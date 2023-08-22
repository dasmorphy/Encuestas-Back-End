using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiprueba.Models;
using apiprueba;
using apiprueba.DTO;
using AutoMapper;
using Newtonsoft.Json;
using apiprueba.Services;

/*
 
Controlador de usuarios mediante crud 
 
*/


namespace apiprueba.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IHashPasswordService hashPasswordService;

        public UsuariosController(ApplicationDbContext context, IMapper mapper, IHashPasswordService hashPasswordService)
        {
            this.context = context;
            this.mapper = mapper;
            this.hashPasswordService = hashPasswordService;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var usuarios = await context.Usuarios.ToListAsync();
            return Ok(usuarios);
        }

        //Obtiene los datos por el id usuario
        [HttpGet("{id_usuario}")]
        public async Task<ActionResult> Get(int id_usuario)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Id_Usuario == id_usuario);
            if (usuario == null)
            {
                return BadRequest("Usuario no encontrado");
            }

            return Ok(usuario);
        }
        
        //Obtiene los datos por el campo usuario
        [HttpGet("usuario/{usuarioString}")]
        public async Task<ActionResult> GetDatosByUsuario(string usuarioString)
        {
            var usuario = await context.Usuarios.SingleOrDefaultAsync(e => e.Usuario == usuarioString);

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }

            return Ok(usuario);
        }

        //Post para el insert de un solo usuario
        [HttpPost]
        public async Task<ActionResult> Post (UsuarioDtoPost usuarioDto)
        {
            try
            {
                //Se comprueba si el usuario ya existe
                var usuarioExist = await context.Usuarios.SingleOrDefaultAsync(x => x.Usuario == usuarioDto.Usuario);

                if (usuarioExist != null)
                {
                    return Conflict("El usuario ya existe");
                }

                //Se mapea los datos necesarios para realizar el insert con solo el id del colaborador
                var usuario = mapper.Map<UsuariosModel>(usuarioDto);
                usuario.Fecha_Creacion = DateTime.Now;

                var rolModel = await context.Roles.FindAsync(usuarioDto.Rol_Id);
                if (rolModel == null)
                {
                    return BadRequest("El rol especificado no existe");
                }

                //Se encripta la contraseña del usuario
                var passHash = hashPasswordService.HashPassword(usuario.Password);

                usuario.Password = passHash;
                usuario.Rol_Id = usuarioDto.Rol_Id;
                usuario.RolesModel = rolModel;

                context.Add(usuario);
                await context.SaveChangesAsync();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al guardar el usuario" + ex.Message);
            }
            
        }


        //Se implementa Post para envio de varios usuarios
        [HttpPost("variosUsuarios")]
        public async Task<ActionResult> Post(UsuarioDtoPost[] usuarioDto)
        {
            var usuarios = mapper.Map<UsuariosModel>(usuarioDto);
            context.AddRange(usuarios);
            await context.SaveChangesAsync();
            return Ok(usuarios);
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate(LoginDto loginDto)
        {
            bool passHash = false;

            var usuario = await context.Usuarios.FirstOrDefaultAsync
            (
                x => x.Usuario == loginDto.Usuario
            );

            if (usuario != null)
            {
                passHash = hashPasswordService.VerifyPassword(loginDto.Password, usuario.Password);

                if (!passHash)
                {
                    return Unauthorized("Credenciales inválidas");
                }
            }
            else
            {
                return Unauthorized("Credenciales inválidas");
            }

            HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(usuario));

            //var sessionUser = JsonConvert.DeserializeObject<UsuariosModel>(HttpContext.Session.GetString("SessionUser"));
            var sessionUser = HttpContext.Session.GetString("SessionUser");
            //var nombreUsuario = HttpContext.Session.GetString("SessionUser");

            //Se valida si la sesion aun esta activa segun el tiempo de vida establecido
            if (sessionUser == null)
            {
                return Redirect("http://localhost:4200/login");
            }else
            {
                var usuarioGuardado = JsonConvert.DeserializeObject<UsuariosModel>(sessionUser);
            }

            Console.WriteLine(sessionUser);
            return Ok(usuario);
        }

        [HttpPut("{id_usuario}")]
        public async Task<ActionResult> Put(int id_usuario, UsuarioDtoPut usuarioDtoPut)
        {
            if (id_usuario != usuarioDtoPut.Id_Usuario)
            {
                return BadRequest("Los id no coinciden");
            }

            var usuarioBD = await context.Usuarios.FirstOrDefaultAsync(x => x.Id_Usuario == id_usuario);

            if (usuarioBD == null)
            { 
                return BadRequest("Usuario no encontrado");
            }
            var rolModel = await context.Roles.FindAsync(usuarioDtoPut.Rol_Id);
            if (rolModel == null)
            {
                return BadRequest("El rol especificado no existe");
            }

            // Conservar los valores actuales de los campos si están vacíos en la solicitud
            if (!string.IsNullOrEmpty(usuarioDtoPut.Password))
            {
                // Se encripta la contraseña del usuario
                var passHash = hashPasswordService.HashPassword(usuarioDtoPut.Password);
                usuarioBD.Password = passHash;
            }

            if (!string.IsNullOrEmpty(usuarioDtoPut.Usuario))
            {
                usuarioBD.Usuario = usuarioDtoPut.Usuario;
            }

            if (!string.IsNullOrEmpty(usuarioDtoPut.Identificacion))
            {
                usuarioBD.Identificacion = usuarioDtoPut.Identificacion;
            }

            usuarioBD.Rol_Id = usuarioDtoPut.Rol_Id;
            usuarioBD.RolesModel = rolModel;

            context.Update(usuarioBD);
            await context.SaveChangesAsync();
            return Ok(usuarioBD);
        }

        [HttpDelete("{id_usuario}")]
        public async Task<ActionResult> Delete(int id_usuario)
        {
            var usuarioBD = await context.Usuarios.FirstOrDefaultAsync(x => x.Id_Usuario == id_usuario);

            if (usuarioBD == null)
                return BadRequest("Usuario no encontrado");

            context.Remove(usuarioBD);
            await context.SaveChangesAsync();
            return Ok(usuarioBD);

        }
    }
}

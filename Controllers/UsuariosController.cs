using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiprueba.Models;
using apiprueba;
using apiprueba.DTO;
using AutoMapper;
using Newtonsoft.Json;

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

        public UsuariosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var usuarios = await context.Usuarios.ToListAsync();
            return Ok(usuarios);
        }

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

        //Post para el insert de un solo usuario
        [HttpPost]
        public async Task<ActionResult> Post (UsuarioDtoPost usuarioDto)
        {
            //Se mapea los datos necesarios para realizar el insert con solo el id del colaborador
            var usuario = mapper.Map<UsuariosModel>(usuarioDto);
            usuario.Fecha_Creacion = DateTime.Now;

            var rolModel = await context.Roles.FindAsync(usuarioDto.Rol_Id);
            if (rolModel == null)
            {
                return BadRequest("El rol especificado no existe");
            }

            var cargoModel = await context.Cargos.FindAsync(usuarioDto.Cargo_Id);
            if (cargoModel == null)
            {
                return BadRequest("El cargo especificado no existe");
            }

            usuario.Rol_Id = usuarioDto.Rol_Id;
            usuario.RolesModel = rolModel;
            usuario.CargosModel = cargoModel;
            context.Add(usuario);
            await context.SaveChangesAsync();
            return Ok(usuario);
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
            var usuario = await context.Usuarios.FirstOrDefaultAsync
            (
                x => x.Usuario == loginDto.Usuario && x.Password == loginDto.Password
            );

            if (usuario == null)
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

            var cargoModel = await context.Cargos.FindAsync(usuarioDtoPut.Cargo_Id);
            if (cargoModel == null)
            {
                return BadRequest("El cargo especificado no existe");
            }

            usuarioBD.Usuario = usuarioDtoPut.Usuario;
            usuarioBD.Password = usuarioDtoPut.Password;
            usuarioBD.Identificacion = usuarioDtoPut.Identificacion;
            usuarioBD.Rol_Id = usuarioDtoPut.Rol_Id;
            usuarioBD.RolesModel = rolModel;
            usuarioBD.Cargo_Id = usuarioDtoPut.Cargo_Id;
            usuarioBD.CargosModel = cargoModel;
            usuarioBD.Grupo = usuarioDtoPut.Grupo;

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

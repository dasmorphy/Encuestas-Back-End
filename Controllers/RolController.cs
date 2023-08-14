using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiprueba.Controllers
{
    [ApiController]
    [Route("api/rol")]
    public class RolController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public RolController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var roles = await context.Roles.ToListAsync();
            return Ok(roles);
        }

        [HttpGet("{id_rol}")]
        public async Task<ActionResult> Get(int id_rol)
        {
            var rol = await context.Roles.FirstOrDefaultAsync(x => x.Id_Rol == id_rol);
            if (rol == null)
            {
                return BadRequest("Rol no encontrado");
            }

            return Ok(rol);
        }
    }
}

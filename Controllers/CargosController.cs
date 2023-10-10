using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiprueba.Controllers
{

    [ApiController]
    [Route("api/cargos")]
    public class CargosController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CargosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var cargos = await context.Cargos.ToListAsync();
            return Ok(cargos);
        }

        //Obtiene los datos por el id cargo
        [HttpGet("{id_cargo}")]
        public async Task<ActionResult> Get(int id_cargo)
        {
            var cargo = await context.Cargos.FirstOrDefaultAsync(x => x.Id_Cargo == id_cargo);
            if (cargo == null)
            {
                return BadRequest("Cargo no encontrado");
            }

            return Ok(cargo);
        }
    }
}

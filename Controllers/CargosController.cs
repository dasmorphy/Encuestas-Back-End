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
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiprueba.Controllers
{
    [ApiController]
    [Route("api/tipoEvaluacion")]
    public class TipoEvaluacionController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TipoEvaluacionController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var tipoEvaluacion = await context.Tipo_Evaluacion.ToListAsync();
            return Ok(tipoEvaluacion);
        }
    }
}

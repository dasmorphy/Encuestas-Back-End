using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiprueba.Controllers
{

    [ApiController]
    [Route("api/observacion")]
    public class ObservacionController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ObservacionController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var observaciones = await context.ObservacionEvaluacion.ToListAsync();

            if (observaciones == null)
            {
                return BadRequest("Lista de observaciones no encontradas");
            }
            return Ok(observaciones);
        }

        [HttpGet("{id_evaluacion}")]
        public async Task<ActionResult> Get(int id_evaluacion)
        {
            var observacion = await context.ObservacionEvaluacion.FirstOrDefaultAsync(x => x.Evaluacion_id == id_evaluacion);
            if (observacion == null)
            {
                return BadRequest("Registro de observacion no encontrada");
            }

            return Ok(observacion);
        }
    }
}

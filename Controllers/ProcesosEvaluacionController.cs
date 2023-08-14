using apiprueba.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static apiprueba.DTO.ProcesosEvalaucionDto;

namespace apiprueba.Controllers
{
    [ApiController]
    [Route("api/procesosEvaluacion")]
    public class ProcesosEvaluacionController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProcesosEvaluacionController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var procesosEvaluacion = await context.ProcesosEvaluacion.ToListAsync();

            return Ok(procesosEvaluacion);

        }

        [HttpGet("ultimoRegistro")]
        public async Task<ActionResult> GetUltimoRegistro()
        {
            // Ordenar los registros por ID en orden descendente y obtener el primero
            var ultimoRegistro = await context.ProcesosEvaluacion
                                            .OrderByDescending(registro => registro.Id_Proceso_Evaluacion)
                                            .FirstOrDefaultAsync();

            if (ultimoRegistro != null)
            {
                return Ok(ultimoRegistro);
            }
            else
            {
                return NotFound("No se encontraron registros");
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post(ProcesosEvaluacionDtoPost procesoEvaluacionDtoPost)
        {
            var procesoEvaluacion = mapper.Map<FechaProcesosEvaluacionModel>(procesoEvaluacionDtoPost);

            procesoEvaluacion.Fecha_Inicio = procesoEvaluacion.Fecha_Inicio.Date; //se envia solo la fecha y no la hora
            procesoEvaluacion.Fecha_Fin = procesoEvaluacion.Fecha_Fin.Date; //se envia solo la fecha y no la hora
            procesoEvaluacion.Estado = "Activo";
                                

            context.Add(procesoEvaluacion);
            await context.SaveChangesAsync();

            return Ok(procesoEvaluacion);

        }

        [HttpPut("{id_proceso}")]
        public async Task<ActionResult> Put(int id_proceso, ProcesosEvaluacionDtoPut procesoEvaluacionDtoPut)
        {
            if (id_proceso != procesoEvaluacionDtoPut.Id_Proceso_Evaluacion)
            {
                return BadRequest("Los id no coinciden");
            }

            var procesoBD = await context.ProcesosEvaluacion.FirstOrDefaultAsync(x => x.Id_Proceso_Evaluacion == id_proceso);

            if (procesoBD == null)
            {
                return BadRequest("Proceso no encontrado");
            }

            procesoBD.Estado = procesoEvaluacionDtoPut.Estado;


            context.Update(procesoBD);
            await context.SaveChangesAsync();
            return Ok(procesoBD);
        }

    }
}

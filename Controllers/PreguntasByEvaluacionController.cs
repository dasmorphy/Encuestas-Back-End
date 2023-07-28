using apiprueba.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using static apiprueba.DTO.PreguntasByEvaluacionDto;

namespace apiprueba.Controllers
{
    [ApiController]
    [Route("api/preguntasEvaluacion")]
    public class PreguntasByEvaluacionController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PreguntasByEvaluacionController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

            // Configuración de JsonSerializerOptions
            jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 50 // Ajusta la profundidad máxima permitida según tus necesidades
            };
        }

        private readonly JsonSerializerOptions jsonSerializerOptions;

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var preguntasEvaluacion = await context.PreguntasByEvaluacion.ToListAsync();

            return Ok(preguntasEvaluacion);
        }

        [HttpGet("{id_preguntaEvaluacion}")]
        public async Task<ActionResult> Get(int id_preguntaEvaluacion)
        {
            var preguntasEvaluacion = await context.PreguntasByEvaluacion.FirstOrDefaultAsync(x => x.Id_Preguntas_Tipo == id_preguntaEvaluacion);
            if (preguntasEvaluacion == null)
            {
                return BadRequest("Pregunta no encontrada");
            }

            return Ok(preguntasEvaluacion);
        }

        [HttpPost]
        public async Task<ActionResult> Post(PreguntasByEvaluacionDtoPost preguntasEvaluacionDto)
        {
            var preguntasEvaluacion = mapper.Map<PreguntasByEvaluacionModel>(preguntasEvaluacionDto);
            preguntasEvaluacion.Fecha_Creacion = DateTime.Now;

            var modulo = await context.ModuloEvaluacion.FindAsync(preguntasEvaluacionDto.Modulo_Id);
            if (modulo == null)
            {
                return BadRequest("El modulo especificado no está registrado en la base de datos");
            }

            //var tipoEvaluacion = await context.Tipo_Evaluacion.FindAsync(preguntasEvaluacionDto.Tipo_Evaluacion_Id);
            //if (tipoEvaluacion == null)
            //{
            //    return BadRequest("El tipoEvaluacion especificado no está registrado en la base de datos");
            //}

            preguntasEvaluacion.ModuloEvaluacionModel = modulo;
            //preguntasEvaluacion.TipoEvaluacionModel = tipoEvaluacion;

            context.Add(preguntasEvaluacion);
            await context.SaveChangesAsync();

            var jsonString = JsonSerializer.Serialize(preguntasEvaluacion, jsonSerializerOptions);

            return Ok(jsonString);
        }
    }
}


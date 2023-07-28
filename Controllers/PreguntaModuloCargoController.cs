using apiprueba.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static apiprueba.DTO.ModuloEvaluacionDto;

namespace apiprueba.Controllers
{

    [ApiController]
    [Route("api/preguntaModuloCargo")]
    public class PreguntaModuloCargoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PreguntaModuloCargoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var preguntaModuloCargo = await context.Evaluacion.ToListAsync();
            return Ok(preguntaModuloCargo);
        }


        [HttpGet("{id_Cargo}")]
        public async Task<ActionResult<List<ModuloPreguntasDtoGet>>> ObtenerModulosConPreguntats(int id_Cargo)
        {
            try
            {
                var preguntaModuloCargo = context.PreguntasModuloCargo
                .Where(e => e.Cargo_Id == id_Cargo)
                .Select(e => new
                {
                    e.Modulo_Id,
                    e.Tipo_Evaluacion_Id // Agrega otros campos que desees obtener
                })
                .ToList();

                if (preguntaModuloCargo.Count == 0)
                {
                    return BadRequest("No se encontraron resultados");
                }

                var resultado = new List<ModuloPreguntasDtoGet>();

                foreach (var item in preguntaModuloCargo)
                {
                    var moduloId = item.Modulo_Id;
                    var tipoEvaluacion = item.Tipo_Evaluacion_Id;

                    // Buscar el módulo en el modelo "OtroModelo" por el "moduloId"
                    var modulo = await context.ModuloEvaluacion.FirstOrDefaultAsync(x => x.Id_Modulo_Evaluacion == moduloId);

                    if (modulo != null)
                    {
                        // Obtener las preguntas del módulo utilizando los valores de "item" u otros criterios que desees
                        var preguntas = await context.PreguntasByEvaluacion
                            .Where(x => x.Tipo_Evaluacion_Id == tipoEvaluacion && x.Modulo_Id == moduloId) // Agrega otros criterios si es necesario
                            .Select(x => new PreguntasByEvaluacionModel
                            {
                                Id_Preguntas_Tipo = x.Id_Preguntas_Tipo,
                                Pregunta = x.Pregunta,
                                Numero_Pregunta = x.Numero_Pregunta,
                                Modulo_Id = x.Modulo_Id,
                                Tipo_Evaluacion_Id = x.Tipo_Evaluacion_Id
                            })
                            .ToListAsync();

                        // Agregar los resultados a "resultado" (si deseas hacerlo de esta manera)
                        resultado.Add(new ModuloPreguntasDtoGet
                        {
                            Id_ModuloPregunta = modulo.Id_Modulo_Evaluacion,
                            Nombre_Modulo = modulo.Nombre_Modulo,
                            Definicion = modulo.Definicion,
                            Tipo_Evaluacion_Id = modulo.Tipo_Evaluacion_Id,
                            PreguntasByEvaluacionModel = preguntas
                        });
                    }
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error en el servidor: {ex.Message}");
            }

            






            //return Ok(preguntaModuloCargo);
        }
    }
}

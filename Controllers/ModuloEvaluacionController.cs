using apiprueba.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static apiprueba.DTO.ModuloEvaluacionDto;

namespace apiprueba.Controllers
{
    [ApiController]
    [Route("api/modulo")]
    public class ModuloEvaluacionController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ModuloEvaluacionController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var modulos = await context.ModuloEvaluacion.ToListAsync();
            return Ok(modulos);
        }

        [HttpGet("{id_modulo}")]
        public async Task<ActionResult> Get(int id_modulo)
        {
            var modulo = await context.ModuloEvaluacion.FirstOrDefaultAsync(x => x.Id_Modulo_Evaluacion == id_modulo);
            if (modulo == null)
            {
                return BadRequest("Modulo no encontrado");
            }

            return Ok(modulo);
        }

        [HttpGet("preguntasModulo/{sessionData}")]
        public async Task<ActionResult<List<ModuloPreguntasDtoGet>>> ObtenerModulosConPreguntas(int sessionData)
        {
            try
            {
                var modulosConPreguntas = await context.ModuloEvaluacion
                .Include(m => m.PreguntasByEvaluacion)
                .ToListAsync();

                var resultado = modulosConPreguntas.Select(modulo => new ModuloPreguntasDtoGet
                {
                    Id_ModuloPregunta = modulo.Id_Modulo_Evaluacion,
                    Nombre_Modulo = modulo.Nombre_Modulo,
                    Definicion = modulo.Definicion,
                    Tipo_Evaluacion_Id = modulo.Tipo_Evaluacion_Id,
                    PreguntasByEvaluacionModel = context.PreguntasByEvaluacion
                    .Where(pregunta => pregunta.Modulo_Id == modulo.Id_Modulo_Evaluacion)
                    .Where(pregunta => pregunta.Tipo_Evaluacion_Id == sessionData)
                    .Select(pregunta => new PreguntasByEvaluacionModel
                    {
                        Id_Preguntas_Tipo = pregunta.Id_Preguntas_Tipo,
                        Pregunta = pregunta.Pregunta,
                        Numero_Pregunta = pregunta.Numero_Pregunta,
                        Modulo_Id = pregunta.Modulo_Id,
                        Tipo_Evaluacion_Id = pregunta.Tipo_Evaluacion_Id
                    })
                    .ToList()
                }).ToList();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error en el servidor: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post(ModuloEvaluacionDtoPost moduloDtoPost)
        {
            var modulo = mapper.Map<ModuloEvaluacionModel>(moduloDtoPost);
            modulo.Fecha_Creacion = DateTime.Now;
            var tipoEvaluacion = await context.Tipo_Evaluacion.FindAsync(moduloDtoPost.Tipo_Evaluacion_Id);
            if (tipoEvaluacion == null)
            {
                return BadRequest("El tipo de evaluacion especificado no existe");
            }
            context.Add(modulo);
            await context.SaveChangesAsync();
            return Ok(modulo);
        }

        [HttpPut("{id_modulo}")]
        public async Task<ActionResult> Put(int id_modulo, ModuloEvaluacionDtoPut moduloDtoPut)
        {
            if (id_modulo != moduloDtoPut.Id_Modulo_Evaluacion)
            {
                return BadRequest("Los id no coinciden");
            }

            var moduloBD = await context.ModuloEvaluacion.FirstOrDefaultAsync(x => x.Id_Modulo_Evaluacion == id_modulo);

            if (moduloBD == null)
            {
                return BadRequest("Modulo no encontrado");
            }
            moduloBD.Nombre_Modulo = moduloDtoPut.Nombre_Modulo;
            moduloBD.Definicion = moduloDtoPut.Definicion;


            context.Update(moduloBD);
            await context.SaveChangesAsync();
            return Ok(moduloBD);
        }

        [HttpDelete("{id_modulo}")]
        public async Task<ActionResult> Delete(int id_modulo)
        {
            var moduloBD = await context.ModuloEvaluacion.FirstOrDefaultAsync(x => x.Id_Modulo_Evaluacion == id_modulo);

            if (moduloBD == null)
                return BadRequest("Modulo no encontrado");

            context.Remove(moduloBD);
            await context.SaveChangesAsync();
            return Ok("Modulo Eliminado");

        }

    }
}

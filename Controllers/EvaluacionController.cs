using apiprueba.DTO;
using apiprueba.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


//Pendiente validar - se cambian modelos de evaluacion 04-05-2023


namespace apiprueba.Controllers
{
    [ApiController]
    [Route("api/evaluacion/")]
    public class EvaluacionController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public EvaluacionController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var evaluaciones = await context.Evaluacion.ToListAsync();
            return Ok(evaluaciones);
        }

        [HttpGet("search/{id_Colaborador}/{id_Usuario}")]
        public IActionResult Get(int id_Colaborador, int id_Usuario)
        {
            // Realiza una consulta a la base de datos para obtener las evaluaciones que coinciden con los parámetros
            var evaluaciones = context.Evaluacion
                .Where(e => e.Colaborador_id == id_Colaborador && e.Usuario_id == id_Usuario)
                .ToList();
            if (evaluaciones.Count == 0)
            {
                return BadRequest("No se encontraron evaluaciones");
            }
            return Ok(evaluaciones);
        }

        [HttpGet("evaluacionByUsuario/{id_usuario}")]
        public async Task<ActionResult> GetEvaluacionrByUsuario(int id_usuario)
        {
            var usuario = await context.Usuarios.SingleOrDefaultAsync(e => e.Id_Usuario == id_usuario);

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }

            var rolUsuario = context.Roles
               .Where(e => e.Id_Rol == usuario.Rol_Id)
               .SingleOrDefault();

            if (rolUsuario == null)
            {
                return NotFound("Rol del usuario no encontrado");
            }

            //Si el usuario tiene rol de admin se devuelve todas las evaluaciones
            if (string.Equals(rolUsuario.Nombre_Rol, "administrador", StringComparison.OrdinalIgnoreCase))
            {
                var evaluaciones = await context.Evaluacion.ToListAsync();

                return Ok(evaluaciones);
            }
            else
            {
                var evaluaciones = context.Evaluacion
               .Where(e => e.Usuario_id == usuario.Id_Usuario)
               .ToList();
                if (evaluaciones.Count == 0)
                {
                    return BadRequest("No se encontraron evaluaciones");
                }
                return Ok(evaluaciones);
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post(EvaluacionObservacionModel evaluacionObservacion)
        {
            try
            {
                //se guarda los diferentes DTO's correspondientes
                var evaluacionDto = evaluacionObservacion.EvaluacionDto;
                var observacionDto = evaluacionObservacion.ObservacionDto;
                var evaluacion = mapper.Map<EvaluacionModel>(evaluacionDto);
                var observacion = mapper.Map<ObservacionModel>(observacionDto);
                observacion.Fecha_Creacion = DateTime.Now;
                evaluacion.Fecha_Creacion = DateTime.Now;
            

                var usuarioExist = await context.Usuarios.FindAsync(evaluacionDto.Usuario_id);
                if (usuarioExist == null)
                {
                    return BadRequest("El usuario no existe");
                }

                var colaboradorExist = await context.Colaborador.FindAsync(evaluacionDto.Colaborador_id);
                if (colaboradorExist == null)
                {
                    return BadRequest("El colaborador no existe");
                }

                if (evaluacion.Estado == "Borrador") 
                {
                    colaboradorExist.Estado = "Borrador";
                }
                else
                {
                    colaboradorExist.Estado = "Evaluado";
                }

                // Se suman los valores de los campos Clfc_Pregunta
                decimal sumaClfcPregunta = 0;
                foreach (var property in typeof(EvaluacionPostDto).GetProperties())
                {
                    if (property.Name.StartsWith("Clfc_Pregunta") && property.PropertyType == typeof(decimal))
                    {
                        decimal? value = (decimal?)property.GetValue(evaluacionDto);
                        if (value != null)
                        {
                            sumaClfcPregunta += value.Value;
                        }
                    }
                }

                evaluacion.UsuariosModel = usuarioExist;
                evaluacion.ColaboradorModel = colaboradorExist;
                evaluacion.CalificacionFinal = sumaClfcPregunta;

                context.Add(evaluacion);
                await context.SaveChangesAsync();

                observacion.Evaluacion_id = evaluacion.Id_Evaluacion;

                context.Add(observacion);
                await context.SaveChangesAsync();

                var resultados = new
                {
                    Evaluacion = evaluacion,
                    Observacion = observacion
                };

                return Ok(resultados);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al guardar los datos: " + ex.Message);
            }
        }

        [HttpPut("{id_Evaluacion}")]
        public async Task<ActionResult> Put(int id_Evaluacion, EvaluacionObservacionPut evaluacionObservacionPut)
        {
            try 
            { 
                var evaluacionDtoPut = evaluacionObservacionPut.evaluacionDtoPut;
                var observacionDtoPut = evaluacionObservacionPut.observacionDtoPut;

                if (id_Evaluacion != evaluacionDtoPut.Id_Evaluacion)
                    return BadRequest("Los id no coinciden");

                var evaluacionBD = await context.Evaluacion.FirstOrDefaultAsync(x => x.Id_Evaluacion == id_Evaluacion);

                if (evaluacionBD == null)
                    return BadRequest("Evaluacion no encontrada");

                var observacionBD = await context.ObservacionEvaluacion.FirstOrDefaultAsync(x => x.Evaluacion_id == id_Evaluacion);

                if (observacionBD == null)
                    return BadRequest("Observaciones de la evaluacion no encontrada");

                // Actualizar solo los campos que no sean nulos en el modelo DTO
                var properties = typeof(EvaluacionPutDto).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var property in properties)
                {
                    // Obtener el valor de la propiedad en evaluacionDtoPut
                    var value = property.GetValue(evaluacionDtoPut);

                    // Si el valor no es nulo, actualizar el campo correspondiente en evaluacionBD
                    if (value != null)
                    {
                        // Obtener el nombre del campo en evaluacionBD que corresponde a la propiedad
                        var fieldName = property.Name;
                        var field = typeof(EvaluacionModel).GetProperty(fieldName, BindingFlags.Public | BindingFlags.Instance);

                        // Si el campo existe en evaluacionBD y es editable, actualizar su valor
                        if (field != null && field.CanWrite)
                        {
                            field.SetValue(evaluacionBD, value);
                        }
                    }
                }

                // Calcular la suma de las calificaciones
                decimal sumaClfcPregunta = 0;
                for (int i = 1; i <= 52; i++)
                {
                    var property = typeof(EvaluacionPutDto).GetProperty($"Clfc_Pregunta{i}", BindingFlags.Public | BindingFlags.Instance);
                    if (property != null && property.PropertyType == typeof(decimal?))
                    {
                        decimal? calificacion = (decimal?)property.GetValue(evaluacionDtoPut);
                        if (calificacion != null)
                        {
                            sumaClfcPregunta += calificacion.Value;
                        }
                    }
                }
                if (evaluacionBD.Estado == "Realizada") 
                {
                    var colaboradorBD = await context.Colaborador.FirstOrDefaultAsync(x => x.Id_Colaborador == evaluacionBD.Colaborador_id);
                    colaboradorBD.Estado = "Evaluado";
                    context.Update(colaboradorBD);
                    await context.SaveChangesAsync();
                }
                else
                {
                    var colaboradorBD = await context.Colaborador.FirstOrDefaultAsync(x => x.Id_Colaborador == evaluacionBD.Colaborador_id);
                    colaboradorBD.Estado = evaluacionBD.Estado;
                    context.Update(colaboradorBD);
                    await context.SaveChangesAsync();
                }
                // Asignar la suma total al campo CalificacionFinal de evaluacionBD
                evaluacionBD.CalificacionFinal = sumaClfcPregunta;

                context.Update(evaluacionBD);
                await context.SaveChangesAsync();

                Type dtoType = observacionDtoPut.GetType();
                Type modelType = observacionBD.GetType();

                foreach (var property in dtoType.GetProperties())
                {
                    var propertyName = property.Name;
                    var modelProperty = modelType.GetProperty(propertyName);

                    if (modelProperty != null)
                    {
                        var value = property.GetValue(observacionDtoPut);
                        modelProperty.SetValue(observacionBD, value);
                    }
                }

                context.Update(observacionBD);
                await context.SaveChangesAsync();

                var resultados = new
                {
                    Evaluacion = evaluacionBD,
                    Observacion = observacionBD
                };

                return Ok(resultados);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al actualizar los datos: " + ex.Message);
            }

        }

        [HttpPut("evaluacionEstado/{id_Evaluacion}")]
        public async Task<ActionResult> UpdateEvaluacionEstado(int id_Evaluacion, EvaluacionPutDto evaluacionPutDto)
        {
            if (id_Evaluacion != evaluacionPutDto.Id_Evaluacion)
            {
                return BadRequest("Los id no coinciden");
            }

            var evaluacionBD = await context.Evaluacion.FirstOrDefaultAsync(x => x.Id_Evaluacion == id_Evaluacion);

            if (evaluacionBD == null)
            {
                return BadRequest("Usuario no encontrado");
            }
            evaluacionBD.Estado = evaluacionPutDto.Estado;


            context.Update(evaluacionBD);
            await context.SaveChangesAsync();
            return Ok(evaluacionBD);
        }

        [HttpDelete("{id_evaluacion}")]
        public async Task<ActionResult> Delete(int id_evaluacion)
        {
            var evaluacionBD = await context.Evaluacion.FirstOrDefaultAsync(x => x.Id_Evaluacion == id_evaluacion);

            if (evaluacionBD == null)
                return BadRequest("Evaluacion no encontrada");

            context.Remove(evaluacionBD);
            await context.SaveChangesAsync();
            return Ok(evaluacionBD);

        }


    }
}

using apiprueba.Models;
using Microsoft.EntityFrameworkCore;
using static apiprueba.DTO.ModuloEvaluacionDto;

namespace apiprueba.Services
{
    public class ModuloPreguntasService : IModuloPreguntasService
    {
        private readonly ApplicationDbContext context;

        public ModuloPreguntasService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<ModuloPreguntasDtoGet>> ObtenerModulosConPreguntas(int id_Cargo)
        {
            
            var preguntaModuloCargo = context.PreguntasModuloCargo
                .Where(e => e.Cargo_Id == id_Cargo)
                .Select(e => new
                {
                    e.Modulo_Id,
                    e.Tipo_Evaluacion_Id
                })
                .ToList();

            if (preguntaModuloCargo.Count == 0)
            {
                return null;
            }

            var resultado = new List<ModuloPreguntasDtoGet>();

            foreach (var item in preguntaModuloCargo)
            {
                var moduloId = item.Modulo_Id;
                var tipoEvaluacion = item.Tipo_Evaluacion_Id;
                var modulo = await context.ModuloEvaluacion.FirstOrDefaultAsync(x => x.Id_Modulo_Evaluacion == moduloId);

                if (modulo != null)
                {
                    // Obtener las preguntas del módulo utilizando los valores de "item"
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

                    // Agregar los resultados a "resultado"
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

            return resultado;
        }
    }
}

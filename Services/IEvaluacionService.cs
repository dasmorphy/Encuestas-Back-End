using apiprueba.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiprueba.Services
{
    public interface IEvaluacionService
    {
        Task<byte[]> exportarEvaluaciones(List<string> estados);

        Task<byte[]> exportarEvaluacionesAcumulado(List<string> estados);

        Task<Object> actualizarEvaluacion(EvaluacionModel evaluacionBD, ObservacionModel observacionBD, EvaluacionObservacionPut evaluacionObservacionPut);

        Task<Object> guardarEvaluacionAndObservacion(EvaluacionObservacionModel evaluacionObservacion);

        Task<Object> obtenerPromedioCompetencias(string? cedulaColaborador = "");
    
    }
}

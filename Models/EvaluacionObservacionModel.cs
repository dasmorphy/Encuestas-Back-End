using apiprueba.DTO;

namespace apiprueba.Models
{
    public class EvaluacionObservacionModel
    {
        public EvaluacionPostDto EvaluacionDto { get; set; } = null!;
        public ObservacionDtoPost ObservacionDto { get; set; } = null!;
    }
}

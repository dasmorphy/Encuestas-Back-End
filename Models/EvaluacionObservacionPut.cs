using apiprueba.DTO;

namespace apiprueba.Models
{
    public class EvaluacionObservacionPut
    {
        public EvaluacionPutDto evaluacionDtoPut { get; set; } = null!;
        public ObservacionDtoPut observacionDtoPut { get; set; } = null!;
    }
}

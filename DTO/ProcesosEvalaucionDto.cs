using System.ComponentModel.DataAnnotations;

namespace apiprueba.DTO
{
    public class ProcesosEvalaucionDto
    {
        public class ProcesosEvaluacionDtoPost
        {  
            [DataType(DataType.Date)] 
            public DateTime Fecha_Inicio { get; set; }

      
            [DataType(DataType.Date)] 
            public DateTime Fecha_Fin { get; set; }

            public string Estado { get; set; } = null!;
        }

        public class ProcesosEvaluacionDtoPut
        {
            public int Id_Proceso_Evaluacion { get; set; }

            public string Estado { get; set; } = null!;
        }
    }
}

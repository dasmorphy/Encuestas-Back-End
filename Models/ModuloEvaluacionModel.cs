using System.ComponentModel.DataAnnotations;

namespace apiprueba.Models
{
    public class ModuloEvaluacionModel
    {
        [Key]
        public int Id_Modulo_Evaluacion { get; set; }
        [StringLength(maximumLength: 50)]
        public string Nombre_Modulo { get; set; } = null!;
        [StringLength(maximumLength: 400)]
        public string Definicion { get; set; } = null!;
        public DateTime Fecha_Creacion { get; set; }
        public int Tipo_Evaluacion_Id { get; set; }
        public HashSet<PreguntasByEvaluacionModel> PreguntasByEvaluacion { get; set; } = new HashSet<PreguntasByEvaluacionModel>();
        public TipoEvaluacionModel TipoEvaluacionModel { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiprueba.Models
{
    public class PreguntasByEvaluacionModel
    {
        [Key]
        [Column(Order = 1)]
        public int Id_Preguntas_Tipo { get; set; }

        [Column(Order = 3)]
        public int Tipo_Evaluacion_Id { get; set; }

        [Column(Order = 4)]
        public int Modulo_Id { get; set; }

        [Column(Order = 5)]
        [StringLength(maximumLength: 350)]
        public string Pregunta { get; set; } = null!;

        [Column(Order = 6)]
        public int Numero_Pregunta { get; set; }

        public DateTime Fecha_Creacion { get; set; }

        public ModuloEvaluacionModel ModuloEvaluacionModel { get; set; } = null!;
        public TipoEvaluacionModel TipoEvaluacionModel { get; set; } = null!;
        //public HashSet<EvaluacionModel> Evaluacion { get; set; } = new HashSet<EvaluacionModel>();

    }
}

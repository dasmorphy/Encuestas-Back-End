using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiprueba.DTO
{
    public class PreguntasByEvaluacionDto
    {
        public class PreguntasByEvaluacionDtoPost
        {

            [Column(Order = 4)]
            public int Modulo_Id { get; set; }

            [Column(Order = 5)]
            [StringLength(maximumLength: 250)]
            public string Pregunta { get; set; } = null!;

        }


        public class PreguntasByEvaluacionDtoPut
        {
            [Key]
            [Column(Order = 1)]
            public int Id_Preguntas_Tipo { get; set; }

            [Column(Order = 4)]
            public int Modulo_Id { get; set; }

            [Column(Order = 5)]
            [StringLength(maximumLength: 250)]
            public string Pregunta { get; set; } = null!;
        }

    }
}

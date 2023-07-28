using apiprueba.Models;
using System.ComponentModel.DataAnnotations;

namespace apiprueba.DTO
{
    public class ModuloEvaluacionDto
    {
        public class ModuloEvaluacionDtoPost
        {
 
            [StringLength(maximumLength: 50)]
            public string Nombre_Modulo { get; set; } = null!;
            [StringLength(maximumLength: 300)]
            public string Definicion { get; set; } = null!;
            public int Tipo_Evaluacion_Id { get; set; }
        }


        public class ModuloEvaluacionDtoPut
        {
            [Key]
            public int Id_Modulo_Evaluacion { get; set; }
            [StringLength(maximumLength: 50)]
            public string Nombre_Modulo { get; set; } = null!;
            [StringLength(maximumLength: 300)]
            public string Definicion { get; set; } = null!;
            public int Tipo_Evaluacion_Id { get; set; }

        }

        public class ModuloPreguntasDtoGet
        {
            [Key]
            public int Id_ModuloPregunta { get; set; }
            [StringLength(maximumLength: 50)]
            public string Nombre_Modulo { get; set; } = null!;
            [StringLength(maximumLength: 300)]
            public string Definicion { get; set; } = null!;
            public int Tipo_Evaluacion_Id { get; set; }
            public List<PreguntasByEvaluacionModel> PreguntasByEvaluacionModel { get; set; } = null!;
            public TipoEvaluacionModel TipoEvaluacionModel { get; set; } = null!;
        }
    }
}

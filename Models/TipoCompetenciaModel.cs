using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiprueba.Models
{
    public class TipoCompetenciaModel
    {
        [Key]
        [Column(Order = 1)]
        public int Id_Tipo_Competencia { get; set; }

        [StringLength(maximumLength: 60)]
        [Column(Order = 2)]
        public string Nombre { get; set; } = null!;

        public HashSet<ModuloEvaluacionModel> ModuloEvaluacion { get; set; } = new HashSet<ModuloEvaluacionModel>();
    }
}

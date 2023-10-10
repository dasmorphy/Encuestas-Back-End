using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiprueba.Models
{
    public class FechaProcesosEvaluacionModel
    {
        [Key]
        [Column(Order = 1)]
        public int Id_Proceso_Evaluacion { get; set; }

        [Column(Order = 2)]
        [DataType(DataType.Date)] // Indicar que es solo la parte de la fecha
        public DateTimeOffset Fecha_Inicio { get; set; }

        [Column(Order = 3)]
        [DataType(DataType.Date)] // Indicar que es solo la parte de la fecha
        public DateTimeOffset Fecha_Fin { get; set; }

        [Column(Order = 4)]
        [StringLength(maximumLength: 8)]
        public string Estado { get; set; } = null!;

    }
}

using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiprueba.Models
{
    public class CargosModel
    {
        [Key]
        [Column(Order = 1)]
        public int Id_Cargo { get; set; }
        [Column(Order = 2)]
        public string Nombre_Cargo { get; set; } = null!;

    }
}

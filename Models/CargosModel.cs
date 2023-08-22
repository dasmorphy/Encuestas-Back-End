using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;

namespace apiprueba.Models
{
    public class CargosModel
    {
        [Key]
        public int Id_Cargo { get; set; }

        public string Nombre_Cargo { get; set; } = null!;

    }
}

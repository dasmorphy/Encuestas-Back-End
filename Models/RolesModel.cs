using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiprueba.Models
{
    //[Index(nameof(Id_Usuario), IsUnique = true)]
    public class RolesModel
    {
        [Key]
        public int Id_Rol { get; set; }

        [StringLength(maximumLength: 20)]
        public string Nombre_Rol { get; set; } = null!;
        //public int Id_Usuario { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public HashSet<UsuariosModel> UsuariosModel { get; set; } = new HashSet<UsuariosModel>();

    }
}

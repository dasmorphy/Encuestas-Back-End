using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 
Modelo para la tabla Usuarios


*/

namespace apiprueba.Models
{
    public class UsuariosModel
    {
        [Key]
        public int Id_Usuario { get; set; }

        [StringLength(maximumLength: 20)]
        public string Usuario { get; set; } = null!;

        [StringLength(maximumLength: 10)]
        public string Identificacion { get; set; } = null!;

        [StringLength(maximumLength: 12)]
        public string Password { get; set; } = null!;
        //public int Tipo_Evaluacion_Id { get; set; }
        public int Rol_Id { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public HashSet<EvaluacionModel> Evaluacion { get; set; } = new HashSet<EvaluacionModel>();
        //public TipoEvaluacionModel TipoEvaluacionModel { get; set; } = null!;
        public RolesModel RolesModel { get; set; } = null!;

    }
}
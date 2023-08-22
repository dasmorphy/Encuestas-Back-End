using apiprueba.Models;
using System.ComponentModel.DataAnnotations;

/*
 
Dto para el Modelo Usuario, el cual implementa solamente los datos necesarios y 
suficientes para realizar un Post 


*/


namespace apiprueba.DTO
{
    public class UsuarioDtoPost
    {
        [StringLength(maximumLength: 20)]
        public string Usuario { get; set; } = null!;
        [StringLength(maximumLength: 10)]
        public string Identificacion { get; set; } = null!;

        [StringLength(maximumLength: 12)]
        public string Password { get; set; } = null!;
        public int Rol_Id { get; set; }
    }

    public class UsuarioDtoPut
    {
        [Key]
        public int Id_Usuario { get; set; }

        [StringLength(maximumLength: 20)]
        public string Usuario { get; set; } = null!;

        [StringLength(maximumLength: 10)]
        public string Identificacion { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Rol_Id { get; set; }
    }
}

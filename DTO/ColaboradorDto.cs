using System.ComponentModel.DataAnnotations;

namespace apiprueba.DTO
{
    public class ColaboradorDto
    {

        public class ColaboradorDtoPost
        {
            [StringLength(maximumLength: 30)]
            public string Nombres { get; set; } = null!;

            [StringLength(maximumLength: 30)]
            public string Apellidos { get; set; } = null!;

            [StringLength(maximumLength: 11)]
            public string? Estado { get; set; } = null!;
            public DateTime? Fecha_Creacion { get; set; }
        }


        public class ColaboradorDtoPut
        {
            [Key]
            public int Id_Colaborador { get; set; }

            [StringLength(maximumLength: 11)]
            public string? Estado { get; set; }
        }

    }
}

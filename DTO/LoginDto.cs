using System.ComponentModel.DataAnnotations;

namespace apiprueba.DTO
{
    public class LoginDto
    {
        [StringLength(maximumLength: 20)]
        public string Usuario { get; set; } = null!;

        [StringLength(maximumLength: 12)]
        public string Password { get; set; } = null!;
    }

}

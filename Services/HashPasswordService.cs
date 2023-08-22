using BCrypt.Net;
using System.Threading.Tasks;

namespace apiprueba.Services
{
    public class HashPasswordService : IHashPasswordService
    {
        public string HashPassword(string password)
        {
            // Genera un nuevo salt para cada contraseña
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            // Hashea la contraseña usando el salt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            // Verifica si la contraseña ingresada coincide con la contraseña almacenada
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}

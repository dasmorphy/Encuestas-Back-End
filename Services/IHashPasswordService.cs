namespace apiprueba.Services
{
    public interface IHashPasswordService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}

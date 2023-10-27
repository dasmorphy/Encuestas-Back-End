using apiprueba.DTO;
using apiprueba.Models;
using apiprueba.Utils;
using Microsoft.AspNetCore.Mvc;

namespace apiprueba.Services
{
    public interface IUsuarioService
    {
        Task<RespuestaService> guardarCsvUsuario(IFormFile file);

    }
}

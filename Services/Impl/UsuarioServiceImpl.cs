using apiprueba.DTO;
using apiprueba.Models;
using apiprueba.Utils;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace apiprueba.Services.Impl
{
    public class UsuarioServiceImpl : IUsuarioService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IHashPasswordService hashPasswordService;

        public UsuarioServiceImpl(ApplicationDbContext context, IMapper mapper, IHashPasswordService hashPasswordService)
        {
            this.context = context;
            this.mapper = mapper;
            this.hashPasswordService = hashPasswordService;
        }

        public async Task<RespuestaService> guardarCsvUsuario(IFormFile file)
        {
            RespuestaService resultado = new RespuestaService();
            try
            {
                if (file == null || file.Length == 0)
                {
                    throw new Exception("Archivo no seleccionado o vacío.");
                }

                // Procesa el archivo CSV y almacena los datos en la tabla existente
                using var streamReader = new StreamReader(file.OpenReadStream(), System.Text.Encoding.UTF8);
                using var csvReader = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",
                    HasHeaderRecord = false,
                    MissingFieldFound = null
                });

                var records = csvReader.GetRecords<UsuariosModel>().ToList();

                foreach (var record in records)
                {
                    //Se comprueba si el usuario ya existe
                    var usuarioExist = await context.Usuarios.SingleOrDefaultAsync(x => x.Usuario == record.Usuario);

                    if (usuarioExist != null)
                    {
                        resultado.Status = 409;
                        resultado.Mensaje = $"El usuario {record.Usuario} ya existe";
                        return resultado;
                    }

                    record.Fecha_Creacion = DateTime.Now;

                    //Se encripta la contraseña del usuario
                    var passHash = hashPasswordService.HashPassword(record.Password);
                    record.Password = passHash;

                    var rolModel = await context.Roles.FindAsync(record.Rol_Id);
                    if (rolModel == null)
                    {
                        throw new Exception("El rol no existe");
                    }

                    record.RolesModel = rolModel;

                    context.Usuarios.Add(record);
                }

                context.SaveChanges();

                resultado.Status = 200;
                resultado.Mensaje = "Archivo CSV cargado correctamente";

            }
            catch (Exception ex)
            {
                resultado.Status = 500;
                resultado.Mensaje = "Error al crear al usuario: " + ex.Message;
            }

            return resultado;
        }
    }
}

using apiprueba.Models;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Globalization;
using static apiprueba.DTO.ColaboradorDto;

namespace apiprueba.Controllers
{
    [ApiController]
    [Route("api/colaborador")]
    public class ColaboradorController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ColaboradorController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var colaborador = await context.Colaborador.ToListAsync();

            return Ok(colaborador);

        }

        [HttpGet("colaboradorByUsuario/{id_usuario}")]
        public async Task<ActionResult> GetColaboradorByUsuarioId(int id_usuario)
        {
            // Realiza una consulta a la base de datos para obtener las evaluaciones que coinciden con los parámetros

            var usuario = context.Usuarios.SingleOrDefault(e => e.Id_Usuario == id_usuario);

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado"); 
            }

            var rolUsuario = context.Roles
               .Where(e => e.Id_Rol == usuario.Rol_Id)
               .SingleOrDefault();

            if (rolUsuario == null) { 
                return NotFound("Rol del usuario no encontrado"); 
            }

            if (string.Equals(rolUsuario.Nombre_Rol, "administrador", StringComparison.OrdinalIgnoreCase))
            {
                var colaborador = await context.Colaborador.ToListAsync();

                return Ok(colaborador);
            }
            else
            {
                var colaborador = context.Colaborador
                .Where(e => e.Cedula_Jefe == usuario.Identificacion)
                .ToList();
                return Ok(colaborador);
            }

        }

        [HttpGet("{id_colaborador}")]
        public async Task<ActionResult> Get(int id_colaborador)
        {
            var colaborador = await context.Colaborador.FirstOrDefaultAsync(x => x.Id_Colaborador == id_colaborador);
            if (colaborador == null)
            {
                return BadRequest("Colaborador no encontrado");
            }

            return Ok(colaborador);
        }

        //Metodo para la exportacion del archivo excel de la tabla Colaboradores

        [HttpGet("exportarColaboradores")]
        public IActionResult ExportarPersonas([FromQuery] string estadosSeleccionados)
        {
            try
            {
                List<string> estados = estadosSeleccionados.Split(',').ToList();

                var colaboradores = context.Colaborador.ToList();

                if (estados != null && estados.Count > 0)
                {
                    colaboradores = colaboradores.Where(c => estados.Contains(c.Estado)).ToList();
                }

                string formatoFecha = "dd/MM/yyyy";
                byte[] result;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Colaboradores");

                    // Agregar encabezados

                    worksheet.Cells[1, 1].Value = "CEDULA DEL EVALUADO";
                    worksheet.Cells[1, 2].Value = "NOMBRES DEL EVALUADO";
                    worksheet.Cells[1, 3].Value = "FECHA INGRESO DEL EVALUADO";
                    worksheet.Cells[1, 4].Value = "CARGO DEL EVALUADO";
                    worksheet.Cells[1, 5].Value = "CC";
                    worksheet.Cells[1, 6].Value = "LOCALIDAD";
                    worksheet.Cells[1, 7].Value = "ZONA";
                    worksheet.Cells[1, 8].Value = "AREA";
                    worksheet.Cells[1, 9].Value = "DEPARTAMENTO";
                    worksheet.Cells[1, 10].Value = "CEDULA DEL JEFE";
                    worksheet.Cells[1, 11].Value = "NOMBRES DEL JEFE";
                    worksheet.Cells[1, 12].Value = "FECHA INGRESO DEL JEFE";
                    worksheet.Cells[1, 13].Value = "CARGO DEL JEFE";
                    worksheet.Cells[1, 14].Value = "ESTADO";

                    // Agregar datos
                    for (int i = 0; i < colaboradores.Count; i++)
                    {
                        worksheet.Cells[i + 2, 1].Value = colaboradores[i].Cedula;
                        worksheet.Cells[i + 2, 2].Value = colaboradores[i].Nombres;
                        worksheet.Cells[i + 2, 3].Value = colaboradores[i].Fe_Ingreso_Colaborador;
                        worksheet.Cells[i + 2, 4].Value = colaboradores[i].Cargo_Colaborador;
                        worksheet.Cells[i + 2, 5].Value = colaboradores[i].CC;
                        worksheet.Cells[i + 2, 6].Value = colaboradores[i].Localidad;
                        worksheet.Cells[i + 2, 7].Value = colaboradores[i].Zona;
                        worksheet.Cells[i + 2, 8].Value = colaboradores[i].Area;
                        worksheet.Cells[i + 2, 9].Value = colaboradores[i].Departamento;
                        worksheet.Cells[i + 2, 10].Value = colaboradores[i].Cedula_Jefe;
                        worksheet.Cells[i + 2, 11].Value = colaboradores[i].Nombres_Jefe;
                        worksheet.Cells[i + 2, 12].Value = colaboradores[i].Fe_Ingreso_Jefe;
                        worksheet.Cells[i + 2, 13].Value = colaboradores[i].Cargo_Jefe;
                        worksheet.Cells[i + 2, 14].Value = colaboradores[i].Estado;

                        worksheet.Cells[i + 2, 3].Style.Numberformat.Format = formatoFecha;
                        worksheet.Cells[i + 2, 12].Style.Numberformat.Format = formatoFecha;
                    }

                    // Autoajustar las columnas
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    result = package.GetAsByteArray();
                }

                // Devolver el archivo Excel
                return File(result, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Colaboradores.xlsx");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al generar el archivo Excel." + ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> Post(ColaboradorDtoPost colaboradorDto)
        {
            var colaborador = mapper.Map<ColaboradorModel>(colaboradorDto);
            //colaborador.Fecha_Creacion = DateTime.Now;
            colaborador.Estado = "No Evaluado";
            context.Add(colaborador);
            await context.SaveChangesAsync();
            return Ok(colaborador);
        }

        [HttpPost("csv")]
        public IActionResult UploadCsv(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Archivo no seleccionado o vacío.");
                }

                // Procesa el archivo CSV y almacena los datos en la tabla existente
                using var streamReader = new StreamReader(file.OpenReadStream(), System.Text.Encoding.UTF8);
                using var csvReader = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",
                    HasHeaderRecord = false,
                    MissingFieldFound = null
                });
                //csvReader.Configuration.HeaderValidated = null;
                //csvReader.Configuration.MissingFieldFound = null;
                var records = csvReader.GetRecords<ColaboradorModel>().ToList();

                foreach (var record in records)
                {
                    record.Estado = "No Evaluado";
                    //record.Fecha_Creacion = DateTime.Now;
                    context.Colaborador.Add(record);
                }

                context.SaveChanges();

                return Ok(new { message = "Archivo CSV cargado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error en el servidor: {ex.Message}" });
            }
        }


        [HttpPut("{id_colaborador}")]
        public async Task<ActionResult> Put(int id_colaborador, ColaboradorDtoPut colaboradorDtoPut)
        {
            if (id_colaborador != colaboradorDtoPut.Id_Colaborador)
                return BadRequest("Los id no coinciden");

            var colaboradorBD = await context.Colaborador.FirstOrDefaultAsync(x => x.Id_Colaborador == id_colaborador);

            if (colaboradorBD == null)
                return BadRequest("Colaborador no encontrado");


            // Actualizar solo los campos que no sean nulos en el modelo DTO
            //if (colaboradorDtoPut.Nombres != null)
            //    colaboradorBD.Nombres = colaboradorDtoPut.Nombres;

            if (colaboradorDtoPut.Estado != null)
                colaboradorBD.Estado = colaboradorDtoPut.Estado;

            context.Update(colaboradorBD);
            await context.SaveChangesAsync();
            return Ok(colaboradorBD);
        }

        [HttpDelete("{id_colaborador}")]
        public async Task<ActionResult> Delete(int id_colaborador)
        {
            var colaboradorBD = await context.Colaborador.FirstOrDefaultAsync(x => x.Id_Colaborador == id_colaborador);

            if (colaboradorBD == null)
                return BadRequest("Colaborador no encontrado");

            context.Remove(colaboradorBD);
            await context.SaveChangesAsync();
            return Ok(colaboradorBD);

        }

    }
}

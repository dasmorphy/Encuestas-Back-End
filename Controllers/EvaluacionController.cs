using apiprueba.DTO;
using apiprueba.Models;
using apiprueba.Services;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Globalization;
using System.Reflection;


//Pendiente validar - se cambian modelos de evaluacion 04-05-2023


namespace apiprueba.Controllers
{
    [ApiController]
    [Route("api/evaluacion/")]
    public class EvaluacionController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IEvaluacionService evaluacionService;

        public EvaluacionController(ApplicationDbContext context, IEvaluacionService evaluacionService)
        {
            this.context = context;
            this.evaluacionService = evaluacionService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var evaluaciones = await context.Evaluacion.ToListAsync();
            return Ok(evaluaciones);
        }

        [HttpGet("search/{id_Colaborador}/{id_Usuario}")]
        public IActionResult Get(int id_Colaborador, int id_Usuario)
        {
            // Realiza una consulta a la base de datos para obtener las evaluaciones que coinciden con los parámetros
            var evaluaciones = context.Evaluacion
                .Where(e => e.Colaborador_id == id_Colaborador && e.Usuario_id == id_Usuario)
                .ToList();
            if (evaluaciones.Count == 0)
            {
                return BadRequest("No se encontraron evaluaciones");
            }
            return Ok(evaluaciones);
        }

        [HttpGet("evaluacionByUsuario/{id_usuario}")]
        public async Task<ActionResult> GetEvaluacionrByUsuario(int id_usuario)
        {
            var usuario = await context.Usuarios.SingleOrDefaultAsync(e => e.Id_Usuario == id_usuario);

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }

            var rolUsuario = context.Roles
               .Where(e => e.Id_Rol == usuario.Rol_Id)
               .SingleOrDefault();

            if (rolUsuario == null)
            {
                return NotFound("Rol del usuario no encontrado");
            }

            var evaluaciones = context.Evaluacion
               .Where(e => e.Usuario_id == usuario.Id_Usuario)
               .ToList();
            if (evaluaciones.Count == 0)
            {
                return BadRequest("No se encontraron evaluaciones");
            }
            return Ok(evaluaciones);

            //Si el usuario tiene rol de admin se devuelve todas las evaluaciones
            //if (string.Equals(rolUsuario.Nombre_Rol, "administrador", StringComparison.OrdinalIgnoreCase))
            //{
            //    var evaluaciones = await context.Evaluacion.ToListAsync();

            //    return Ok(evaluaciones);
            //}
            //else
            //{
            //    var evaluaciones = context.Evaluacion
            //   .Where(e => e.Usuario_id == usuario.Id_Usuario)
            //   .ToList();
            //    if (evaluaciones.Count == 0)
            //    {
            //        return BadRequest("No se encontraron evaluaciones");
            //    }
            //    return Ok(evaluaciones);
            //}
        }

        //Metodo para la exportacion del archivo excel de la tabla Evaluaciones

        [HttpGet("exportarEvaluaciones")]
        async public Task<IActionResult> ExportarEvaluaciones([FromQuery] string estadosSeleccionados)
        {
            try
            {
                List<string> estados = estadosSeleccionados.Split(',').ToList();

                var evaluacionesData = await evaluacionService.exportarEvaluaciones(estados);
                var fileName = "Evaluaciones.xlsx";
                return File(evaluacionesData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al generar el archivo Excel." + ex.Message);
            }
        }


        //Metodo para la exportacion del archivo excel de la tabla Evaluaciones

        [HttpGet("evaluacionesRoles")]
        async public Task<IActionResult> ExportarEvaluacionesRoles([FromQuery] string estadosSeleccionados)
        {
            try
            {
                List<string> estados = estadosSeleccionados.Split(',').ToList();

                byte[] result = null;

                var evaluaciones = context.Evaluacion.ToList();

                if (estados != null && estados.Count > 0)
                {
                    evaluaciones = evaluaciones.Where(c => estados.Contains(c.Estado)).ToList();
                }

                var colaboradoresIds = evaluaciones.Select(evaluacion => evaluacion.Colaborador_id).Distinct().ToList();

                var colaboradores = await context.Colaborador
                    .Where(colaborador => colaboradoresIds.Contains(colaborador.Id_Colaborador))
                    .ToListAsync();

                var evaluacionesAgrupadas = evaluaciones
                    .GroupBy(evaluacion => colaboradores.FirstOrDefault(colaborador => colaborador.Id_Colaborador == evaluacion.Colaborador_id)?.Nombres)
                    .Select(grupo => new {
                        ColaboradorNombre = grupo.Key,
                        Evaluaciones = grupo.ToList(),
                        ColaboradorIdentificacion = colaboradores.FirstOrDefault(colaborador => colaborador.Nombres == grupo.Key)?.Cedula,
                    })
                    .ToList();

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Evaluaciones");

                    // Agregar encabezados
                    worksheet.Cells[1, 1].Value = "Evaluado";
                    worksheet.Cells[1, 2].Value = "Identificacion del Evaluado";
                    worksheet.Cells[1, 3].Value = "JEFE";
                    worksheet.Cells[1, 4].Value = "CLIENTE";
                    worksheet.Cells[1, 5].Value = "EQUIPO";
                    worksheet.Cells[1, 6].Value = "Calificacion Final";

                    int row = 2; // Fila donde comenzar a agregar datos

                    foreach (var grupo in evaluacionesAgrupadas)
                    {
                        var colaboradorNombre = grupo.ColaboradorNombre;
                        var evaluacionesDelColaborador = grupo.Evaluaciones;

                        worksheet.Cells[row, 1].Value = colaboradorNombre;
                        worksheet.Cells[row, 2].Value = grupo.ColaboradorIdentificacion;
                        decimal? calificacionFinal = 0;
                        decimal? valorResultante = 0;

                        foreach (var evaluacion in evaluacionesDelColaborador)
                        {
                            var colaborador = await context.Colaborador.FirstOrDefaultAsync(u => u.Id_Colaborador == evaluacion.Colaborador_id);
                            var cargo = await context.Cargos.FirstOrDefaultAsync(u => u.Id_Cargo == colaborador.Cargo_Id);

                            if (cargo != null && colaborador != null)
                            {
                                if (cargo.Nombre_Cargo == "Jefaturas")
                                {
                                    if (colaborador.Grupo == "JEFE")
                                    {
                                        decimal? porcentajeGrupo = 0.40M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;//ej 5*40% = 2
                                                                                                                    //decimal? valorMaximo = 5;

                                        //decimal? porcentajeOriginal = (valorResultante / valorMaximo) * 100;

                                        //Console.WriteLine($"Valor Resultante: {valorResultante} => Porcentaje Original: {porcentajeOriginal}%");
                                        valorResultante += valorCalificacion;


                                        worksheet.Cells[row, 3].Value = valorCalificacion;
                                    }

                                    if (colaborador.Grupo == "CLIENTE")
                                    {
                                        decimal? porcentajeGrupo = 0.40M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;//ej 5*40% = 2
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 4].Value = valorCalificacion;
                                    }

                                    if (colaborador.Grupo == "EQUIPO")
                                    {
                                        decimal? porcentajeGrupo = 0.20M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;//ej 5*40% = 2
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 5].Value = valorCalificacion;
                                    }
                                }

                                else if (cargo.Nombre_Cargo == "Supervisores" || cargo.Nombre_Cargo == "Gestor")
                                {
                                    if (colaborador.Grupo == "JEFE")
                                    {
                                        decimal? porcentajeGrupo = 0.60M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 3].Value = valorCalificacion;
                                    }

                                    if (colaborador.Grupo == "EQUIPO")
                                    {
                                        decimal? porcentajeGrupo = 0.40M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;//ej 5*40% = 2
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 5].Value = valorCalificacion;
                                    }
                                }

                                else if (cargo.Nombre_Cargo == "Coordinador")
                                {
                                    if (colaborador.Grupo == "JEFE")
                                    {
                                        decimal? porcentajeGrupo = 0.60M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 3].Value = valorCalificacion;
                                    }

                                    if (colaborador.Grupo == "CLIENTE")
                                    {
                                        decimal? porcentajeGrupo = 0.40M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;//ej 5*40% = 2
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 4].Value = valorCalificacion;
                                    }
                                }

                                else if (cargo.Nombre_Cargo == "Analista" || cargo.Nombre_Cargo == "Vendedor" || cargo.Nombre_Cargo == "Auxiliar")
                                {
                                    if (colaborador.Grupo == "JEFE")
                                    {
                                        decimal? porcentajeGrupo = 1.00M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 3].Value = valorCalificacion;
                                    }
                                }

                                else if (cargo.Nombre_Cargo == "Administrador")
                                {
                                    if (colaborador.Grupo == "JEFE")
                                    {
                                        decimal? porcentajeGrupo = 0.50M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 3].Value = valorCalificacion;
                                    }

                                    if (colaborador.Grupo == "EQUIPO")
                                    {
                                        decimal? porcentajeGrupo = 0.50M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;//ej 5*40% = 2
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 5].Value = valorCalificacion;
                                    }
                                }

                                //string usuarioNombre = usuario.Usuario;

                            }
                        }
                        
                        calificacionFinal += valorResultante;
                        worksheet.Cells[row, 6].Value = calificacionFinal;

                        row++;
                    }

                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    result = package.GetAsByteArray();
                }

                if (result != null)
                {
                    // Devolver el archivo Excel
                    return File(result, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Evaluaciones.xlsx");

                }
                else
                {
                    return BadRequest("Ocurrio un error al generar el archivo");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al generar el archivo Excel." + ex.Message);
            }
        }

        //Metodo para la exportacion del archivo excel de la tabla Evaluaciones por Acumulado

        [HttpGet("detalladoAcumulado")]
        async public Task<IActionResult> DetalladoAcumulado([FromQuery] string estadosSeleccionados)
        {
            try
            {
                List<string> estados = estadosSeleccionados.Split(',').ToList();
                var evaluacionesData = await evaluacionService.exportarEvaluacionesAcumulado(estados);
                var fileName = "EvaluacionesAcumulado.xlsx";
                return File(evaluacionesData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al generar el archivo Excel." + ex.Message);
            }
        }

        //Metodo para obtener los promedios de las competencias

        [HttpGet("promediosCompetencia")]
        async public Task<IActionResult> ObtenerPromedios(string? cedulaColaborador = "")
        {
            try
            {
                var evaluacionesData = await evaluacionService.obtenerPromedioCompetencias(cedulaColaborador);
                return Ok(evaluacionesData);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los promedios." + ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post(EvaluacionObservacionModel evaluacionObservacion)
        {
            try
            {
                var evaluacionGuardada = await evaluacionService.guardarEvaluacionAndObservacion(evaluacionObservacion);
                return Ok(evaluacionGuardada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al guardar los datos: " + ex.Message);
            }
        }

        [HttpPut("{id_Evaluacion}")]
        public async Task<ActionResult> Put(int id_Evaluacion, EvaluacionObservacionPut evaluacionObservacionPut)
        {
            try 
            {
                var evaluacionDtoPut = evaluacionObservacionPut.evaluacionDtoPut;

                if (id_Evaluacion != evaluacionDtoPut.Id_Evaluacion)
                    throw new Exception("Los id no coinciden");

                var evaluacionBD = await context.Evaluacion.FirstOrDefaultAsync(x => x.Id_Evaluacion == id_Evaluacion);

                if (evaluacionBD == null)
                    throw new Exception("Evaluacion no encontrada");

                var observacionBD = await context.ObservacionEvaluacion.FirstOrDefaultAsync(x => x.Evaluacion_id == id_Evaluacion);

                if (observacionBD == null)
                    throw new Exception("Observaciones de la evaluacion no encontrada");

                var evaluacionesData = await evaluacionService.actualizarEvaluacion(evaluacionBD, observacionBD, evaluacionObservacionPut);

                return Ok(evaluacionesData);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al actualizar los datos: " + ex.Message);
            }

        }

        [HttpPut("evaluacionEstado/{id_Evaluacion}")]
        public async Task<ActionResult> UpdateEvaluacionEstado(int id_Evaluacion, EvaluacionPutDto evaluacionPutDto)
        {
            if (id_Evaluacion != evaluacionPutDto.Id_Evaluacion)
            {
                return BadRequest("Los id no coinciden");
            }

            var evaluacionBD = await context.Evaluacion.FirstOrDefaultAsync(x => x.Id_Evaluacion == id_Evaluacion);

            if (evaluacionBD == null)
            {
                return BadRequest("Usuario no encontrado");
            }
            evaluacionBD.Estado = evaluacionPutDto.Estado;


            context.Update(evaluacionBD);
            await context.SaveChangesAsync();
            return Ok(evaluacionBD);
        }

        [HttpDelete("{id_evaluacion}")]
        public async Task<ActionResult> Delete(int id_evaluacion)
        {
            var evaluacionBD = await context.Evaluacion.FirstOrDefaultAsync(x => x.Id_Evaluacion == id_evaluacion);

            if (evaluacionBD == null)
                return BadRequest("Evaluacion no encontrada");

            var colaborador = await context.Colaborador.FirstAsync(c => c.Id_Colaborador == evaluacionBD.Colaborador_id);

            //Se actualiza el estado del colaborador
            colaborador.Estado = "No Evaluado";

            context.Remove(evaluacionBD);
            await context.SaveChangesAsync();
            return Ok(evaluacionBD);

        }


    }
}

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
        private readonly IMapper mapper;
        private readonly IModuloPreguntasService moduloPreguntasService;

        public EvaluacionController(ApplicationDbContext context, IMapper mapper, IModuloPreguntasService moduloPreguntasService)
        {
            this.context = context;
            this.mapper = mapper;
            this.moduloPreguntasService = moduloPreguntasService;
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

            //Si el usuario tiene rol de admin se devuelve todas las evaluaciones
            if (string.Equals(rolUsuario.Nombre_Rol, "administrador", StringComparison.OrdinalIgnoreCase))
            {
                var evaluaciones = await context.Evaluacion.ToListAsync();

                return Ok(evaluaciones);
            }
            else
            {
                var evaluaciones = context.Evaluacion
               .Where(e => e.Usuario_id == usuario.Id_Usuario)
               .ToList();
                if (evaluaciones.Count == 0)
                {
                    return BadRequest("No se encontraron evaluaciones");
                }
                return Ok(evaluaciones);
            }
        }

        //Metodo para la exportacion del archivo excel de la tabla Evaluaciones

        [HttpGet("exportarEvaluaciones")]
        async public Task<IActionResult> ExportarEvaluaciones([FromQuery] string estadosSeleccionados)
        {
            try
            {
                List<string> estados = estadosSeleccionados.Split(',').ToList();

                var evaluaciones = context.Evaluacion.ToList();

                if (estados != null && estados.Count > 0)
                {
                    evaluaciones = evaluaciones.Where(c => estados.Contains(c.Estado)).ToList();
                }

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Evaluaciones");

                    // Agregar encabezados
                    worksheet.Cells[1, 1].Value = "Evaluador";
                    worksheet.Cells[1, 2].Value = "Identificacion del Evaluador";
                    worksheet.Cells[1, 3].Value = "Evaluado";
                    worksheet.Cells[1, 4].Value = "Identificacion del Evaluado";
                    worksheet.Cells[1, 5].Value = "Fecha";
                    worksheet.Cells[1, 6].Value = "Calificacion Final";
                    worksheet.Cells[1, 7].Value = "Estado";

                    int row = 2; // Fila donde comenzar a agregar datos

                    foreach (var evaluacion in evaluaciones)
                    {
                        var colaborador = await context.Colaborador.FirstOrDefaultAsync(c => c.Id_Colaborador == evaluacion.Colaborador_id);
                        var usuario = await context.Usuarios.FirstOrDefaultAsync(u => u.Id_Usuario == evaluacion.Usuario_id);

                        if (colaborador != null && usuario != null)
                        {
                            string nombreColaborador = colaborador.Nombres;
                            string usuarioNombre = usuario.Usuario;

                            decimal? calificacionFinal = evaluacion.CalificacionFinal;
                            string formatoFecha = "dd/MM/yyyy";

                            var preguntaModuloResult = await moduloPreguntasService.ObtenerModulosConPreguntas(usuario.Cargo_Id);

                            //var preguntaModuloResult = preguntaModuloResultTask.Result;

                            if (preguntaModuloResult != null && preguntaModuloResult != null)
                            {
                                int currentColumn = 8; // Inicializar en la columna 8

                                foreach (var moduloPregunta in preguntaModuloResult)
                                {
                                    if (moduloPregunta.PreguntasByEvaluacionModel != null && moduloPregunta.PreguntasByEvaluacionModel.Count > 0)
                                    {
                                        worksheet.Cells[1, currentColumn].Value = moduloPregunta.Nombre_Modulo;

                                        var preguntaByEvaluacion = moduloPregunta.PreguntasByEvaluacionModel[0];

                                        var pregunta = preguntaByEvaluacion.Pregunta;
                                        var numeroPregunta = preguntaByEvaluacion.Numero_Pregunta;

                                        string propertyName = $"Clfc_Pregunta{numeroPregunta}";

                                        // Se utiliza reflexión para acceder a la propiedad de evaluación
                                        var propertyInfo = evaluacion.GetType().GetProperty(propertyName);
                                        if (propertyInfo != null)
                                        {
                                            var propertyValue = propertyInfo.GetValue(evaluacion);
                                            worksheet.Cells[row, currentColumn].Value = propertyValue;
                                        }
                                        //row++;
                                        currentColumn++;
                                    }
                                }
                            }

                            // Agregar datos a la fila actual
                            worksheet.Cells[row, 1].Value = usuarioNombre;
                            worksheet.Cells[row, 2].Value = usuario.Identificacion;
                            worksheet.Cells[row, 3].Value = nombreColaborador;
                            worksheet.Cells[row, 4].Value = colaborador.Cedula;
                            worksheet.Cells[row, 5].Value = evaluacion.Fecha_Creacion;
                            worksheet.Cells[row, 6].Value = calificacionFinal;
                            worksheet.Cells[row, 7].Value = evaluacion.Estado;

                            worksheet.Cells[row, 5].Style.Numberformat.Format = formatoFecha;

                            row++; // Avanzar a la siguiente fila

                        }

                    }

                    // Autoajustar las columnas
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    byte[] result = package.GetAsByteArray();

                    // Devolver el archivo Excel
                    return File(result, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Evaluaciones.xlsx");

                }
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
                            var usuario = await context.Usuarios.FirstOrDefaultAsync(u => u.Id_Usuario == evaluacion.Usuario_id);
                            var cargo = await context.Cargos.FirstOrDefaultAsync(u => u.Id_Cargo == usuario.Cargo_Id);

                            if (cargo != null && usuario != null)
                            {
                                if (cargo.Nombre_Cargo == "Jefaturas")
                                {
                                    if (usuario.Grupo == "JEFE")
                                    {
                                        decimal? porcentajeGrupo = 0.40M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;//ej 5*40% = 2
                                                                                                                    //decimal? valorMaximo = 5;

                                        //decimal? porcentajeOriginal = (valorResultante / valorMaximo) * 100;

                                        //Console.WriteLine($"Valor Resultante: {valorResultante} => Porcentaje Original: {porcentajeOriginal}%");
                                        valorResultante += valorCalificacion;


                                        worksheet.Cells[row, 3].Value = valorCalificacion;
                                    }

                                    if (usuario.Grupo == "CLIENTE")
                                    {
                                        decimal? porcentajeGrupo = 0.40M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;//ej 5*40% = 2
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 4].Value = valorCalificacion;
                                    }

                                    if (usuario.Grupo == "EQUIPO")
                                    {
                                        decimal? porcentajeGrupo = 0.20M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;//ej 5*40% = 2
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 5].Value = valorCalificacion;
                                    }
                                }

                                else if (cargo.Nombre_Cargo == "Supervisores" || cargo.Nombre_Cargo == "Gestor")
                                {
                                    if (usuario.Grupo == "JEFE")
                                    {
                                        decimal? porcentajeGrupo = 0.60M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 3].Value = valorCalificacion;
                                    }

                                    if (usuario.Grupo == "EQUIPO")
                                    {
                                        decimal? porcentajeGrupo = 0.40M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;//ej 5*40% = 2
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 5].Value = valorCalificacion;
                                    }
                                }

                                else if (cargo.Nombre_Cargo == "Coordinador")
                                {
                                    if (usuario.Grupo == "JEFE")
                                    {
                                        decimal? porcentajeGrupo = 0.60M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 3].Value = valorCalificacion;
                                    }

                                    if (usuario.Grupo == "CLIENTE")
                                    {
                                        decimal? porcentajeGrupo = 0.40M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;//ej 5*40% = 2
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 4].Value = valorCalificacion;
                                    }
                                }

                                else if (cargo.Nombre_Cargo == "Analista" || cargo.Nombre_Cargo == "Vendedor" || cargo.Nombre_Cargo == "Auxiliar")
                                {
                                    if (usuario.Grupo == "JEFE")
                                    {
                                        decimal? porcentajeGrupo = 1.00M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 3].Value = valorCalificacion;
                                    }
                                }

                                else if (cargo.Nombre_Cargo == "Administrador")
                                {
                                    if (usuario.Grupo == "JEFE")
                                    {
                                        decimal? porcentajeGrupo = 0.50M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 3].Value = valorCalificacion;
                                    }

                                    if (usuario.Grupo == "EQUIPO")
                                    {
                                        decimal? porcentajeGrupo = 0.50M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo;//ej 5*40% = 2
                                        valorResultante += valorCalificacion;
                                        worksheet.Cells[row, 5].Value = valorCalificacion;
                                    }
                                }

                                string usuarioNombre = usuario.Usuario;

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


        [HttpPost]
        public async Task<ActionResult> Post(EvaluacionObservacionModel evaluacionObservacion)
        {
            try
            {
                //se guarda los diferentes DTO's correspondientes
                var evaluacionDto = evaluacionObservacion.EvaluacionDto;
                var observacionDto = evaluacionObservacion.ObservacionDto;
                var evaluacion = mapper.Map<EvaluacionModel>(evaluacionDto);
                var observacion = mapper.Map<ObservacionModel>(observacionDto);
                decimal competenciaOrganizacional = 0M;
                decimal competenciaEstrategica = 0M;
                decimal competenciaFuncional = 0M;
                var cargoUsuario = "";
                observacion.Fecha_Creacion = DateTime.Now;
                evaluacion.Fecha_Creacion = DateTime.Now;
            

                var usuarioExist = await context.Usuarios.FindAsync(evaluacionDto.Usuario_id);
                if (usuarioExist == null)
                {
                    return BadRequest("El usuario no existe");
                }

                var colaboradorExist = await context.Colaborador.FindAsync(evaluacionDto.Colaborador_id);
                if (colaboradorExist == null)
                {
                    return BadRequest("El colaborador no existe");
                }

                if (evaluacion.Estado == "Borrador") 
                {
                    colaboradorExist.Estado = "Borrador";
                }
                else
                {
                    colaboradorExist.Estado = "Evaluado";
                }

                if (usuarioExist != null)
                {
                    var cargo = await context.Cargos.FirstOrDefaultAsync(x => x.Id_Cargo == usuarioExist.Cargo_Id);

                    if (cargo != null)
                    {
                        if (cargo.Nombre_Cargo == "Jefaturas")
                        {
                            cargoUsuario = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaEstrategica = 0.50M;
                            competenciaFuncional = 0.30M;
                        }
                        else if (cargo.Nombre_Cargo == "Supervisores")
                        {
                            cargoUsuario = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaEstrategica = 0.40M;
                            competenciaFuncional = 0.40M;
                        }
                        else if (cargo.Nombre_Cargo == "Coordinador")
                        {
                            cargoUsuario = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaEstrategica = 0.30M;
                            competenciaFuncional = 0.50M;
                        }
                        else if (cargo.Nombre_Cargo == "Gestor")
                        {
                            cargoUsuario = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaEstrategica = 0.20M;
                            competenciaFuncional = 0.60M;
                        }
                        else if (cargo.Nombre_Cargo == "Analista")
                        {
                            cargoUsuario = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaFuncional = 0.80M;
                        }
                        else if (cargo.Nombre_Cargo == "Administrador")
                        {
                            cargoUsuario = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaEstrategica = 0.10M;
                            competenciaFuncional = 0.70M;
                        }
                        else if (cargo.Nombre_Cargo == "Vendedor")
                        {
                            cargoUsuario = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaFuncional = 0.80M;
                        }
                        else if (cargo.Nombre_Cargo == "Auxiliar")
                        {
                            cargoUsuario = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaFuncional = 0.80M;
                        }
                    }

                }

                // Se suman los valores de los campos Clfc_Pregunta
                decimal? sumaClfcPregunta = 0;
                decimal? primerCompetencia = 0M;
                decimal? segundaCompetencia = 0M;
                decimal? terceraCompetencia = 0M;

                var preguntasCargoo = await context.PreguntasModuloCargo
                                                .Where(x => x.Cargo_Id == usuarioExist.Cargo_Id)
                                                .ToListAsync();

                foreach (var preguntas in preguntasCargoo)
                {

                    //Se obtiene la pregunta referente al modulo y tipo de evaluacion
                    var modulo = await context.ModuloEvaluacion.FirstOrDefaultAsync(x => x.Id_Modulo_Evaluacion == preguntas.Modulo_Id);
                    var preguntasByModulo = await context.PreguntasByEvaluacion
                                            .Where(x => x.Modulo_Id == preguntas.Modulo_Id)
                                            .Where(x => x.Tipo_Evaluacion_Id == preguntas.Tipo_Evaluacion_Id)
                                            .ToListAsync();
                    if (preguntasByModulo.Count > 0)
                    {
                        foreach (var pregunta in preguntasByModulo)
                        {
                            string propertyName = $"Clfc_Pregunta{pregunta.Numero_Pregunta}";

                            // Obtener el PropertyInfo del objeto EvaluacionPostDto
                            PropertyInfo propertyInfo = typeof(EvaluacionPostDto).GetProperty(propertyName);

                            if (propertyInfo != null)
                            {
                                decimal? value = (decimal?)propertyInfo.GetValue(evaluacionDto);

                                Console.WriteLine($"Pregunta {pregunta.Numero_Pregunta}: {value}");


                                if (modulo != null)
                                {
                                    var tipoCompetencia = await context.TipoCompetencia.FirstOrDefaultAsync(x => x.Id_Tipo_Competencia == modulo.Tipo_Competencia_Id);
                                    if (tipoCompetencia != null)
                                    {
                                        if (tipoCompetencia.Nombre == "COMPETENCIAS ORGANIZACIONALES")
                                        {
                                                
                                            if (cargoUsuario == "Jefaturas")
                                            {
                                                if (modulo.Nombre_Modulo == "Orientación al Servicio")
                                                {
                                                    decimal pesoModulo = 0.40M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Trabajo en Equipo")
                                                {
                                                    decimal pesoModulo = 0.20M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Orientación a los Resultados")
                                                {
                                                    decimal pesoModulo = 0.30M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Diversidad e Inclusión")
                                                {
                                                    decimal pesoModulo = 0.10M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                            }

                                            else if (cargoUsuario == "Supervisores")
                                            {

                                                if (modulo.Nombre_Modulo == "Orientación al Servicio")
                                                {
                                                    decimal pesoModulo = 0.35M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Trabajo en Equipo")
                                                {
                                                    decimal pesoModulo = 0.20M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Orientación a los Resultados")
                                                {
                                                    decimal pesoModulo = 0.30M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Diversidad e Inclusión")
                                                {
                                                    decimal pesoModulo = 0.15M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                            }

                                            else if (cargoUsuario == "Coordinador")
                                            {

                                                if (modulo.Nombre_Modulo == "Orientación al Servicio")
                                                {
                                                    decimal pesoModulo = 0.30M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Trabajo en Equipo")
                                                {
                                                    decimal pesoModulo = 0.30M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Orientación a los Resultados")
                                                {
                                                    decimal pesoModulo = 0.30M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Diversidad e Inclusión")
                                                {
                                                    decimal pesoModulo = 0.10M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                            }

                                            else if (cargoUsuario == "Gestor")
                                            {

                                                if (modulo.Nombre_Modulo == "Orientación al Servicio")
                                                {
                                                    decimal pesoModulo = 0.40M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Trabajo en Equipo")
                                                {
                                                    decimal pesoModulo = 0.20M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Orientación a los Resultados")
                                                {
                                                    decimal pesoModulo = 0.25M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Diversidad e Inclusión")
                                                {
                                                    decimal pesoModulo = 0.15M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                            }

                                            else if (cargoUsuario == "Analista")
                                            {

                                                if (modulo.Nombre_Modulo == "Orientación al Servicio")
                                                {
                                                    decimal pesoModulo = 0.35M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Trabajo en Equipo")
                                                {
                                                    decimal pesoModulo = 0.30M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Orientación a los Resultados")
                                                {
                                                    decimal pesoModulo = 0.25M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Diversidad e Inclusión")
                                                {
                                                    decimal pesoModulo = 0.10M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                            }

                                            else if (cargoUsuario == "Administrador")
                                            {

                                                if (modulo.Nombre_Modulo == "Orientación al Servicio")
                                                {
                                                    decimal pesoModulo = 0.40M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Trabajo en Equipo")
                                                {
                                                    decimal pesoModulo = 0.15M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Orientación a los Resultados")
                                                {
                                                    decimal pesoModulo = 0.30M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Diversidad e Inclusión")
                                                {
                                                    decimal pesoModulo = 0.15M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                            }

                                            else if (cargoUsuario == "Vendedor" || cargoUsuario == "Auxiliar")
                                            {

                                                if (modulo.Nombre_Modulo == "Orientación al Servicio")
                                                {
                                                    decimal pesoModulo = 0.40M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Trabajo en Equipo")
                                                {
                                                    decimal pesoModulo = 0.25M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Orientación a los Resultados")
                                                {
                                                    decimal pesoModulo = 0.20M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                                else if (modulo.Nombre_Modulo == "Diversidad e Inclusión")
                                                {
                                                    decimal pesoModulo = 0.15M;
                                                    value = value.Value * pesoModulo / 5;
                                                    primerCompetencia += value;
                                                }
                                            }

                                        }
                                        else if (tipoCompetencia.Nombre == "COMPETENCIAS ESTRATÉGICAS Y GESTIÓN")
                                        {
                                            if (cargoUsuario == "Jefaturas")
                                            {
                                                if (modulo.Nombre_Modulo == "Pensamiento creativo e innovador")
                                                {
                                                    decimal pesoModulo = 0.40M;
                                                    value = value.Value * pesoModulo / 5;
                                                    segundaCompetencia += value;
                                                }
                                                if (modulo.Nombre_Modulo == "Liderazgo")
                                                {
                                                    decimal pesoModulo = 0.35M;
                                                    value = value.Value * pesoModulo / 5;
                                                    segundaCompetencia += value;
                                                }
                                                if (modulo.Nombre_Modulo == "Planificación, seguimiento y control")
                                                {
                                                    decimal pesoModulo = 0.25M;
                                                    value = value.Value * pesoModulo / 5;
                                                    segundaCompetencia += value;
                                                }
                                            }

                                            else if (cargoUsuario == "Supervisores")
                                            {
                                                if (modulo.Nombre_Modulo == "Pensamiento creativo e innovador")
                                                {
                                                    decimal pesoModulo = 0.30M;
                                                    value = value.Value * pesoModulo / 5;
                                                    segundaCompetencia += value;
                                                }
                                                if (modulo.Nombre_Modulo == "Liderazgo")
                                                {
                                                    decimal pesoModulo = 0.45M;
                                                    value = value.Value * pesoModulo / 5;
                                                    segundaCompetencia += value;
                                                }
                                                if (modulo.Nombre_Modulo == "Planificación, seguimiento y control")
                                                {
                                                    decimal pesoModulo = 0.25M;
                                                    value = value.Value * pesoModulo / 5;
                                                    segundaCompetencia += value;
                                                }
                                            }
                                            else if (cargoUsuario == "Coordinador")
                                            {
                                                if (modulo.Nombre_Modulo == "Liderazgo")
                                                {
                                                    decimal pesoModulo = 0.30M;
                                                    value = value.Value * pesoModulo / 5;
                                                    segundaCompetencia += value;
                                                }
                                                if (modulo.Nombre_Modulo == "Planificación, seguimiento y control")
                                                {
                                                    decimal pesoModulo = 0.70M;
                                                    value = value.Value * pesoModulo / 5;
                                                    segundaCompetencia += value;
                                                }
                                            }
                                            else if (cargoUsuario == "Gestor")
                                            {
                                                if (modulo.Nombre_Modulo == "Planificación, seguimiento y control")
                                                {
                                                    decimal pesoModulo = 1.00M;
                                                    value = value.Value * pesoModulo / 5;
                                                    segundaCompetencia += value;
                                                }
                                            }
                                            else if (cargoUsuario == "Administrador")
                                            {
                                                if (modulo.Nombre_Modulo == "Liderazgo")
                                                {
                                                    decimal pesoModulo = 0.80M;
                                                    value = value.Value * pesoModulo / 5;
                                                    segundaCompetencia += value;
                                                }
                                                if (modulo.Nombre_Modulo == "Planificación, seguimiento y control")
                                                {
                                                    decimal pesoModulo = 0.20M;
                                                    value = value.Value * pesoModulo / 5;
                                                    segundaCompetencia += value;
                                                }
                                            }

                                        }

                                        else if (tipoCompetencia.Nombre == "COMPETENCIAS FUNCIONALES")
                                        {

                                            if (cargoUsuario == "Jefaturas" || cargoUsuario == "Supervisores")
                                            {

                                                if (modulo.Nombre_Modulo == "Pensamiento crítico para la toma de decisiones")
                                                {
                                                    decimal pesoModulo = 1.00M;
                                                    value = value.Value * pesoModulo / 5;
                                                    terceraCompetencia += value;
                                                }
                                            }
                                            else if (cargoUsuario == "Coordinador")
                                            {
                                                    
                                                if (modulo.Nombre_Modulo == "Pensamiento crítico para la toma de decisiones")
                                                {
                                                    decimal pesoPensamientoCritico = 0.50M;
                                                    value = value.Value * pesoPensamientoCritico / 5;
                                                    terceraCompetencia += value;
                                                }
                                                if (modulo.Nombre_Modulo == "Pensamiento Analítico")
                                                {
                                                    decimal pesoPensamientoAnalitico = 0.50M;
                                                    value = value.Value * pesoPensamientoAnalitico / 5;
                                                    terceraCompetencia += value;
                                                }
                                            }
                                            else if (cargoUsuario == "Gestor")
                                            {

                                                if (modulo.Nombre_Modulo == "Responsabilidad")
                                                {
                                                    decimal pesoResponsabilidad = 0.30M;
                                                    value = value.Value * pesoResponsabilidad / 5;
                                                    terceraCompetencia += value;
                                                }
                                                if (modulo.Nombre_Modulo == "Instrucción y Entrenamiento")
                                                {
                                                    decimal pesoInstruccion = 0.35M;
                                                    value = value.Value * pesoInstruccion / 5;
                                                    terceraCompetencia += value;
                                                }
                                                if (modulo.Nombre_Modulo == "Asesoría y ventas")
                                                {
                                                    decimal pesoAsesorias = 0.35M;
                                                    value = value.Value * pesoAsesorias / 5;
                                                    terceraCompetencia += value;
                                                }
                                            }
                                            else if (cargoUsuario == "Analista")
                                            {

                                                if (modulo.Nombre_Modulo == "Pensamiento crítico para la toma de decisiones")
                                                {
                                                    decimal pesoPensamiento = 0.10M;
                                                    value = value.Value * pesoPensamiento / 5;
                                                    terceraCompetencia += value;
                                                }
                                                if (modulo.Nombre_Modulo == "Responsabilidad")
                                                {
                                                    decimal pesoResponsabilidad = 0.40M;
                                                    value = value.Value * pesoResponsabilidad / 5;
                                                    terceraCompetencia += value;
                                                }
                                                if (modulo.Nombre_Modulo == "Pensamiento Analítico")
                                                {
                                                    decimal pesoPensamientoAnalitico = 0.30M;
                                                    value = value.Value * pesoPensamientoAnalitico / 5;
                                                    terceraCompetencia += value;
                                                }
                                                if (modulo.Nombre_Modulo == "Organización del trabajo")
                                                {
                                                    decimal pesoTrabajo = 0.20M;
                                                    value = value.Value * pesoTrabajo / 5;
                                                    terceraCompetencia += value;
                                                }
                                            }
                                            else if (cargoUsuario == "Administrador" || cargoUsuario == "Vendedor")
                                            {
                                                if (modulo.Nombre_Modulo == "Responsabilidad")
                                                {
                                                    decimal pesoResponsabilidad = 0.40M;
                                                    value = value.Value * pesoResponsabilidad / 5;
                                                    terceraCompetencia += value;
                                                }
                                                if (modulo.Nombre_Modulo == "Organización del trabajo")
                                                {
                                                    decimal pesoTrabajo = 0.20M;
                                                    value = value.Value * pesoTrabajo / 5;
                                                    terceraCompetencia += value;
                                                }
                                                if (modulo.Nombre_Modulo == "Asesoría y ventas")
                                                {
                                                    decimal pesoAsesorias = 0.40M;
                                                    value = value.Value * pesoAsesorias / 5;
                                                    terceraCompetencia += value;
                                                }
                                            }
                                            else if (cargoUsuario == "Auxiliar")
                                            {
                                                if (modulo.Nombre_Modulo == "Responsabilidad")
                                                {
                                                    decimal pesoResponsabilidad = 0.60M;
                                                    value = value.Value * pesoResponsabilidad / 5;
                                                    terceraCompetencia += value;
                                                }
                                                if (modulo.Nombre_Modulo == "Pensamiento Analítico")
                                                {
                                                    decimal pesoPensamientoAnalitico = 0.20M;
                                                    value = value.Value * pesoPensamientoAnalitico / 5;
                                                    terceraCompetencia += value;
                                                }
                                                if (modulo.Nombre_Modulo == "Organización del trabajo")
                                                {
                                                    decimal pesoTrabajo = 0.20M;
                                                    value = value.Value * pesoTrabajo / 5;
                                                    terceraCompetencia += value;
                                                }
                                            }

                                        }
                                    }

                                }

                            }
                            else
                            {
                                // La propiedad no existe en el objeto, manejar este caso si es necesario
                                Console.WriteLine("Noexiste");
                            }

                        }
                    }
                }

                //Se calculan los valores finales multiplancando la variable de cada modulo por el peso del tipo competencia
                decimal? clfcOrganizacional = primerCompetencia * competenciaOrganizacional;
                decimal? clfcEstrategica = segundaCompetencia * competenciaEstrategica;
                decimal? clfcFuncional = terceraCompetencia * competenciaFuncional;

                //Se obtiene primero el porcentaje total para pasarlo como numero decimal a sumaClfcPregunta
                decimal? porcentajeClfcPregunta = clfcOrganizacional + clfcEstrategica + clfcFuncional;

                sumaClfcPregunta = porcentajeClfcPregunta * 5; //calificacion final de la evaluacion


                evaluacion.UsuariosModel = usuarioExist;
                evaluacion.ColaboradorModel = colaboradorExist;
                evaluacion.CalificacionFinal = sumaClfcPregunta;

                context.Add(evaluacion);
                await context.SaveChangesAsync();

                observacion.Evaluacion_id = evaluacion.Id_Evaluacion;

                context.Add(observacion);
                await context.SaveChangesAsync();

                var resultados = new
                {
                    Evaluacion = evaluacion,
                    Observacion = observacion
                };

                return Ok(resultados);

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
                var observacionDtoPut = evaluacionObservacionPut.observacionDtoPut;

                if (id_Evaluacion != evaluacionDtoPut.Id_Evaluacion)
                    return BadRequest("Los id no coinciden");

                var evaluacionBD = await context.Evaluacion.FirstOrDefaultAsync(x => x.Id_Evaluacion == id_Evaluacion);

                if (evaluacionBD == null)
                    return BadRequest("Evaluacion no encontrada");

                var observacionBD = await context.ObservacionEvaluacion.FirstOrDefaultAsync(x => x.Evaluacion_id == id_Evaluacion);

                if (observacionBD == null)
                    return BadRequest("Observaciones de la evaluacion no encontrada");

                // Actualizar solo los campos que no sean nulos en el modelo DTO
                var properties = typeof(EvaluacionPutDto).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var property in properties)
                {
                    // Obtener el valor de la propiedad en evaluacionDtoPut
                    var value = property.GetValue(evaluacionDtoPut);

                    // Si el valor no es nulo, actualizar el campo correspondiente en evaluacionBD
                    if (value != null)
                    {
                        // Obtener el nombre del campo en evaluacionBD que corresponde a la propiedad
                        var fieldName = property.Name;
                        var field = typeof(EvaluacionModel).GetProperty(fieldName, BindingFlags.Public | BindingFlags.Instance);

                        // Si el campo existe en evaluacionBD y es editable, actualizar su valor
                        if (field != null && field.CanWrite)
                        {
                            field.SetValue(evaluacionBD, value);
                        }
                    }
                }

                // Calcular la suma de las calificaciones
                decimal sumaClfcPregunta = 0;
                for (int i = 1; i <= 52; i++)
                {
                    var property = typeof(EvaluacionPutDto).GetProperty($"Clfc_Pregunta{i}", BindingFlags.Public | BindingFlags.Instance);
                    if (property != null && property.PropertyType == typeof(decimal?))
                    {
                        decimal? calificacion = (decimal?)property.GetValue(evaluacionDtoPut);
                        if (calificacion != null)
                        {
                            sumaClfcPregunta += calificacion.Value;
                        }
                    }
                }
                if (evaluacionBD.Estado == "Realizada") 
                {
                    var colaboradorBD = await context.Colaborador.FirstOrDefaultAsync(x => x.Id_Colaborador == evaluacionBD.Colaborador_id);
                    colaboradorBD.Estado = "Evaluado";
                    context.Update(colaboradorBD);
                    await context.SaveChangesAsync();
                }
                else
                {
                    var colaboradorBD = await context.Colaborador.FirstOrDefaultAsync(x => x.Id_Colaborador == evaluacionBD.Colaborador_id);
                    colaboradorBD.Estado = evaluacionBD.Estado;
                    context.Update(colaboradorBD);
                    await context.SaveChangesAsync();
                }
                // Asignar la suma total al campo CalificacionFinal de evaluacionBD
                evaluacionBD.CalificacionFinal = sumaClfcPregunta;

                context.Update(evaluacionBD);
                await context.SaveChangesAsync();

                Type dtoType = observacionDtoPut.GetType();
                Type modelType = observacionBD.GetType();

                foreach (var property in dtoType.GetProperties())
                {
                    var propertyName = property.Name;
                    var modelProperty = modelType.GetProperty(propertyName);

                    if (modelProperty != null)
                    {
                        var value = property.GetValue(observacionDtoPut);
                        modelProperty.SetValue(observacionBD, value);
                    }
                }

                context.Update(observacionBD);
                await context.SaveChangesAsync();

                var resultados = new
                {
                    Evaluacion = evaluacionBD,
                    Observacion = observacionBD
                };

                return Ok(resultados);
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

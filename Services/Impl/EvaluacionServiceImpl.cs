using OfficeOpenXml;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using apiprueba.Models;
using apiprueba.DTO;
using System.Reflection;
using AutoMapper;
using System.Text.Json;

namespace apiprueba.Services.Impl
{
    public class EvaluacionServiceImpl : IEvaluacionService
    {
        private readonly ApplicationDbContext context;
        private readonly IModuloPreguntasService moduloPreguntasService;
        private readonly IMapper mapper;

        public EvaluacionServiceImpl(ApplicationDbContext context, IModuloPreguntasService moduloPreguntasService, IMapper mapper)
        {
            this.context = context;
            this.moduloPreguntasService = moduloPreguntasService;
            this.mapper = mapper;
        }

        async Task<byte[]> IEvaluacionService.exportarEvaluaciones(List<string> estados)
        {
            try
            {
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
                    worksheet.Cells[1, 5].Value = "Fecha de evaluacion";
                    worksheet.Cells[1, 6].Value = "Calificacion Final";
                    worksheet.Cells[1, 7].Value = "Estado";

                    int row = 2; // Fila donde comenzar a agregar datos

                    HashSet<string> nombresCeldasCreadas = new HashSet<string>(); // Para rastrear los nombres de las celdas creadas

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

                            var preguntaModuloResult = await moduloPreguntasService.ObtenerModulosConPreguntas(colaborador.Cargo_Id);

                            //var preguntaModuloResult = preguntaModuloResultTask.Result;

                            if (preguntaModuloResult != null)
                            {
                                int currentColumn = 8; // Inicializar en la columna 8

                                foreach (var moduloPregunta in preguntaModuloResult)
                                {
                                    if (moduloPregunta.PreguntasByEvaluacionModel != null && moduloPregunta.PreguntasByEvaluacionModel.Count > 0)
                                    {
                                        var preguntaByEvaluacion = moduloPregunta.PreguntasByEvaluacionModel[0];

                                        var pregunta = preguntaByEvaluacion.Pregunta;
                                        var numeroPregunta = preguntaByEvaluacion.Numero_Pregunta;

                                        string propertyName = $"Clfc_Pregunta{numeroPregunta}";

                                        // Se utiliza reflexión para acceder a la propiedad de evaluación
                                        var propertyInfo = evaluacion.GetType().GetProperty(propertyName);
                                        if (propertyInfo != null)
                                        {
                                            var propertyValue = propertyInfo.GetValue(evaluacion);
                                            if (moduloPregunta.Nombre_Modulo == "Orientación al Servicio")
                                            {
                                                string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                //Verifica si el nombre de la celda ya está en el conjunto
                                                if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                {
                                                    worksheet.Cells[1, 8].Value = nombreCelda;
                                                    nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                }

                                                worksheet.Cells[row, 8].Value = propertyValue;

                                            }
                                            else if (moduloPregunta.Nombre_Modulo == "Trabajo en Equipo")
                                            {
                                                string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                //Verifica si el nombre de la celda ya está en el conjunto
                                                if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                {
                                                    worksheet.Cells[1, 9].Value = nombreCelda;
                                                    nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                }

                                                worksheet.Cells[row, 9].Value = propertyValue;

                                            }
                                            else if (moduloPregunta.Nombre_Modulo == "Orientación a los Resultados")
                                            {
                                                string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                //Verifica si el nombre de la celda ya está en el conjunto
                                                if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                {
                                                    worksheet.Cells[1, 10].Value = nombreCelda;
                                                    nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                }

                                                worksheet.Cells[row, 10].Value = propertyValue;

                                            }
                                            else if (moduloPregunta.Nombre_Modulo == "Diversidad e Inclusión")
                                            {
                                                string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                //Verifica si el nombre de la celda ya está en el conjunto
                                                if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                {
                                                    worksheet.Cells[1, 11].Value = nombreCelda;
                                                    nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                }

                                                worksheet.Cells[row, 11].Value = propertyValue;

                                            }
                                            else if (moduloPregunta.Nombre_Modulo == "Pensamiento creativo e innovador")
                                            {
                                                string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                //Verifica si el nombre de la celda ya está en el conjunto
                                                if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                {
                                                    worksheet.Cells[1, 12].Value = nombreCelda;
                                                    nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                }

                                                worksheet.Cells[row, 12].Value = propertyValue;

                                            }
                                            else if (moduloPregunta.Nombre_Modulo == "Liderazgo")
                                            {
                                                string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                //Verifica si el nombre de la celda ya está en el conjunto
                                                if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                {
                                                    worksheet.Cells[1, 13].Value = nombreCelda;
                                                    nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                }

                                                worksheet.Cells[row, 13].Value = propertyValue;

                                            }
                                            else if (moduloPregunta.Nombre_Modulo == "Planificación, seguimiento y control")
                                            {
                                                string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                //Verifica si el nombre de la celda ya está en el conjunto
                                                if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                {
                                                    worksheet.Cells[1, 14].Value = nombreCelda;
                                                    nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                }

                                                worksheet.Cells[row, 14].Value = propertyValue;

                                            }
                                            else if (moduloPregunta.Nombre_Modulo == "Pensamiento crítico para la toma de decisiones")
                                            {
                                                string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                //Verifica si el nombre de la celda ya está en el conjunto
                                                if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                {
                                                    worksheet.Cells[1, 15].Value = nombreCelda;
                                                    nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                }

                                                worksheet.Cells[row, 15].Value = propertyValue;

                                            }
                                            else if (moduloPregunta.Nombre_Modulo == "Responsabilidad")
                                            {
                                                string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                //Verifica si el nombre de la celda ya está en el conjunto
                                                if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                {
                                                    worksheet.Cells[1, 16].Value = nombreCelda;
                                                    nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                }

                                                worksheet.Cells[row, 16].Value = propertyValue;

                                            }
                                            else if (moduloPregunta.Nombre_Modulo == "Pensamiento Analítico")
                                            {
                                                string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                //Verifica si el nombre de la celda ya está en el conjunto
                                                if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                {
                                                    worksheet.Cells[1, 17].Value = nombreCelda;
                                                    nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                }

                                                worksheet.Cells[row, 17].Value = propertyValue;

                                            }
                                            else if (moduloPregunta.Nombre_Modulo == "Organización del trabajo") //FALTA
                                            {
                                                string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                //Verifica si el nombre de la celda ya está en el conjunto
                                                if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                {
                                                    worksheet.Cells[1, 18].Value = nombreCelda;
                                                    nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                }

                                                worksheet.Cells[row, 18].Value = propertyValue;

                                            }
                                            else if (moduloPregunta.Nombre_Modulo == "Instrucción y Entrenamiento")
                                            {
                                                string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                //Verifica si el nombre de la celda ya está en el conjunto
                                                if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                {
                                                    worksheet.Cells[1, 19].Value = nombreCelda;
                                                    nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                }

                                                worksheet.Cells[row, 19].Value = propertyValue;

                                            }
                                            else if (moduloPregunta.Nombre_Modulo == "Asesoría y ventas")
                                            {
                                                string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                //Verifica si el nombre de la celda ya está en el conjunto
                                                if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                {
                                                    worksheet.Cells[1, 20].Value = nombreCelda;
                                                    nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                }

                                                worksheet.Cells[row, 20].Value = propertyValue;

                                            }
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
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el archivo Excel.", ex);
            }

        
        }

        async Task<byte[]> IEvaluacionService.exportarEvaluacionesAcumulado(List<string> estados)
        {
            try
            {
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

                        //Contadores de las veces que ingresa por competencia en todas las evaluaciones
                        int contCompetencia1 = 0;
                        int contCompetencia2 = 0;
                        int contCompetencia3 = 0;
                        int contCompetencia4 = 0;
                        int contCompetencia5 = 0;
                        int contCompetencia6 = 0;
                        int contCompetencia7 = 0;
                        int contCompetencia8 = 0;
                        int contCompetencia9 = 0;
                        int contCompetencia10 = 0;
                        int contCompetencia11 = 0;
                        int contCompetencia12 = 0;
                        int contCompetencia13 = 0;

                        //Contadores para los grupos segun el cargo del colaborador
                        //No se considera grupo1 ya que solo sera evaluado por un solo jefe y no varios 

                        int contGrupo2 = 0;
                        int contGrupo3 = 0;

                        //Acumulado o suma de todos los grupos por las evaluaciones del colaborador
                        decimal? grupo1 = 0;
                        decimal? grupo2 = 0;
                        decimal? grupo3 = 0;

                        //Acumulado o suma de todas las evaluaciones del colaborador respecto a una competencia especifica
                        decimal competencia1 = 0;
                        decimal competencia2 = 0;
                        decimal competencia3 = 0;
                        decimal competencia4 = 0;
                        decimal competencia5 = 0;
                        decimal competencia6 = 0;
                        decimal competencia7 = 0;
                        decimal competencia8 = 0;
                        decimal competencia9 = 0;
                        decimal competencia10 = 0;
                        decimal competencia11 = 0;
                        decimal competencia12 = 0;
                        decimal competencia13 = 0;

                        decimal porcentajeGrupo = 0M;

                        var flagCargo = "";

                        //decimal acumJefe = 0;
                        //decimal acumCliente = 0;
                        //decimal acumEquipo = 0;

                        decimal puntajeMax = 0;

                        HashSet<string> nombresCeldasCreadas = new HashSet<string>(); // Para rastrear los nombres de las celdas creadas

                        foreach (var evaluacion in evaluacionesDelColaborador)
                        {
                            var colaborador = await context.Colaborador.FirstOrDefaultAsync(u => u.Id_Colaborador == evaluacion.Colaborador_id);
                            var cargo = await context.Cargos.FirstOrDefaultAsync(u => u.Id_Cargo == colaborador.Cargo_Id);

                            if (cargo != null && colaborador != null)
                            {
                                if (cargo.Nombre_Cargo == "Jefaturas")
                                {
                                    flagCargo = "JF";
                                    if (colaborador.Grupo == "JEFE")
                                    {
                                        porcentajeGrupo = 0.40M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;//ej 5*40% = 2
                                                                                                                        //decimal? valorMaximo = 5;

                                        //decimal? porcentajeOriginal = (valorResultante / valorMaximo) * 100;

                                        //Console.WriteLine($"Valor Resultante: {valorResultante} => Porcentaje Original: {porcentajeOriginal}%");
                                        //valorResultante += valorCalificacion;


                                        grupo1 = valorCalificacion;
                                        puntajeMax += 5 * porcentajeGrupo;

                                        // worksheet.Cells[row, 3].Value = valorCalificacion;
                                    }

                                    if (colaborador.Grupo == "CLIENTE")
                                    {
                                        porcentajeGrupo = 0.40M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;//ej 5*40% = 2
                                        //valorResultante += valorCalificacion;


                                        grupo2 += valorCalificacion;
                                        puntajeMax += 5 * porcentajeGrupo;
                                        contGrupo2++;

                                        // worksheet.Cells[row, 4].Value = valorCalificacion;
                                    }

                                    if (colaborador.Grupo == "EQUIPO")
                                    {
                                        porcentajeGrupo = 0.20M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;//ej 5*40% = 2
                                        //valorResultante += valorCalificacion;

                                        grupo3 += valorCalificacion;
                                        puntajeMax += 5 * porcentajeGrupo;
                                        contGrupo3++;
                                        // worksheet.Cells[row, 5].Value = valorCalificacion;
                                    }
                                }

                                else if (cargo.Nombre_Cargo == "Supervisores")
                                {
                                    flagCargo = "SP";
                                    if (colaborador.Grupo == "JEFE")
                                    {
                                        porcentajeGrupo = 0.50M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;
                                        //valorResultante += valorCalificacion;

                                        grupo1 = valorCalificacion;
                                        puntajeMax += 5 * porcentajeGrupo;
                                        //worksheet.Cells[row, 3].Value = valorCalificacion;
                                    }
                                    if (colaborador.Grupo == "CLIENTE")
                                    {
                                        porcentajeGrupo = 0.25M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;//ej 5*40% = 2
                                        //valorResultante += valorCalificacion;

                                        grupo2 += valorCalificacion;
                                        puntajeMax += 5 * porcentajeGrupo;
                                        contGrupo2++;
                                        //worksheet.Cells[row, 5].Value = valorCalificacion;
                                    }

                                    if (colaborador.Grupo == "EQUIPO")
                                    {
                                        porcentajeGrupo = 0.25M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;//ej 5*40% = 2
                                        //valorResultante += valorCalificacion;

                                        grupo3 += valorCalificacion;
                                        puntajeMax += 5 * porcentajeGrupo;
                                        contGrupo3++;
                                        //worksheet.Cells[row, 5].Value = valorCalificacion;
                                    }
                                }

                                else if (cargo.Nombre_Cargo == "Gestor")
                                {
                                    flagCargo = "GT";
                                    if (colaborador.Grupo == "JEFE")
                                    {
                                        porcentajeGrupo = 0.60M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;
                                        //valorResultante += valorCalificacion;

                                        grupo1 = valorCalificacion;
                                        puntajeMax += 5 * porcentajeGrupo;
                                        //worksheet.Cells[row, 3].Value = valorCalificacion;
                                    }

                                    if (colaborador.Grupo == "EQUIPO")
                                    {
                                        porcentajeGrupo = 0.40M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;//ej 5*40% = 2
                                        //valorResultante += valorCalificacion;

                                        grupo3 += valorCalificacion;
                                        puntajeMax += 5 * porcentajeGrupo;
                                        contGrupo3++;
                                        //worksheet.Cells[row, 5].Value = valorCalificacion;
                                    }
                                }

                                else if (cargo.Nombre_Cargo == "Coordinador")
                                {
                                    flagCargo = "CD";
                                    if (colaborador.Grupo == "JEFE")
                                    {
                                        porcentajeGrupo = 0.60M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;
                                        //valorResultante += valorCalificacion;

                                        grupo1 = valorCalificacion;
                                        puntajeMax += 5 * porcentajeGrupo;
                                        // worksheet.Cells[row, 3].Value = valorCalificacion;
                                    }

                                    if (colaborador.Grupo == "CLIENTE")
                                    {
                                        porcentajeGrupo = 0.40M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;//ej 5*40% = 2
                                        //valorResultante += valorCalificacion;

                                        grupo2 += valorCalificacion;
                                        puntajeMax += 5 * porcentajeGrupo;
                                        contGrupo2++;
                                        //worksheet.Cells[row, 4].Value = valorCalificacion;
                                    }
                                }

                                else if (cargo.Nombre_Cargo == "Analista" || cargo.Nombre_Cargo == "Vendedor" || cargo.Nombre_Cargo == "Auxiliar")
                                {
                                    flagCargo = "AV";
                                    if (colaborador.Grupo == "JEFE")
                                    {
                                        porcentajeGrupo = 1.00M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;
                                        //valorResultante += valorCalificacion;

                                        grupo1 = valorCalificacion;
                                        puntajeMax += 5 * porcentajeGrupo;
                                        //worksheet.Cells[row, 3].Value = valorCalificacion;
                                    }
                                }

                                else if (cargo.Nombre_Cargo == "Administrador")
                                {
                                    flagCargo = "AD";
                                    if (colaborador.Grupo == "JEFE")
                                    {
                                        porcentajeGrupo = 0.50M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;
                                        //valorResultante += valorCalificacion;

                                        grupo1 = valorCalificacion;
                                        puntajeMax += 5 * porcentajeGrupo;
                                        //worksheet.Cells[row, 3].Value = valorCalificacion;
                                    }

                                    if (colaborador.Grupo == "EQUIPO")
                                    {
                                        porcentajeGrupo = 0.50M;
                                        decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;//ej 5*40% = 2
                                        //valorResultante += valorCalificacion;


                                        grupo3 += valorCalificacion;
                                        puntajeMax += 5 * porcentajeGrupo;
                                        contGrupo3++;
                                        //worksheet.Cells[row, 5].Value = valorCalificacion;
                                    }
                                }

                                //string usuarioNombre = usuario.Usuario;
                                var preguntaModuloResult = await moduloPreguntasService.ObtenerModulosConPreguntas(colaborador.Cargo_Id);

                                //int currentColumn = 7; // Inicializar en la columna 7

                                if (preguntaModuloResult != null)
                                {
                                    foreach (var moduloPregunta in preguntaModuloResult)
                                    {
                                        if (moduloPregunta.PreguntasByEvaluacionModel != null && moduloPregunta.PreguntasByEvaluacionModel.Count > 0)
                                        {
                                            var preguntaByEvaluacion = moduloPregunta.PreguntasByEvaluacionModel[0];

                                            var pregunta = preguntaByEvaluacion.Pregunta;
                                            var numeroPregunta = preguntaByEvaluacion.Numero_Pregunta;

                                            //var clfFinal = evaluacion.CalificacionFinal;

                                            string propertyName = $"Clfc_Pregunta{numeroPregunta}";

                                            // Se utiliza reflexión para acceder a la propiedad de evaluación
                                            var propertyInfo = evaluacion.GetType().GetProperty(propertyName);
                                            if (propertyInfo != null)
                                            {
                                                //Se obtiene la calificacion de la competencia o pregunta de la evaluacion de manera individual
                                                var propertyValue = propertyInfo.GetValue(evaluacion);
                                                if (moduloPregunta.Nombre_Modulo == "Orientación al Servicio")
                                                {
                                                    //worksheet.Cells[1, 7].Value = moduloPregunta.Nombre_Modulo;

                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        worksheet.Cells[1, 7].Value = nombreCelda;
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    decimal valueConGrupo = (decimal)propertyValue * porcentajeGrupo;
                                                    valueConGrupo = Math.Round(valueConGrupo, 2);
                                                    competencia1 += valueConGrupo;
                                                    contCompetencia1++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Trabajo en Equipo")
                                                {
                                                    //worksheet.Cells[1, 8].Value = moduloPregunta.Nombre_Modulo;

                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        worksheet.Cells[1, 8].Value = nombreCelda;
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    decimal valueConGrupo = (decimal)propertyValue * porcentajeGrupo;
                                                    valueConGrupo = Math.Round(valueConGrupo, 2);
                                                    competencia2 += valueConGrupo;
                                                    contCompetencia2++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Orientación a los Resultados")
                                                {
                                                    //worksheet.Cells[1, 9].Value = moduloPregunta.Nombre_Modulo;

                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        worksheet.Cells[1, 9].Value = nombreCelda;
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    decimal valueConGrupo = (decimal)propertyValue * porcentajeGrupo;
                                                    valueConGrupo = Math.Round(valueConGrupo, 2);
                                                    competencia3 += valueConGrupo;
                                                    contCompetencia3++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Diversidad e Inclusión")
                                                {
                                                    //worksheet.Cells[1, 10].Value = moduloPregunta.Nombre_Modulo;

                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        worksheet.Cells[1, 10].Value = nombreCelda;
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    decimal valueConGrupo = (decimal)propertyValue * porcentajeGrupo;
                                                    valueConGrupo = Math.Round(valueConGrupo, 2);
                                                    competencia4 += valueConGrupo;
                                                    contCompetencia4++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Pensamiento creativo e innovador")
                                                {
                                                    //worksheet.Cells[1, 11].Value = moduloPregunta.Nombre_Modulo;

                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        worksheet.Cells[1, 11].Value = nombreCelda;
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    decimal valueConGrupo = (decimal)propertyValue * porcentajeGrupo;
                                                    valueConGrupo = Math.Round(valueConGrupo, 2);
                                                    competencia5 += valueConGrupo;
                                                    contCompetencia5++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Liderazgo")
                                                {
                                                    //worksheet.Cells[1, 12].Value = moduloPregunta.Nombre_Modulo;

                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        worksheet.Cells[1, 12].Value = nombreCelda;
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    decimal valueConGrupo = (decimal)propertyValue * porcentajeGrupo;
                                                    valueConGrupo = Math.Round(valueConGrupo, 2);
                                                    competencia6 += valueConGrupo;
                                                    contCompetencia6++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Planificación, seguimiento y control")
                                                {
                                                    //worksheet.Cells[1, 13].Value = moduloPregunta.Nombre_Modulo;

                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        worksheet.Cells[1, 13].Value = nombreCelda;
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    decimal valueConGrupo = (decimal)propertyValue * porcentajeGrupo;
                                                    valueConGrupo = Math.Round(valueConGrupo, 2);
                                                    competencia7 += valueConGrupo;
                                                    contCompetencia7++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Pensamiento crítico para la toma de decisiones")
                                                {
                                                    //worksheet.Cells[1, 14].Value = moduloPregunta.Nombre_Modulo;

                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        worksheet.Cells[1, 14].Value = nombreCelda;
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    decimal valueConGrupo = (decimal)propertyValue * porcentajeGrupo;
                                                    valueConGrupo = Math.Round(valueConGrupo, 2);
                                                    competencia8 += valueConGrupo;
                                                    contCompetencia8++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Responsabilidad")
                                                {
                                                    //worksheet.Cells[1, 15].Value = moduloPregunta.Nombre_Modulo;

                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        worksheet.Cells[1, 15].Value = nombreCelda;
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    decimal valueConGrupo = (decimal)propertyValue * porcentajeGrupo;
                                                    valueConGrupo = Math.Round(valueConGrupo, 2);
                                                    competencia9 += valueConGrupo;
                                                    contCompetencia9++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Pensamiento Analítico")
                                                {
                                                    //worksheet.Cells[1, 16].Value = moduloPregunta.Nombre_Modulo;

                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        worksheet.Cells[1, 16].Value = nombreCelda;
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    decimal valueConGrupo = (decimal)propertyValue * porcentajeGrupo;
                                                    valueConGrupo = Math.Round(valueConGrupo, 2);
                                                    competencia10 += valueConGrupo;
                                                    contCompetencia10++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Organización del trabajo") //FALTA
                                                {
                                                    //worksheet.Cells[1, 17].Value = moduloPregunta.Nombre_Modulo;

                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        worksheet.Cells[1, 17].Value = nombreCelda;
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    decimal valueConGrupo = (decimal)propertyValue * porcentajeGrupo;
                                                    valueConGrupo = Math.Round(valueConGrupo, 2);
                                                    competencia11 += valueConGrupo;
                                                    contCompetencia11++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Instrucción y Entrenamiento")
                                                {
                                                    //worksheet.Cells[1, 18].Value = moduloPregunta.Nombre_Modulo;

                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        worksheet.Cells[1, 18].Value = nombreCelda;
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    decimal valueConGrupo = (decimal)propertyValue * porcentajeGrupo;
                                                    valueConGrupo = Math.Round(valueConGrupo, 2);
                                                    competencia12 += valueConGrupo;
                                                    contCompetencia12++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Asesoría y ventas")
                                                {
                                                    //worksheet.Cells[1, 19].Value = moduloPregunta.Nombre_Modulo;

                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        worksheet.Cells[1, 19].Value = nombreCelda;
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    decimal valueConGrupo = (decimal)propertyValue * porcentajeGrupo;
                                                    valueConGrupo = Math.Round(valueConGrupo, 2);
                                                    competencia13 += valueConGrupo;
                                                    contCompetencia13++;
                                                }
                                                //var propertyValue = propertyInfo.GetValue(evaluacion);
                                            }
                                            //row++;
                                            //currentColumn++;
                                        }



                                    }


                                }

                            }
                        }


                        if (competencia1 != 0 && contCompetencia1 != 0)
                        {
                            //decimal puntajeMax = valorMaxByCargo * contCompetencia1;
                            decimal division = competencia1 / puntajeMax;
                            decimal porcentaje = division * 100;
                            decimal porcentajeRedondeado = Math.Round(porcentaje, 2); // Redondear a dos decimales
                            worksheet.Cells[row, 7].Value = porcentajeRedondeado.ToString() + "%";
                        }

                        if (competencia2 != 0 && contCompetencia2 != 0)
                        {
                            //decimal acumulado2 = competencia2 / contCompetencia2 / 5; //se divide para 5 ya que es la calificacion maxima
                            //decimal puntajeMax = valorMaxByCargo * contCompetencia2;
                            decimal division = competencia2 / puntajeMax;
                            decimal porcentaje = division * 100;
                            //int porcentajeEntero = (int)Math.Floor(porcentaje); // Redondear hacia abajo
                            decimal porcentajeRedondeado = Math.Round(porcentaje, 2); // Redondear a dos decimales
                            worksheet.Cells[row, 8].Value = porcentajeRedondeado.ToString() + "%";
                        }


                        if (competencia3 != 0 && contCompetencia3 != 0)
                        {
                            //decimal acumulado3 = (competencia3 / contCompetencia3) / 5; //se divide para 5 ya que es la calificacion maxima
                            //decimal puntajeMax = valorMaxByCargo * contCompetencia3;
                            decimal division = competencia3 / puntajeMax;
                            decimal porcentaje = division * 100;
                            decimal porcentajeRedondeado = Math.Round(porcentaje, 2); // Redondear a dos decimales
                            worksheet.Cells[row, 9].Value = porcentajeRedondeado.ToString() + "%";
                        }

                        if (competencia4 != 0 && contCompetencia3 != 0)
                        {
                            //decimal acumulado4 = (competencia4 / contCompetencia4) / 5; //se divide para 5 ya que es la calificacion maxima
                            //decimal puntajeMax = valorMaxByCargo * contCompetencia4;
                            decimal division = competencia4 / puntajeMax;
                            decimal porcentaje = division * 100;
                            decimal porcentajeRedondeado = Math.Round(porcentaje, 2); // Redondear a dos decimales
                            worksheet.Cells[row, 10].Value = porcentajeRedondeado.ToString() + "%";
                        }

                        if (competencia5 != 0 && contCompetencia5 != 0)
                        {
                            //decimal acumulado5 = (competencia5 / contCompetencia5) / 5; //se divide para 5 ya que es la calificacion maxima
                            //decimal puntajeMax = valorMaxByCargo * contCompetencia5;
                            decimal division = competencia5 / puntajeMax;
                            decimal porcentaje = division * 100;
                            decimal porcentajeRedondeado = Math.Round(porcentaje, 2); // Redondear a dos decimales
                            worksheet.Cells[row, 11].Value = porcentajeRedondeado.ToString() + "%";
                        }

                        if (competencia6 != 0 && contCompetencia6 != 0)
                        {
                            //decimal acumulado6 = (competencia6 / contCompetencia6) / 5; //se divide para 5 ya que es la calificacion maxima
                            //decimal puntajeMax = valorMaxByCargo * contCompetencia6;
                            decimal division = competencia6 / puntajeMax;
                            decimal porcentaje = division * 100;
                            decimal porcentajeRedondeado = Math.Round(porcentaje, 2); // Redondear a dos decimales
                            worksheet.Cells[row, 12].Value = porcentajeRedondeado.ToString() + "%";
                        }

                        if (competencia7 != 0 && contCompetencia7 != 0)
                        {
                            //decimal acumulado7 = (competencia7 / contCompetencia7) / 5; //se divide para 5 ya que es la calificacion maxima
                            //decimal puntajeMax = valorMaxByCargo * contCompetencia7;
                            decimal division = competencia7 / puntajeMax;
                            decimal porcentaje = division * 100;
                            decimal porcentajeRedondeado = Math.Round(porcentaje, 2); // Redondear a dos decimales
                            worksheet.Cells[row, 13].Value = porcentajeRedondeado.ToString() + "%";
                        }

                        if (competencia8 != 0 && contCompetencia8 != 0)
                        {
                            //decimal acumulado8 = (competencia8 / contCompetencia8) / 5; //se divide para 5 ya que es la calificacion maxima
                            //decimal puntajeMax = valorMaxByCargo * contCompetencia8;
                            decimal division = competencia8 / puntajeMax;
                            decimal porcentaje = division * 100;
                            decimal porcentajeRedondeado = Math.Round(porcentaje, 2); // Redondear a dos decimales
                            worksheet.Cells[row, 14].Value = porcentajeRedondeado.ToString() + "%";
                        }

                        if (competencia9 != 0 && contCompetencia9 != 0)
                        {
                            //decimal acumulado9 = (competencia9 / contCompetencia9) / 5; //se divide para 5 ya que es la calificacion maxima
                            //decimal puntajeMax = valorMaxByCargo * contCompetencia9;
                            decimal division = competencia9 / puntajeMax;
                            decimal porcentaje = division * 100;
                            decimal porcentajeRedondeado = Math.Round(porcentaje, 2); // Redondear a dos decimales
                            worksheet.Cells[row, 15].Value = porcentajeRedondeado.ToString() + "%";
                        }

                        if (competencia10 != 0 && contCompetencia10 != 0)
                        {
                            //decimal acumulado10 = (competencia10 / contCompetencia10) / 5; //se divide para 5 ya que es la calificacion maxima
                            //decimal puntajeMax = valorMaxByCargo * contCompetencia10;
                            decimal division = competencia10 / puntajeMax;
                            decimal porcentaje = division * 100;
                            decimal porcentajeRedondeado = Math.Round(porcentaje, 2); // Redondear a dos decimales
                            worksheet.Cells[row, 16].Value = porcentajeRedondeado.ToString() + "%";
                        }

                        if (competencia11 != 0 && contCompetencia11 != 0)
                        {
                            //decimal acumulado11 = (competencia11 / contCompetencia11) / 5; //se divide para 5 ya que es la calificacion maxima
                            //decimal puntajeMax = valorMaxByCargo * contCompetencia11;
                            decimal division = competencia11 / puntajeMax;
                            decimal porcentaje = division * 100;
                            decimal porcentajeRedondeado = Math.Round(porcentaje, 2); // Redondear a dos decimales
                            worksheet.Cells[row, 17].Value = porcentajeRedondeado.ToString() + "%";
                        }

                        if (competencia12 != 0 && contCompetencia12 != 0)
                        {
                            //decimal acumulado12 = (competencia12 / contCompetencia12) / 5; //se divide para 5 ya que es la calificacion maxima
                            //decimal puntajeMax = valorMaxByCargo * contCompetencia12;
                            decimal division = competencia12 / puntajeMax;
                            decimal porcentaje = division * 100;
                            decimal porcentajeRedondeado = Math.Round(porcentaje, 2); // Redondear a dos decimales
                            worksheet.Cells[row, 18].Value = porcentajeRedondeado.ToString() + "%";
                        }

                        if (competencia13 != 0 && contCompetencia13 != 0)
                        {
                            //decimal acumulado13 = (competencia3 / contCompetencia13) / 5; //se divide para 5 ya que es la calificacion maxima
                            //decimal puntajeMax = valorMaxByCargo * contCompetencia13;
                            decimal division = competencia13 / puntajeMax;
                            decimal porcentaje = division * 100;
                            decimal porcentajeRedondeado = Math.Round(porcentaje, 2); // Redondear a dos decimales
                            worksheet.Cells[row, 19].Value = porcentajeRedondeado.ToString() + "%";
                        }

                        decimal? calificacionFinalRoles = 0;

                        if (grupo1 != 0)
                        {
                            decimal valorCalificacion = grupo1.Value;
                            decimal porcentajeRedondeado = Math.Round((valorCalificacion * 100), 2); // Redondear a dos decimales
                            //decimal? valorEntero = valorCalificacion * 100;
                            //decimal? porcentajeRedondeado = Math.Round(valorEntero, 2); // Redondear a dos decimales
                            calificacionFinalRoles += valorCalificacion;
                            worksheet.Cells[row, 3].Value = porcentajeRedondeado.ToString() + "%";
                        }

                        if (grupo2 != 0)
                        {
                            decimal valorCalificacion = grupo2.Value / contGrupo2;
                            decimal porcentajeRedondeado = Math.Round((valorCalificacion * 100), 2); // Redondear a dos decimales
                            calificacionFinalRoles += valorCalificacion;
                            worksheet.Cells[row, 4].Value = porcentajeRedondeado.ToString() + "%";
                        }

                        if (grupo3 != 0)
                        {
                            decimal valorCalificacion = grupo3.Value / contGrupo3;
                            decimal porcentajeRedondeado = Math.Round((valorCalificacion * 100), 2); // Redondear a dos decimales
                            calificacionFinalRoles += valorCalificacion;
                            worksheet.Cells[row, 5].Value = porcentajeRedondeado.ToString() + "%";
                        }

                        calificacionFinal = calificacionFinalRoles.Value;
                        decimal porcentajeFinalRedondeado = Math.Round((calificacionFinal.Value * 100), 2);
                        worksheet.Cells[row, 6].Value = porcentajeFinalRedondeado.ToString() + "%";

                        row++;
                    }

                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    byte[] result = package.GetAsByteArray();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el archivo Excel.", ex);
            }
        }

        /*
            autor: Daniel Males
            since: 03-10-2023
            Se define nueva funcion que devolvera la actualizacion de la evaluacion y observacion
        */
        async Task<object> IEvaluacionService.actualizarEvaluacion(EvaluacionModel evaluacionBD, ObservacionModel observacionBD, EvaluacionObservacionPut evaluacionObservacionPut)
        {
            try
            {
                var evaluacionDtoPut = evaluacionObservacionPut.evaluacionDtoPut;
                var observacionDtoPut = evaluacionObservacionPut.observacionDtoPut;
                decimal competenciaOrganizacional = 0M;
                decimal competenciaEstrategica = 0M;
                decimal competenciaFuncional = 0M;
                var cargoColaborador = "";

                var usuarioExist = await context.Usuarios.FirstOrDefaultAsync(u => u.Id_Usuario == evaluacionBD.Usuario_id);
                var colaboradorExist = await context.Colaborador.FirstOrDefaultAsync(u => u.Id_Colaborador == evaluacionBD.Colaborador_id);

                if (colaboradorExist != null)
                {
                    var cargo = await context.Cargos.FirstOrDefaultAsync(x => x.Id_Cargo == colaboradorExist.Cargo_Id);

                    if (cargo != null)
                    {
                        if (cargo.Nombre_Cargo == "Jefaturas")
                        {
                            cargoColaborador = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaEstrategica = 0.50M;
                            competenciaFuncional = 0.30M;
                        }
                        else if (cargo.Nombre_Cargo == "Supervisores")
                        {
                            cargoColaborador = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaEstrategica = 0.40M;
                            competenciaFuncional = 0.40M;
                        }
                        else if (cargo.Nombre_Cargo == "Coordinador")
                        {
                            cargoColaborador = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaEstrategica = 0.30M;
                            competenciaFuncional = 0.50M;
                        }
                        else if (cargo.Nombre_Cargo == "Gestor")
                        {
                            cargoColaborador = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaEstrategica = 0.20M;
                            competenciaFuncional = 0.60M;
                        }
                        else if (cargo.Nombre_Cargo == "Analista")
                        {
                            cargoColaborador = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaFuncional = 0.80M;
                        }
                        else if (cargo.Nombre_Cargo == "Administrador")
                        {
                            cargoColaborador = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaEstrategica = 0.10M;
                            competenciaFuncional = 0.70M;
                        }
                        else if (cargo.Nombre_Cargo == "Vendedor")
                        {
                            cargoColaborador = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaFuncional = 0.80M;
                        }
                        else if (cargo.Nombre_Cargo == "Auxiliar")
                        {
                            cargoColaborador = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaFuncional = 0.80M;
                        }
                    }

                }

                decimal? sumaClfcPregunta = 0;
                decimal? primerCompetencia = 0M;
                decimal? segundaCompetencia = 0M;
                decimal? terceraCompetencia = 0M;

                var preguntasCargo = await context.PreguntasModuloCargo
                                                .Where(x => x.Cargo_Id == colaboradorExist.Cargo_Id)
                                                .ToListAsync();

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

                foreach (var preguntas in preguntasCargo)
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
                            PropertyInfo propertyInfo = typeof(EvaluacionPutDto).GetProperty(propertyName);


                            if (propertyInfo != null)
                            {
                                decimal? value = (decimal?)propertyInfo.GetValue(evaluacionDtoPut);

                                Console.WriteLine($"Pregunta {pregunta.Numero_Pregunta}: {value}");


                                if (modulo != null && value != null)
                                {
                                    var tipoCompetencia = await context.TipoCompetencia.FirstOrDefaultAsync(x => x.Id_Tipo_Competencia == modulo.Tipo_Competencia_Id);
                                    if (tipoCompetencia != null)
                                    {
                                        if (tipoCompetencia.Nombre == "COMPETENCIAS ORGANIZACIONALES")
                                        {

                                            if (cargoColaborador == "Jefaturas")
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

                                            else if (cargoColaborador == "Supervisores")
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

                                            else if (cargoColaborador == "Coordinador")
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

                                            else if (cargoColaborador == "Gestor")
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

                                            else if (cargoColaborador == "Analista")
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

                                            else if (cargoColaborador == "Administrador")
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

                                            else if (cargoColaborador == "Vendedor" || cargoColaborador == "Auxiliar")
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
                                            if (cargoColaborador == "Jefaturas")
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

                                            else if (cargoColaborador == "Supervisores")
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
                                            else if (cargoColaborador == "Coordinador")
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
                                            else if (cargoColaborador == "Gestor")
                                            {
                                                if (modulo.Nombre_Modulo == "Planificación, seguimiento y control")
                                                {
                                                    decimal pesoModulo = 1.00M;
                                                    value = value.Value * pesoModulo / 5;
                                                    segundaCompetencia += value;
                                                }
                                            }
                                            else if (cargoColaborador == "Administrador")
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

                                            if (cargoColaborador == "Jefaturas" || cargoColaborador == "Supervisores")
                                            {

                                                if (modulo.Nombre_Modulo == "Pensamiento crítico para la toma de decisiones")
                                                {
                                                    decimal pesoModulo = 1.00M;
                                                    value = value.Value * pesoModulo / 5;
                                                    terceraCompetencia += value;
                                                }
                                            }
                                            else if (cargoColaborador == "Coordinador")
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
                                            else if (cargoColaborador == "Gestor")
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
                                            else if (cargoColaborador == "Analista")
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
                                            else if (cargoColaborador == "Administrador")
                                            {
                                                if (modulo.Nombre_Modulo == "Organización del trabajo")
                                                {
                                                    decimal pesoTrabajo = 0.60M;
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
                                            else if (cargoColaborador == "Vendedor")
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
                                            else if (cargoColaborador == "Auxiliar")
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

                return resultados;
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }

        }

        async Task<object> IEvaluacionService.guardarEvaluacionAndObservacion(EvaluacionObservacionModel evaluacionObservacion)
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
                var cargoColaborador = "";
                observacion.Fecha_Creacion = DateTime.Now;
                evaluacion.Fecha_Creacion = DateTime.Now;


                var usuarioExist = await context.Usuarios.FindAsync(evaluacionDto.Usuario_id);
                if (usuarioExist == null)
                {
                    throw new Exception("El usuario no existe");
                }

                var colaboradorExist = await context.Colaborador.FindAsync(evaluacionDto.Colaborador_id);
                if (colaboradorExist == null)
                {
                    throw new Exception("El colaborador no existe");
                }

                if (evaluacion.Estado == "Borrador")
                {
                    colaboradorExist.Estado = "Borrador";
                }
                else
                {
                    colaboradorExist.Estado = "Evaluado";
                }

                if (colaboradorExist != null)
                {
                    var cargo = await context.Cargos.FirstOrDefaultAsync(x => x.Id_Cargo == colaboradorExist.Cargo_Id);

                    if (cargo != null)
                    {
                        if (cargo.Nombre_Cargo == "Jefaturas")
                        {
                            cargoColaborador = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaEstrategica = 0.50M;
                            competenciaFuncional = 0.30M;
                        }
                        else if (cargo.Nombre_Cargo == "Supervisores")
                        {
                            cargoColaborador = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaEstrategica = 0.40M;
                            competenciaFuncional = 0.40M;
                        }
                        else if (cargo.Nombre_Cargo == "Coordinador")
                        {
                            cargoColaborador = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaEstrategica = 0.30M;
                            competenciaFuncional = 0.50M;
                        }
                        else if (cargo.Nombre_Cargo == "Gestor")
                        {
                            cargoColaborador = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaEstrategica = 0.20M;
                            competenciaFuncional = 0.60M;
                        }
                        else if (cargo.Nombre_Cargo == "Analista")
                        {
                            cargoColaborador = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaFuncional = 0.80M;
                        }
                        else if (cargo.Nombre_Cargo == "Administrador")
                        {
                            cargoColaborador = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaEstrategica = 0.10M;
                            competenciaFuncional = 0.70M;
                        }
                        else if (cargo.Nombre_Cargo == "Vendedor")
                        {
                            cargoColaborador = cargo.Nombre_Cargo;
                            competenciaOrganizacional = 0.20M;
                            competenciaFuncional = 0.80M;
                        }
                        else if (cargo.Nombre_Cargo == "Auxiliar")
                        {
                            cargoColaborador = cargo.Nombre_Cargo;
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

                var preguntasCargo = await context.PreguntasModuloCargo
                                                .Where(x => x.Cargo_Id == colaboradorExist.Cargo_Id)
                                                .ToListAsync();

                foreach (var preguntas in preguntasCargo)
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


                                if (modulo != null && value != null)
                                {
                                    var tipoCompetencia = await context.TipoCompetencia.FirstOrDefaultAsync(x => x.Id_Tipo_Competencia == modulo.Tipo_Competencia_Id);
                                    if (tipoCompetencia != null)
                                    {
                                        if (tipoCompetencia.Nombre == "COMPETENCIAS ORGANIZACIONALES")
                                        {

                                            if (cargoColaborador == "Jefaturas")
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

                                            else if (cargoColaborador == "Supervisores")
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

                                            else if (cargoColaborador == "Coordinador")
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

                                            else if (cargoColaborador == "Gestor")
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

                                            else if (cargoColaborador == "Analista")
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

                                            else if (cargoColaborador == "Administrador")
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

                                            else if (cargoColaborador == "Vendedor" || cargoColaborador == "Auxiliar")
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
                                            if (cargoColaborador == "Jefaturas")
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

                                            else if (cargoColaborador == "Supervisores")
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
                                            else if (cargoColaborador == "Coordinador")
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
                                            else if (cargoColaborador == "Gestor")
                                            {
                                                if (modulo.Nombre_Modulo == "Planificación, seguimiento y control")
                                                {
                                                    decimal pesoModulo = 1.00M;
                                                    value = value.Value * pesoModulo / 5;
                                                    segundaCompetencia += value;
                                                }
                                            }
                                            else if (cargoColaborador == "Administrador")
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

                                            if (cargoColaborador == "Jefaturas" || cargoColaborador == "Supervisores")
                                            {

                                                if (modulo.Nombre_Modulo == "Pensamiento crítico para la toma de decisiones")
                                                {
                                                    decimal pesoModulo = 1.00M;
                                                    value = value.Value * pesoModulo / 5;
                                                    terceraCompetencia += value;
                                                }
                                            }
                                            else if (cargoColaborador == "Coordinador")
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
                                            else if (cargoColaborador == "Gestor")
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
                                            else if (cargoColaborador == "Analista")
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
                                            else if (cargoColaborador == "Administrador")
                                            {
                                                if (modulo.Nombre_Modulo == "Organización del trabajo")
                                                {
                                                    decimal pesoTrabajo = 0.60M;
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
                                            else if (cargoColaborador == "Vendedor")
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
                                            else if (cargoColaborador == "Auxiliar")
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

                return resultados;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        /*
            autor: Daniel Males
            since: 08-10-2023
            Funcion que obtiene los promedios de cada competencia
        */
        async Task<object> IEvaluacionService.obtenerPromedioCompetencias(string? cedulaColaborador)
        {
            try
            {
                var evaluaciones = await context.Evaluacion.ToListAsync();

                if (cedulaColaborador != "")
                {
                    evaluaciones.Clear(); // Borra todas las evaluaciones existentes

                    var colaboradoresPrueba = await context.Colaborador.Where(colaborador => colaborador.Cedula == cedulaColaborador).ToListAsync();

                    foreach(var colaborador in colaboradoresPrueba)
                    {
                        var colaboradorEvaluacion = await context.Evaluacion.Where(evaluacion => evaluacion.Colaborador_id == colaborador.Id_Colaborador).ToListAsync();
                        // Agrega cada evaluación individualmente a la lista
                        evaluaciones.AddRange(colaboradorEvaluacion);
                    }
                }

                HashSet<string> nombresCeldasCreadas = new HashSet<string>(); // Para rastrear los nombres de las celdas creadas

                //Acumulado para las calificaciones de todas las competencias
                decimal clfCompetencia1 = 0;
                decimal clfCompetencia2 = 0;
                decimal clfCompetencia3 = 0;
                decimal clfCompetencia4 = 0;
                decimal clfCompetencia5 = 0;
                decimal clfCompetencia6 = 0;
                decimal clfCompetencia7 = 0;
                decimal clfCompetencia8 = 0;
                decimal clfCompetencia9 = 0;
                decimal clfCompetencia10 = 0;
                decimal clfCompetencia11 = 0;
                decimal clfCompetencia12 = 0;
                decimal clfCompetencia13 = 0;

                //Contadores para todas las competencias
                int contadortCompetencia1 = 0;
                int contadortCompetencia2 = 0;
                int contadortCompetencia3 = 0;
                int contadortCompetencia4 = 0;
                int contadortCompetencia5 = 0;
                int contadortCompetencia6 = 0;
                int contadortCompetencia7 = 0;
                int contadortCompetencia8 = 0;
                int contadortCompetencia9 = 0;
                int contadortCompetencia10 = 0;
                int contadortCompetencia11 = 0;
                int contadortCompetencia12 = 0;
                int contadortCompetencia13 = 0;


                //Acumulado o suma de todos los grupos por las evaluaciones del colaborador
                decimal grupo1 = 0;
                decimal grupo2 = 0;
                decimal grupo3 = 0;

                decimal contGrupo2 = 0;
                decimal contGrupo3 = 0;

                decimal porcentajeGrupo = 0M;

                decimal calificacionFinal = 0;

                var cargoColaborador = "";

                if (evaluaciones.Count > 0)
                {
                    foreach (var evaluacion in evaluaciones)
                    {
                        var colaborador = context.Colaborador
                           .Where(e => e.Id_Colaborador == evaluacion.Colaborador_id)
                           .SingleOrDefault();
                        var cargo = await context.Cargos.FirstOrDefaultAsync(u => u.Id_Cargo == colaborador.Cargo_Id);
                        
                        if (cargo != null && colaborador != null)
                        {
                            cargoColaborador = cargo.Nombre_Cargo;

                            if (cargo.Nombre_Cargo == "Jefaturas")
                            {
                                if (colaborador.Grupo == "JEFE")
                                {
                                    porcentajeGrupo = 0.40M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;

                                    grupo1 = (decimal)valorCalificacion;
                                }

                                if (colaborador.Grupo == "CLIENTE")
                                {
                                    porcentajeGrupo = 0.40M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;

                                    grupo2 += (decimal)valorCalificacion;
                                    contGrupo2++;
                                }

                                if (colaborador.Grupo == "EQUIPO")
                                {
                                    porcentajeGrupo = 0.20M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;
                                    grupo3 += (decimal)valorCalificacion;
                                    contGrupo3++;
                                }
                            }

                            else if (cargo.Nombre_Cargo == "Supervisores")
                            {
                                if (colaborador.Grupo == "JEFE")
                                {
                                    porcentajeGrupo = 0.50M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;

                                    grupo1 = (decimal)valorCalificacion;
                                }
                                if (colaborador.Grupo == "CLIENTE")
                                {
                                    porcentajeGrupo = 0.25M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;
                                    grupo2 += (decimal)valorCalificacion;
                                    contGrupo2++;
                                }

                                if (colaborador.Grupo == "EQUIPO")
                                {
                                    porcentajeGrupo = 0.25M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;
                                    grupo3 += (decimal)valorCalificacion;
                                    contGrupo3++;
                                }
                            }

                            else if (cargo.Nombre_Cargo == "Gestor")
                            {
                                if (colaborador.Grupo == "JEFE")
                                {
                                    porcentajeGrupo = 0.60M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;
                                    grupo1 = (decimal)valorCalificacion;
                                }

                                if (colaborador.Grupo == "EQUIPO")
                                {
                                    porcentajeGrupo = 0.40M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;
                                    grupo3 += (decimal)valorCalificacion;
                                    contGrupo3++;
                                }
                            }

                            else if (cargo.Nombre_Cargo == "Coordinador")
                            {
                                if (colaborador.Grupo == "JEFE")
                                {
                                    porcentajeGrupo = 0.60M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;
                                    grupo1 = (decimal)valorCalificacion;

                                }

                                if (colaborador.Grupo == "CLIENTE")
                                {
                                    porcentajeGrupo = 0.40M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;
                                    grupo2 += (decimal)valorCalificacion;
                                    contGrupo2++;

                                }
                            }

                            else if (cargo.Nombre_Cargo == "Analista" || cargo.Nombre_Cargo == "Vendedor" || cargo.Nombre_Cargo == "Auxiliar")
                            {
                                if (colaborador.Grupo == "JEFE")
                                {
                                    porcentajeGrupo = 1.00M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;

                                    grupo1 = (decimal)valorCalificacion;

                                }
                            }

                            else if (cargo.Nombre_Cargo == "Administrador")
                            {
                                if (colaborador.Grupo == "JEFE")
                                {
                                    porcentajeGrupo = 0.50M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;
                                    grupo1 = (decimal)valorCalificacion;

                                }

                                if (colaborador.Grupo == "EQUIPO")
                                {
                                    porcentajeGrupo = 0.50M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;

                                    grupo3 += (decimal)valorCalificacion;
                                    contGrupo3++;
                                }
                            }

                            if (colaborador != null)
                            {
                                var preguntaModuloResult = await moduloPreguntasService.ObtenerModulosConPreguntas(colaborador.Cargo_Id);

                                if (preguntaModuloResult != null)
                                {
                                    foreach (var moduloPregunta in preguntaModuloResult)
                                    {
                                        if (moduloPregunta.PreguntasByEvaluacionModel != null && moduloPregunta.PreguntasByEvaluacionModel.Count > 0)
                                        {
                                            var preguntaByEvaluacion = moduloPregunta.PreguntasByEvaluacionModel[0];

                                            var numeroPregunta = preguntaByEvaluacion.Numero_Pregunta;

                                            string propertyName = $"Clfc_Pregunta{numeroPregunta}";

                                            // Se utiliza reflexión para acceder a la propiedad de evaluación
                                            var propertyInfo = evaluacion.GetType().GetProperty(propertyName);
                                            if (propertyInfo != null)
                                            {
                                                var propertyValue = propertyInfo.GetValue(evaluacion);
                                                if (moduloPregunta.Nombre_Modulo == "Orientación al Servicio")
                                                {
                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    clfCompetencia1 += (decimal)propertyValue;
                                                    contadortCompetencia1++;

                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Trabajo en Equipo")
                                                {
                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }
                                                    clfCompetencia2 += (decimal)propertyValue;
                                                    contadortCompetencia2++;

                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Orientación a los Resultados")
                                                {
                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    clfCompetencia3 += (decimal)propertyValue;
                                                    contadortCompetencia3++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Diversidad e Inclusión")
                                                {
                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    clfCompetencia4 += (decimal)propertyValue;
                                                    contadortCompetencia4++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Pensamiento creativo e innovador")
                                                {
                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    clfCompetencia5 += (decimal)propertyValue;
                                                    contadortCompetencia5++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Liderazgo")
                                                {
                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    clfCompetencia6 += (decimal)propertyValue;
                                                    contadortCompetencia6++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Planificación, seguimiento y control")
                                                {
                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    clfCompetencia7 += (decimal)propertyValue;
                                                    contadortCompetencia7++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Pensamiento crítico para la toma de decisiones")
                                                {
                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    clfCompetencia8 += (decimal)propertyValue;
                                                    contadortCompetencia8++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Responsabilidad")
                                                {
                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    clfCompetencia9 += (decimal)propertyValue;
                                                    contadortCompetencia9++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Pensamiento Analítico")
                                                {
                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    clfCompetencia10 += (decimal)propertyValue;
                                                    contadortCompetencia10++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Organización del trabajo") //FALTA
                                                {
                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    clfCompetencia11 += (decimal)propertyValue;
                                                    contadortCompetencia11++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Instrucción y Entrenamiento")
                                                {
                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    clfCompetencia12 += (decimal)propertyValue;
                                                    contadortCompetencia12++;
                                                }
                                                else if (moduloPregunta.Nombre_Modulo == "Asesoría y ventas")
                                                {
                                                    string nombreCelda = moduloPregunta.Nombre_Modulo;

                                                    //Verifica si el nombre de la celda ya está en el conjunto
                                                    if (!nombresCeldasCreadas.Contains(nombreCelda))
                                                    {
                                                        nombresCeldasCreadas.Add(nombreCelda); // Agrega el nombre a la lista de nombres creados

                                                    }

                                                    clfCompetencia13 += (decimal)propertyValue;
                                                    contadortCompetencia13++;
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                            else
                            {
                                throw new Exception("No se encontraron evaluaciones");
                            }


                        }
                    }
                }

                decimal calificacionFinalRoles = 0;
                decimal calificacionJefe = 0;
                decimal calificacionCliente = 0;
                decimal calificacionEquipo = 0;

                if (grupo1 != 0)
                {
                    decimal valorCalificacion = grupo1;
                    decimal porcentajeRedondeado = Math.Round((valorCalificacion * 100), 2); // Redondear a dos decimales
                                                                                                //decimal? valorEntero = valorCalificacion * 100;
                                                                                                //decimal? porcentajeRedondeado = Math.Round(valorEntero, 2); // Redondear a dos decimales
                    calificacionFinalRoles += valorCalificacion;
                    calificacionJefe = porcentajeRedondeado;
                }

                if (grupo2 != 0)
                {
                    decimal valorCalificacion = grupo2 / contGrupo2;
                    decimal porcentajeRedondeado = Math.Round((valorCalificacion * 100), 2); // Redondear a dos decimales
                    calificacionFinalRoles += valorCalificacion;
                    calificacionCliente = porcentajeRedondeado;
                }

                if (grupo3 != 0)
                {
                    decimal valorCalificacion = grupo3 / contGrupo3;
                    decimal porcentajeRedondeado = Math.Round((valorCalificacion * 100), 2); // Redondear a dos decimales
                    calificacionFinalRoles += valorCalificacion;
                    calificacionEquipo = porcentajeRedondeado;
                }

                calificacionFinal = calificacionFinalRoles;
                decimal porcentajeFinalRedondeado = Math.Round((calificacionFinal * 100), 2);

                //Calculo de promedios
                var redondeados = new Dictionary<string, object> { };

                // Definir un array de clfCompetencias y contadortCompetencias
                decimal[] clfCompetencias = { clfCompetencia1, clfCompetencia2, clfCompetencia3, clfCompetencia4, clfCompetencia5, clfCompetencia6, clfCompetencia7, clfCompetencia8, clfCompetencia9, clfCompetencia10, clfCompetencia11, clfCompetencia12, clfCompetencia13 };
                int[] contadortCompetencias = { contadortCompetencia1, contadortCompetencia2, contadortCompetencia3, contadortCompetencia4, contadortCompetencia5, contadortCompetencia6, contadortCompetencia7, contadortCompetencia8, contadortCompetencia9, contadortCompetencia10, contadortCompetencia11, contadortCompetencia12, contadortCompetencia13 };

                for (int i = 0; i < clfCompetencias.Length; i++)
                {
                    if (clfCompetencias[i] > 0 && contadortCompetencias[i] > 0)
                    {
                        var calculo = clfCompetencias[i] / contadortCompetencias[i];
                        var redondeado = Math.Round(calculo, 2);

                        // Construir el nombre de la clave dinámicamente, por ejemplo, "valueCompetencia1", "valueCompetencia2", ...
                        string clave = "valueCompetencia" + (i + 1);

                        redondeados.Add(clave, redondeado);
                    }
                }
                
                redondeados.Add("valueJefe", calificacionJefe);
                redondeados.Add("valueCliente", calificacionCliente);
                redondeados.Add("valueEquipo", calificacionEquipo);
                redondeados.Add("valueFinal", porcentajeFinalRedondeado);
                redondeados.Add("valueCargo", cargoColaborador);
                
         
                string jsonString = JsonSerializer.Serialize(redondeados);

                return jsonString;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        /*
            autor: Daniel Males
            since: 11-10-2023
            version: 1.0
            Funcion que obtiene las calificaciones de jefe, cliente y equipo de todos los colaboradores

            autor: Daniel Males
            since: 12-10-2023
            version: 1.1
            Se agrega parametro y logica para la busqueda de calificaciones generales por cedula del colaborador
        */
        async Task<object> IEvaluacionService.obtenerCalificacionGeneral(string? cedulaColaborador)
        {
            try
            {
                var evaluaciones = await context.Evaluacion.ToListAsync();

                if (cedulaColaborador != "")
                {
                    var colaboradorByCedula = await context.Colaborador.Where(colaborador => colaborador.Cedula == cedulaColaborador).FirstAsync();


                    var colaboradoresTotales = await context.Colaborador.Where(colaborador => colaborador.Nombres == colaboradorByCedula.Nombres).ToListAsync();

                    evaluaciones.Clear();

                    if (colaboradorByCedula != null)
                    {
                        var colaboradoresCedula = await context.Colaborador
                            .Where(colaborador => colaborador.Nombres == colaboradorByCedula.Nombres)
                            .ToListAsync();

                        var idsColaboradores = colaboradoresCedula.Select(colaborador => colaborador.Id_Colaborador).ToList();

                        // Concatena las evaluaciones de todos los colaboradores
                        var evaluacionesConcatenadass = await context.Evaluacion
                            .Where(evaluacion => idsColaboradores.Contains(evaluacion.Colaborador_id))
                            .ToListAsync();

                        evaluaciones.AddRange(evaluacionesConcatenadass);
                    }

                }

                var colaboradoresIds = evaluaciones.Select(evaluacion => evaluacion.Colaborador_id).Distinct().ToList();

                var colaboradores = await context.Colaborador
                    .Where(colaborador => colaboradoresIds.Contains(colaborador.Id_Colaborador))
                    .ToListAsync();

                var evaluacionesAgrupadas = evaluaciones
                    .GroupBy(evaluacion => colaboradores.FirstOrDefault(colaborador => colaborador.Id_Colaborador == evaluacion.Colaborador_id)?.Nombres)
                    .Select(grupo => new
                    {
                        ColaboradorNombre = grupo.Key,
                        Evaluaciones = grupo.ToList(),
                        ColaboradorIdentificacion = colaboradores.FirstOrDefault(colaborador => colaborador.Nombres == grupo.Key)?.Cedula,
                    })
                    .ToList();

                var dataCalificaciones = new Dictionary<string, decimal> { };
                var dataCalificacionesPdf = new Dictionary<string, decimal> { };


                string dataFinal = "";

                foreach (var grupo in evaluacionesAgrupadas)
                {
                    var colaboradorNombre = grupo.ColaboradorNombre;
                    var evaluacionesDelColaborador = grupo.Evaluaciones;

                    decimal calificacionFinal = 0;

                    //Contadores para los grupos segun el cargo del colaborador
                    //No se considera grupo1 ya que solo sera evaluado por un solo jefe y no varios 

                    int contGrupo2 = 0;
                    int contGrupo3 = 0;

                    //Acumulado o suma de todos los grupos por las evaluaciones del colaborador
                    decimal? grupo1 = 0;
                    decimal? grupo2 = 0;
                    decimal? grupo3 = 0;

                    decimal porcentajeGrupo = 0M;

                    decimal puntajeMax = 0;

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
                                    porcentajeGrupo = 0.40M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;//ej 5*40% = 2
                                                                                                                    //decimal? valorMaximo = 5;

                                    grupo1 = valorCalificacion;
                                    puntajeMax += 5 * porcentajeGrupo;

                                }

                                if (colaborador.Grupo == "CLIENTE")
                                {
                                    porcentajeGrupo = 0.40M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;//ej 5*40% = 2
                                                                                                                    //valorResultante += valorCalificacion;


                                    grupo2 += valorCalificacion;
                                    puntajeMax += 5 * porcentajeGrupo;
                                    contGrupo2++;
                                }

                                if (colaborador.Grupo == "EQUIPO")
                                {
                                    porcentajeGrupo = 0.20M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;//ej 5*40% = 2
                                                                                                                    //valorResultante += valorCalificacion;

                                    grupo3 += valorCalificacion;
                                    puntajeMax += 5 * porcentajeGrupo;
                                    contGrupo3++;
                                }
                            }

                            else if (cargo.Nombre_Cargo == "Supervisores")
                            {
                                if (colaborador.Grupo == "JEFE")
                                {
                                    porcentajeGrupo = 0.50M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;
                                    //valorResultante += valorCalificacion;

                                    grupo1 = valorCalificacion;
                                    puntajeMax += 5 * porcentajeGrupo;
                                }
                                if (colaborador.Grupo == "CLIENTE")
                                {
                                    porcentajeGrupo = 0.25M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;//ej 5*40% = 2
                                                                                                                    //valorResultante += valorCalificacion;

                                    grupo2 += valorCalificacion;
                                    puntajeMax += 5 * porcentajeGrupo;
                                    contGrupo2++;
                                }

                                if (colaborador.Grupo == "EQUIPO")
                                {
                                    porcentajeGrupo = 0.25M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;//ej 5*40% = 2
                                                                                                                    //valorResultante += valorCalificacion;

                                    grupo3 += valorCalificacion;
                                    puntajeMax += 5 * porcentajeGrupo;
                                    contGrupo3++;
                                }
                            }

                            else if (cargo.Nombre_Cargo == "Gestor")
                            {
                                if (colaborador.Grupo == "JEFE")
                                {
                                    porcentajeGrupo = 0.60M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;

                                    grupo1 = valorCalificacion;
                                    puntajeMax += 5 * porcentajeGrupo;
                                }

                                if (colaborador.Grupo == "EQUIPO")
                                {
                                    porcentajeGrupo = 0.40M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;//ej 5*40% = 2
                                                                                                                    //valorResultante += valorCalificacion;

                                    grupo3 += valorCalificacion;
                                    puntajeMax += 5 * porcentajeGrupo;
                                    contGrupo3++;
                                }
                            }

                            else if (cargo.Nombre_Cargo == "Coordinador")
                            {
                                if (colaborador.Grupo == "JEFE")
                                {
                                    porcentajeGrupo = 0.60M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;

                                    grupo1 = valorCalificacion;
                                    puntajeMax += 5 * porcentajeGrupo;
                                }

                                if (colaborador.Grupo == "CLIENTE")
                                {
                                    porcentajeGrupo = 0.40M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;//ej 5*40% = 2
                                                                                                                    //valorResultante += valorCalificacion;

                                    grupo2 += valorCalificacion;
                                    puntajeMax += 5 * porcentajeGrupo;
                                    contGrupo2++;
                                }
                            }

                            else if (cargo.Nombre_Cargo == "Analista" || cargo.Nombre_Cargo == "Vendedor" || cargo.Nombre_Cargo == "Auxiliar")
                            {
                                if (colaborador.Grupo == "JEFE")
                                {
                                    porcentajeGrupo = 1.00M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;

                                    grupo1 = valorCalificacion;
                                    puntajeMax += 5 * porcentajeGrupo;
                                }
                            }

                            else if (cargo.Nombre_Cargo == "Administrador")
                            {
                                if (colaborador.Grupo == "JEFE")
                                {
                                    porcentajeGrupo = 0.50M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;

                                    grupo1 = valorCalificacion;
                                    puntajeMax += 5 * porcentajeGrupo;
                                }

                                if (colaborador.Grupo == "EQUIPO")
                                {
                                    porcentajeGrupo = 0.50M;
                                    decimal? valorCalificacion = evaluacion.CalificacionFinal * porcentajeGrupo / 5;//ej 5*40% = 2
                                                                                                                    //valorResultante += valorCalificacion;


                                    grupo3 += valorCalificacion;
                                    puntajeMax += 5 * porcentajeGrupo;
                                    contGrupo3++;
                                }
                            }



                        }
                    }

                    decimal? calificacionFinalRoles = 0;

                    if (grupo1 != 0)
                    {
                        decimal valorCalificacion = grupo1.Value;
                        calificacionFinalRoles += valorCalificacion;

                        if (cedulaColaborador != "")
                        {
                            var redondeoCalificacion = Math.Round((valorCalificacion * 100), 2);
                            dataCalificacionesPdf.Add("Jefe", redondeoCalificacion);
                        }
                    }

                    if (grupo2 != 0)
                    {
                        decimal valorCalificacion = grupo2.Value / contGrupo2;
                        calificacionFinalRoles += valorCalificacion;
                        if (cedulaColaborador != "")
                        {
                            var redondeoCalificacion = Math.Round((valorCalificacion * 100), 2);
                            dataCalificacionesPdf.Add("Cliente", redondeoCalificacion);
                        }
                    }

                    if (grupo3 != 0)
                    {
                        decimal valorCalificacion = grupo3.Value / contGrupo3;
                        calificacionFinalRoles += valorCalificacion;
                        if (cedulaColaborador != "")
                        {
                            var redondeoCalificacion = Math.Round((valorCalificacion * 100), 2);
                            dataCalificacionesPdf.Add("Equipo", redondeoCalificacion);
                        }
                    }

                    if (cedulaColaborador != "")
                    {
                        return dataCalificacionesPdf;
                    }

                    calificacionFinal = calificacionFinalRoles.Value;
                    decimal porcentajeFinalRedondeado = Math.Round((calificacionFinal * 100), 2); // Redondear a dos decimales

                    dataCalificaciones.Add(colaboradorNombre, porcentajeFinalRedondeado);

                    //Se ordenan los datos de formas asc en base al nombre del colaborador
                    var datosOrdenados = dataCalificaciones.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                    // Serializa el diccionario ordenado a JSON
                    dataFinal = JsonSerializer.Serialize(datosOrdenados);

                }

                

                return dataFinal;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}

 


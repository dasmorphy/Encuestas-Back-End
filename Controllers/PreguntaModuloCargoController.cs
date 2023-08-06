using apiprueba.Models;
using apiprueba.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static apiprueba.DTO.ModuloEvaluacionDto;

namespace apiprueba.Controllers
{

    [ApiController]
    [Route("api/preguntaModuloCargo")]
    public class PreguntaModuloCargoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IModuloPreguntasService moduloPreguntasService;

        public PreguntaModuloCargoController(ApplicationDbContext context, IMapper mapper, IModuloPreguntasService moduloPreguntasService)
        {
            this.context = context;
            this.mapper = mapper;
            this.moduloPreguntasService = moduloPreguntasService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var preguntaModuloCargo = await context.Evaluacion.ToListAsync();
            return Ok(preguntaModuloCargo);
        }


        [HttpGet("{id_Cargo}")]
        public async Task<ActionResult<List<ModuloPreguntasDtoGet>>> ObtenerPreguntas(int id_Cargo)
        {
            try
            {
                var modulosConPreguntas = await moduloPreguntasService.ObtenerModulosConPreguntas(id_Cargo);

                return Ok(modulosConPreguntas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error en el servidor: {ex.Message}");
            }
        }
    }
}

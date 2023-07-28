using apiprueba.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using static apiprueba.DTO.PreguntasEvaluacionDto;

namespace apiprueba.Controllers
{
    //[ApiController]
    //[Route("api/preguntas")]
    //public class PreguntasEvaluacionController : ControllerBase
    //{
    //    private readonly ApplicationDbContext context;
    //    private readonly IMapper mapper;

    //    public PreguntasEvaluacionController(ApplicationDbContext context, IMapper mapper)
    //    {
    //        this.context = context;
    //        this.mapper = mapper;
    //    }


    //    [HttpGet]
    //    public async Task<ActionResult> Get()
    //    {
    //        var preguntas = await context.PreguntasEvaluacion.ToListAsync();
    //        return Ok(preguntas);
    //    }

    //    [HttpGet("{id_pregunta}")]
    //    public async Task<ActionResult> Get(int id_pregunta)
    //    {
    //        var pregunta = await context.PreguntasEvaluacion.FirstOrDefaultAsync(x => x.Id_Pregunta == id_pregunta);
    //        if (pregunta == null)
    //        {
    //            return BadRequest("Pregunta no encontrada");
    //        }

    //        return Ok(pregunta);
    //    }


    //    [HttpPost]
    //    public async Task<ActionResult> Post(PreguntasEvaluacionDtoPost preguntasDtoPost)
    //    {
    //        var preguntas = mapper.Map<PreguntasEvaluacionModel>(preguntasDtoPost);
    //        preguntas.Fecha_Creacion = DateTime.Now;
    //        context.Add(preguntas);
    //        await context.SaveChangesAsync();
    //        return Ok(preguntas);
    //    }

    //    [HttpPut("{id_pregunta}")]
    //    public async Task<ActionResult> Put(int id_pregunta, PreguntasEvaluacionDtoPut preguntasDtoPut)
    //    {
    //        if (id_pregunta != preguntasDtoPut.Id_Pregunta)
    //        {
    //            return BadRequest("Los id no coinciden");
    //        }

    //        var preguntaBD = await context.PreguntasEvaluacion.FirstOrDefaultAsync(x => x.Id_Pregunta == id_pregunta);

    //        if (preguntaBD == null)
    //        {
    //            return BadRequest("Pregunta no encontrada");
    //        }
    //        preguntaBD.Pregunta = preguntasDtoPut.Pregunta;

    //        context.Update(preguntaBD);
    //        await context.SaveChangesAsync();
    //        return Ok(preguntaBD);
    //    }

    //    [HttpDelete("{id_pregunta}")]
    //    public async Task<ActionResult> Delete(int id_pregunta)
    //    {
    //        var preguntaBD = await context.PreguntasEvaluacion.FirstOrDefaultAsync(x => x.Id_Pregunta == id_pregunta);

    //        if (preguntaBD == null)
    //            return BadRequest("Pregunta no encontrada");

    //        context.Remove(preguntaBD);
    //        await context.SaveChangesAsync();
    //        return Ok("Pregunta Eliminado");

    //    }
    //}
        
}
    


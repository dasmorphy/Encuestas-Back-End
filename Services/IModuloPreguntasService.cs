using static apiprueba.DTO.ModuloEvaluacionDto;

namespace apiprueba.Services
{
    public interface IModuloPreguntasService
    {
        Task<List<ModuloPreguntasDtoGet>> ObtenerModulosConPreguntas(int id_Cargo);
    }
}

using apiprueba.DTO;
using apiprueba.Models;
using AutoMapper;
using static apiprueba.DTO.ColaboradorDto;
using static apiprueba.DTO.ModuloEvaluacionDto;
using static apiprueba.DTO.PreguntasByEvaluacionDto;
//using static apiprueba.DTO.PreguntasEvaluacionDto;


/*

15-04-2023 Se crea el Map para enviar los datos del Usuario Dto hacia el modelo Usuarios 
para la insercion de datos


18-04-2023 Creacion UsuarioDtoPost para la relacion uno a uno entre el Usuario y el Colaborador 
validando que el colaborador indicado en el metodo Post exista en bases


1-05-2023 Creacion Mapping Evaluacion para la validacion de que exista un tipo de evaluacion creado
en bases
*/

namespace apiprueba.Utils
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UsuarioDtoPost, UsuariosModel>();

            CreateMap<UsuarioDtoPut, UsuariosModel>();

            CreateMap<ColaboradorDtoPost, ColaboradorModel>();

            CreateMap<ColaboradorDtoPut, ColaboradorModel>();

            //CreateMap<PreguntasEvaluacionDtoPost, PreguntasEvaluacionModel>();

            //CreateMap<PreguntasEvaluacionDtoPut, PreguntasEvaluacionModel>();

            CreateMap<ModuloEvaluacionDtoPost, ModuloEvaluacionModel>()
            .ForMember(dest => dest.TipoEvaluacionModel,
                    opt => opt.MapFrom(src => new TipoEvaluacionModel { Id_Tipo_Evaluacion = src.Tipo_Evaluacion_Id }))
            .ReverseMap();


            CreateMap<ModuloEvaluacionDtoPut, ModuloEvaluacionModel>();

            CreateMap<ModuloPreguntasDtoGet, ModuloEvaluacionModel>()
            .ForMember(dest => dest.TipoEvaluacionModel,
                    opt => opt.MapFrom(src => new TipoEvaluacionModel { Id_Tipo_Evaluacion = src.Tipo_Evaluacion_Id }))
            .ReverseMap();

            CreateMap<PreguntasByEvaluacionDtoPost, PreguntasByEvaluacionModel>()
            .ForMember(dest => dest.ModuloEvaluacionModel,
                    opt => opt.MapFrom(src => new ModuloEvaluacionModel { Id_Modulo_Evaluacion = src.Modulo_Id }));

            CreateMap<ObservacionDtoPost, ObservacionModel>();


            CreateMap<EvaluacionPostDto, EvaluacionModel>()
            .ForMember(dest => dest.ColaboradorModel,
                       opt => opt.MapFrom(src => new ColaboradorModel { Id_Colaborador = src.Colaborador_id }))

            .ForMember(dest => dest.UsuariosModel,
                       opt => opt.MapFrom(src => new UsuariosModel { Id_Usuario = src.Usuario_id }))

            //.ForMember(dest => dest.PreguntasByEvaluacionModel,
            //           opt => opt.MapFrom(src => new PreguntasByEvaluacionModel { Id_Preguntas_Tipo = src.Preguntas_Tipo_id }))

            .ReverseMap();
        }
    }
}

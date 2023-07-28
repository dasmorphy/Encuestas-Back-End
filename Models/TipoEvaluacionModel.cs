using System.ComponentModel.DataAnnotations;


namespace apiprueba.Models
{
    public class TipoEvaluacionModel
    {
        [Key]
        public int Id_Tipo_Evaluacion { get; set; }

        [StringLength(maximumLength: 50)]
        public string Nombre_Tipo { get; set; } = null!;
        public DateTime Fecha_Creacion { get; set; }

        //se agrega el HashSet como como coleccion de PreguntasByEvaluacionModel
        public ICollection<ModuloEvaluacionModel> ModuloEvaluacionModel { get; set; } = new List<ModuloEvaluacionModel>();
        // Relación uno a muchos con UsuariosModel
        //public ICollection<UsuariosModel> UsuariosModel { get; set; } = new List<UsuariosModel>();
        public ICollection<PreguntasByEvaluacionModel> PreguntasByEvaluacionModel { get; set; } = new List<PreguntasByEvaluacionModel>();
    }
}

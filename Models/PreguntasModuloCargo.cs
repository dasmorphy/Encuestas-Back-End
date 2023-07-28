using System.ComponentModel.DataAnnotations;

namespace apiprueba.Models
{
    public class PreguntasModuloCargo
    {
        [Key]
        public int Id_PreguntaModuloCargo { get; set; }

        public int Modulo_Id { get; set; }
        public int Cargo_Id { get; set; }

        public int Tipo_Evaluacion_Id { get; set; }


    }
}

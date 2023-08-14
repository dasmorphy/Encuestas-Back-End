using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiprueba.Models
{
    public class ColaboradorModel
    {
        [Key]
        [Ignore]
        public int Id_Colaborador { get; set; }

        [StringLength(maximumLength: 13)]
        public string Cedula { get; set; } = null!;

        [StringLength(maximumLength: 60)]

        public string Nombres { get; set; } = null!;
        [Format("dd-MM-yy")]
        public DateTime Fe_Ingreso_Colaborador { get; set; }
        public string Cargo_Colaborador { get; set; } = null!;
        public string CC { get; set; } = null!;
        public string Localidad { get; set; } = null!;
        public string Zona { get; set; } = null!;
        public string Area { get; set; } = null!;
        public string Departamento { get; set; } = null!;

        [StringLength(maximumLength: 13)]
        public string Cedula_Evaluador { get; set; } = null!;
        public string Nombres_Evaluador { get; set; } = null!;

        [Format("dd-MM-yy")]
        public DateTime Fe_Ingreso_Evaluador { get; set; }
        public string Cargo_Evaluador { get; set; } = null!;

        [StringLength(maximumLength: 30)]
        public string Cargo { get; set; } = null!;

        [StringLength(maximumLength: 20)]
        public string Grupo { get; set; } = null!;

        [Ignore]
        public int Cargo_Id { get; set; }

        [StringLength(maximumLength: 11)]
        [Ignore]
        public string Estado { get; set; } = null!;
        //public DateTime Fecha_Creacion { get; set; }
        [Ignore]
        public HashSet<EvaluacionModel> Evaluacion { get; set; } = new HashSet<EvaluacionModel>();
    }
}

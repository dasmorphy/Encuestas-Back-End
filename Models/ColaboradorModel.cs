using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiprueba.Models
{
    public class ColaboradorModel
    {
        [Key]
        [Ignore]
        [Column(Order = 1)]
        public int Id_Colaborador { get; set; }

        [StringLength(maximumLength: 13)]
        [Column(Order = 2)]
        public string Cedula { get; set; } = null!;

        [StringLength(maximumLength: 60)]
        [Column(Order = 3)]
        public string Nombres { get; set; } = null!;

        [Format("dd-MM-yy")]
        [Column(Order = 4)]
        public DateTime Fe_Ingreso_Colaborador { get; set; }

        [Column(Order = 5)]
        public string Cargo_Colaborador { get; set; } = null!;

        [Column(Order = 6)]
        public string CC { get; set; } = null!;

        [Column(Order = 7)]
        public string Localidad { get; set; } = null!;

        [Column(Order = 8)]
        public string Zona { get; set; } = null!;

        [Column(Order = 9)]
        public string Area { get; set; } = null!;

        [Column(Order = 10)]
        public string Departamento { get; set; } = null!;


        [StringLength(maximumLength: 13)]
        [Column(Order = 11)]
        public string Cedula_Evaluador { get; set; } = null!;

        [Column(Order = 12)]
        public string Nombres_Evaluador { get; set; } = null!;

        [Format("dd-MM-yy")]
        [Column(Order = 13)]
        public DateTime Fe_Ingreso_Evaluador { get; set; }

        [Column(Order = 14)]
        public string Cargo_Evaluador { get; set; } = null!;

        [StringLength(maximumLength: 30)]
        [Column(Order = 15)]
        public string Cargo { get; set; } = null!;

        [StringLength(maximumLength: 20)]
        [Column(Order = 16)]
        public string Grupo { get; set; } = null!;

        [Ignore]
        [Column(Order = 17)]
        public int Cargo_Id { get; set; }

        [StringLength(maximumLength: 11)]
        [Ignore]
        [Column(Order = 18)]
        public string Estado { get; set; } = null!;
        //public DateTime Fecha_Creacion { get; set; }
        [Ignore]
        public HashSet<EvaluacionModel> Evaluacion { get; set; } = new HashSet<EvaluacionModel>();
    }
}

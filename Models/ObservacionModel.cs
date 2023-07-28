using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiprueba.Models
{
    public class ObservacionModel
    {
        [Key]
        public int Id_Observacion { get; set; }

        [Column(Order = 2)]
        public int Evaluacion_id { get; set; } //relacion uno a uno

        [Column(Order = 3)]
        public string? Observacion1 { get; set; }

        [Column(Order = 4)]
        public string? Observacion2 { get; set; }

        [Column(Order = 5)]
        public string? Observacion3 { get; set; }

        [Column(Order = 6)]
        public string? Observacion4 { get; set; }

        [Column(Order = 7)]
        public string? Observacion5 { get; set; }

        [Column(Order = 8)]
        public string? Observacion6 { get; set; }

        [Column(Order = 9)]
        public string? Observacion7 { get; set; }

        [Column(Order = 10)]
        public string? Observacion8 { get; set; }

        [Column(Order = 11)]
        public string? Observacion9 { get; set; }

        [Column(Order = 12)]
        public string? Observacion10 { get; set; }

        [Column(Order = 13)]
        public string? Observacion11 { get; set; }

        [Column(Order = 14)]
        public string? Observacion12 { get; set; }

        [Column(Order = 15)]
        public string? Observacion13 { get; set; }

        [Column(Order = 16)]
        public string? Observacion14 { get; set; }

        [Column(Order = 17)]
        public string? Observacion15 { get; set; }

        [Column(Order = 18)]
        public string? Observacion16 { get; set; }

        [Column(Order = 19)]
        public string? Observacion17 { get; set; }

        [Column(Order = 20)]
        public string? Observacion18 { get; set; }

        [Column(Order = 21)]
        public string? Observacion19 { get; set; }

        [Column(Order = 22)]
        public string? Observacion20 { get; set; }

        [Column(Order = 23)]
        public string? Observacion21 { get; set; }

        [Column(Order = 24)]
        public string? Observacion22 { get; set; }

        [Column(Order = 25)]
        public string? Observacion23 { get; set; }

        [Column(Order = 26)]
        public string? Observacion24 { get; set; }

        [Column(Order = 27)]
        public string? Observacion25 { get; set; }

        [Column(Order = 28)]
        public string? Observacion26 { get; set; }

        [Column(Order = 29)]
        public string? Observacion27 { get; set; }

        [Column(Order = 30)]
        public string? Observacion28 { get; set; }

        [Column(Order = 31)]
        public string? Observacion29 { get; set; }

        [Column(Order = 32)]
        public string? Observacion30 { get; set; }

        [Column(Order = 33)]
        public string? Observacion31 { get; set; }

        [Column(Order = 34)]
        public string? Observacion32 { get; set; }

        [Column(Order = 35)]
        public string? Observacion33 { get; set; }

        [Column(Order = 36)]
        public string? Observacion34 { get; set; }

        [Column(Order = 37)]
        public string? Observacion35 { get; set; }

        [Column(Order = 38)]
        public string? Observacion36 { get; set; }

        [Column(Order = 39)]
        public string? Observacion37 { get; set; }

        [Column(Order = 40)]
        public string? Observacion38 { get; set; }

        [Column(Order = 41)]
        public string? Observacion39 { get; set; }

        [Column(Order = 42)]
        public string? Observacion40 { get; set; }

        [Column(Order = 43)]
        public string? Observacion41 { get; set; }

        [Column(Order = 44)]
        public string? Observacion42 { get; set; }

        [Column(Order = 45)]
        public string? Observacion43{ get; set; }

        [Column(Order = 46)]
        public string? Observacion44 { get; set; }

        [Column(Order = 47)]
        public string? Observacion45 { get; set; }

        [Column(Order = 48)]
        public string? Observacion46 { get; set; }

        [Column(Order = 49)]
        public string? Observacion47{ get; set; }

        [Column(Order = 50)]
        public string? Observacion48 { get; set; }

        [Column(Order = 51)]
        public string? Observacion49 { get; set; }

        [Column(Order = 52)]
        public string? Observacion50 { get; set; }

        [Column(Order = 53)]
        public string? Observacion51 { get; set; }

        [Column(Order = 54)]
        public string? Observacion52 { get; set; }

        [Column(Order = 55)]
        public DateTime Fecha_Creacion { get; set; }
        public EvaluacionModel EvaluacionModel { get; set; } = null!;

    }

}

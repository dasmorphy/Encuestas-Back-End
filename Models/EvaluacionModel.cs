using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiprueba.Models
{
        public class EvaluacionModel
        {
            [Key]
            public int Id_Evaluacion { get; set; }
            [Column(Order = 2)]
            public int Usuario_id { get; set; } //relacion uno a muchos
            [Column(Order = 3)]
            public int Colaborador_id { get; set; } //relacion uno a muchos
            //[Column(Order = 4)]
            //public int Preguntas_Tipo_id { get; set; } //relacion uno a muchos
            
            [Column(Order = 4)]
            [StringLength(maximumLength: 11)]
            public string? Estado { get; set; } = null!;

            [Column(Order = 5)]
            public decimal? CalificacionFinal { get; set; }
            [Column(Order = 6)]
            public decimal? Clfc_Pregunta1 { get; set; }
            [Column(Order = 7)]
            public decimal? Clfc_Pregunta2 { get; set; }
            [Column(Order = 8)]
            public decimal? Clfc_Pregunta3 { get; set; }
            [Column(Order = 9)]
            public decimal? Clfc_Pregunta4 { get; set; }
            [Column(Order = 10)]
            public decimal? Clfc_Pregunta5 { get; set; }
            [Column(Order = 11)]
            public decimal? Clfc_Pregunta6 { get; set; }
            [Column(Order = 12)]
            public decimal? Clfc_Pregunta7 { get; set; }
            [Column(Order = 13)]
            public decimal? Clfc_Pregunta8 { get; set; }
            [Column(Order = 14)]
            public decimal? Clfc_Pregunta9 { get; set; }
            [Column(Order = 15)]
            public decimal? Clfc_Pregunta10 { get; set; }
            [Column(Order = 16)]
            public decimal? Clfc_Pregunta11 { get; set; }
            [Column(Order = 17)]
            public decimal? Clfc_Pregunta12 { get; set; }
            [Column(Order = 18)]
            public decimal? Clfc_Pregunta13 { get; set; }
            [Column(Order = 19)]
            public decimal? Clfc_Pregunta14 { get; set; }
            [Column(Order = 20)]
            public decimal? Clfc_Pregunta15 { get; set; }
            [Column(Order = 21)]
            public decimal? Clfc_Pregunta16 { get; set; }
            [Column(Order = 22)]
            public decimal? Clfc_Pregunta17 { get; set; }
            [Column(Order = 23)]
            public decimal? Clfc_Pregunta18 { get; set; }
            [Column(Order = 24)]
            public decimal? Clfc_Pregunta19 { get; set; }
            [Column(Order = 25)]
            public decimal? Clfc_Pregunta20 { get; set; }
            [Column(Order = 26)]
            public decimal? Clfc_Pregunta21 { get; set; }
            [Column(Order = 27)]
            public decimal? Clfc_Pregunta22 { get; set; }
            [Column(Order = 28)]
            public decimal? Clfc_Pregunta23 { get; set; }
            [Column(Order = 29)]
            public decimal? Clfc_Pregunta24 { get; set; }
            [Column(Order = 30)]
            public decimal? Clfc_Pregunta25 { get; set; }
            [Column(Order = 31)]
            public decimal? Clfc_Pregunta26 { get; set; }
            [Column(Order = 32)]
            public decimal? Clfc_Pregunta27 { get; set; }
            [Column(Order = 33)]
            public decimal? Clfc_Pregunta28 { get; set; }
            [Column(Order = 34)]
            public decimal? Clfc_Pregunta29 { get; set; }
            [Column(Order = 35)]
            public decimal? Clfc_Pregunta30 { get; set; }
            [Column(Order = 36)]
            public decimal? Clfc_Pregunta31 { get; set; }

            [Column(Order = 37)]
            public decimal? Clfc_Pregunta32 { get; set; }

            [Column(Order = 38)]
            public decimal? Clfc_Pregunta33 { get; set; }

            [Column(Order = 39)]
            public decimal? Clfc_Pregunta34 { get; set; }


            [Column(Order = 40)]
            public decimal? Clfc_Pregunta35 { get; set; }

            [Column(Order = 41)]
            public decimal? Clfc_Pregunta36 { get; set; }

            [Column(Order = 42)]
            public decimal? Clfc_Pregunta37 { get; set; }

            [Column(Order = 43)]
            public decimal? Clfc_Pregunta38 { get; set; }

            [Column(Order = 44)]
            public decimal? Clfc_Pregunta39 { get; set; }

            [Column(Order = 45)]
            public decimal? Clfc_Pregunta40 { get; set; }

            [Column(Order = 46)]
            public decimal? Clfc_Pregunta41 { get; set; }

            [Column(Order = 47)]
            public decimal? Clfc_Pregunta42 { get; set; }

            [Column(Order = 48)]
            public decimal? Clfc_Pregunta43 { get; set; }

            [Column(Order = 49)]
            public decimal? Clfc_Pregunta44 { get; set; }

            [Column(Order = 50)]
            public decimal? Clfc_Pregunta45 { get; set; }

            [Column(Order = 51)]
            public decimal? Clfc_Pregunta46 { get; set; }

            [Column(Order = 52)]
            public decimal? Clfc_Pregunta47 { get; set; }

            [Column(Order = 53)]
            public decimal? Clfc_Pregunta48 { get; set; }

            [Column(Order = 54)]
            public decimal? Clfc_Pregunta49 { get; set; }

            [Column(Order = 55)]
            public decimal? Clfc_Pregunta50 { get; set; }

            [Column(Order = 56)]
            public decimal? Clfc_Pregunta51 { get; set; }

            [Column(Order = 57)]
            public decimal? Clfc_Pregunta52 { get; set; }

            public int Observacion_id { get; set; }
            public DateTime Fecha_Creacion { get; set; }
            public UsuariosModel UsuariosModel { get; set; } = null!;
            public ColaboradorModel ColaboradorModel { get; set; } = null!;
            public ObservacionModel ObservacionModel { get; set; } = null!;
        //public PreguntasByEvaluacionModel PreguntasByEvaluacionModel { get; set; } = null!;

    }
}

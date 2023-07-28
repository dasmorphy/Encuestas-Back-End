using apiprueba.Models;
using System.ComponentModel.DataAnnotations;



/*
 
Dto para el Modelo Evaluacion, el cual implementa solamente los datos necesarios y 
suficientes para realizar un Post 


*/
namespace apiprueba.DTO
{
    public class EvaluacionPostDto
    {
        public int Usuario_id { get; set; } 
        public int Colaborador_id { get; set; } 
        public decimal CalificacionFinal { get; set; }
        public string Estado { get; set; } = null!;

        public decimal Clfc_Pregunta1 { get; set; }
        public decimal Clfc_Pregunta2 { get; set; }
       
        public decimal Clfc_Pregunta3 { get; set; }

        public decimal Clfc_Pregunta4 { get; set; }

        public decimal Clfc_Pregunta5 { get; set; }

        public decimal Clfc_Pregunta6 { get; set; }
 
        public decimal Clfc_Pregunta7 { get; set; }

        public decimal Clfc_Pregunta8 { get; set; }

        public decimal Clfc_Pregunta9 { get; set; }

        public decimal Clfc_Pregunta10 { get; set; }

        public decimal Clfc_Pregunta11 { get; set; }

        public decimal Clfc_Pregunta12 { get; set; }

        public decimal Clfc_Pregunta13 { get; set; }

        public decimal Clfc_Pregunta14 { get; set; }
        public decimal Clfc_Pregunta15 { get; set; }
        public decimal Clfc_Pregunta16 { get; set; }
        public decimal Clfc_Pregunta17 { get; set; }
        public decimal Clfc_Pregunta18 { get; set; }
        public decimal Clfc_Pregunta19 { get; set; }
        public decimal Clfc_Pregunta20 { get; set; }
        public decimal Clfc_Pregunta21 { get; set; }
        public decimal Clfc_Pregunta22 { get; set; }
        public decimal Clfc_Pregunta23 { get; set; }
        public decimal Clfc_Pregunta24 { get; set; }
        public decimal Clfc_Pregunta25 { get; set; }
        public decimal Clfc_Pregunta26 { get; set; }
        public decimal Clfc_Pregunta27 { get; set; }
        public decimal Clfc_Pregunta28 { get; set; }
        public decimal Clfc_Pregunta29 { get; set; }
        public decimal Clfc_Pregunta30 { get; set; }

        public decimal Clfc_Pregunta31 { get; set; }


        public decimal Clfc_Pregunta32 { get; set; }


        public decimal Clfc_Pregunta33 { get; set; }


        public decimal Clfc_Pregunta34 { get; set; }



        public decimal Clfc_Pregunta35 { get; set; }


        public decimal Clfc_Pregunta36 { get; set; }

        public decimal Clfc_Pregunta37 { get; set; }


        public decimal Clfc_Pregunta38 { get; set; }


        public decimal Clfc_Pregunta39 { get; set; }


        public decimal Clfc_Pregunta40 { get; set; }


        public decimal Clfc_Pregunta41 { get; set; }


        public decimal Clfc_Pregunta42 { get; set; }


        public decimal Clfc_Pregunta43 { get; set; }


        public decimal Clfc_Pregunta44 { get; set; }


        public decimal Clfc_Pregunta45 { get; set; }


        public decimal Clfc_Pregunta46 { get; set; }


        public decimal Clfc_Pregunta47 { get; set; }

        public decimal Clfc_Pregunta48 { get; set; }

        public decimal Clfc_Pregunta49 { get; set; }

        public decimal Clfc_Pregunta50 { get; set; }

        public decimal Clfc_Pregunta51 { get; set; }

        public decimal Clfc_Pregunta52 { get; set; }
    }

    public class EvaluacionPutDto
    {
        public int Id_Evaluacion { get; set; }
        public decimal CalificacionFinal { get; set; }
        public decimal? Clfc_Pregunta1 { get; set; }
        public decimal? Clfc_Pregunta2 { get; set; }

        public decimal? Clfc_Pregunta3 { get; set; }

        public decimal? Clfc_Pregunta4 { get; set; }

        public decimal? Clfc_Pregunta5 { get; set; }

        public decimal? Clfc_Pregunta6 { get; set; }

        public decimal? Clfc_Pregunta7 { get; set; }

        public decimal? Clfc_Pregunta8 { get; set; }

        public decimal? Clfc_Pregunta9 { get; set; }

        public decimal? Clfc_Pregunta10 { get; set; }

        public decimal? Clfc_Pregunta11 { get; set; }

        public decimal? Clfc_Pregunta12 { get; set; }

        public decimal? Clfc_Pregunta13 { get; set; }

        public decimal? Clfc_Pregunta14 { get; set; }
        public decimal? Clfc_Pregunta15 { get; set; }
        public decimal? Clfc_Pregunta16 { get; set; }
        public decimal? Clfc_Pregunta17 { get; set; }
        public decimal? Clfc_Pregunta18 { get; set; }
        public decimal? Clfc_Pregunta19 { get; set; }
        public decimal? Clfc_Pregunta20 { get; set; }
        public decimal? Clfc_Pregunta21 { get; set; }
        public decimal? Clfc_Pregunta22 { get; set; }
        public decimal? Clfc_Pregunta23 { get; set; }
        public decimal? Clfc_Pregunta24 { get; set; }
        public decimal? Clfc_Pregunta25 { get; set; }
        public decimal? Clfc_Pregunta26 { get; set; }
        public decimal? Clfc_Pregunta27 { get; set; }
        public decimal? Clfc_Pregunta28 { get; set; }
        public decimal? Clfc_Pregunta29 { get; set; }
        public decimal? Clfc_Pregunta30 { get; set; }

        public decimal? Clfc_Pregunta31 { get; set; }


        public decimal? Clfc_Pregunta32 { get; set; }


        public decimal? Clfc_Pregunta33 { get; set; }


        public decimal? Clfc_Pregunta34 { get; set; }


  
        public decimal? Clfc_Pregunta35 { get; set; }


        public decimal? Clfc_Pregunta36 { get; set; }

        public decimal? Clfc_Pregunta37 { get; set; }

   
        public decimal? Clfc_Pregunta38 { get; set; }

   
        public decimal? Clfc_Pregunta39 { get; set; }


        public decimal? Clfc_Pregunta40 { get; set; }


        public decimal? Clfc_Pregunta41 { get; set; }

 
        public decimal? Clfc_Pregunta42 { get; set; }

  
        public decimal? Clfc_Pregunta43 { get; set; }

    
        public decimal? Clfc_Pregunta44 { get; set; }

 
        public decimal? Clfc_Pregunta45 { get; set; }

  
        public decimal? Clfc_Pregunta46 { get; set; }

 
        public decimal? Clfc_Pregunta47 { get; set; }

        public decimal? Clfc_Pregunta48 { get; set; }

        public decimal? Clfc_Pregunta49 { get; set; }

        public decimal? Clfc_Pregunta50 { get; set; }

        public decimal? Clfc_Pregunta51 { get; set; }

        public decimal? Clfc_Pregunta52 { get; set; }

        public string? Estado { get; set; } = null!;

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sergio.Saude.Dominio;

namespace Prosige_SaudeOc.Models
{
    public class ConsultaExame
    {
        [Key Column(Order = 0)]
        public int ConsultaExameId { get; set; }  

        
        public int ConsultaId { get; set; }

        [Display(Name = "Exame")]
        public int ExameId { get; set; }


        [Display(Name = "Médico Analista")]
        public int MedicoId { get; set; }

        [Display(Name = "Valor")]
        public decimal? Valor { get; set; }

        [Display(Name = "Coleta")]
        public DateTime? DataColeta { get; set; }

        [Display(Name = "Emissão")]
        public DateTime? DataEmissao { get; set; }

        [Display(Name = "Próxima Consulta")]
        public DateTime? ProximaConsulta { get; set; }

        [Display(Name = "Situação")]
        public int SituacaoExame { get; set; }

        [Display(Name = "Observações")]
        public string Observacao { get; set; }



        public Cliente Cliente { get; set; }

        
        [ForeignKey("ConsultaId")]
        public Consulta Consulta { get; set; }

        public Exame Exame { get; set; }

    }
}
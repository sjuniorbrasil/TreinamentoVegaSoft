using Sergio.Saude.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosige_SaudeOc.Models
{
    public class Consulta
    {
        public Cliente Cliente { get; set; }              
        public Funcionario Funcionario { get; set; }       
       


        [Key, Column(Order = 0)]
        public int Id { get; set; }       


        public DateTime? DataAgendamento { get; set; }

        public DateTime? DataAgendado { get; set; }

        public int SituacaoAgenda { get; set; }

        [Required]
        public long ClienteId { get; set; }

        [Required]
        public long FuncionarioId { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Informe somente data válida.")]
        public DateTime? DataConsulta { get; set; }     

        [DataType(DataType.Date, ErrorMessage = "Informe somente data válida.")]
        public DateTime? DataEncaminhado { get; set; }

        public int SituacaoConsulta { get; set; } //0 pendente, 1 apto, 2 inapto, 3 apto com restrição, 4 homologado, 5 encaminhado

        public decimal? ValorConsulta { get; set; }

        public int FormaPagamento { get; set; } // 0 avista, 1 faturamento

        public string Observacao { get; set; }

        public List<ConsultaExame> ConsultaExames { get; set; }













    }
}


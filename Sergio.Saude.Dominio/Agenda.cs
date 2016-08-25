using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sergio.Saude.Dominio
{
    public class Agenda
    {
        public int Id { get; set; }

        public DateTime? DataAgendamento { get; set; }

        public DateTime? DataAtendimento { get; set; }

        public SituacaoAgenda Status { get; set; }

        public int MedicoId { get; set; }

        public int ClienteId { get; set; }

        public int? FuncionarioId { get; set; }

        public Medico Medico { get; set; }

        public Cliente Cliente { get; set; }

        public Funcionario Funcionario { get; set; }


    }

    public enum SituacaoAgenda
    {
       Pendente, Atendimento, Concluido, Cancelado, Remarcado 
    }
}

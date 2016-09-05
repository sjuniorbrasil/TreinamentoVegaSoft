using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sergio.Saude.Dominio
{
    public class Exame
    {

        public int Id { get; set; }

        public String Descricao { get; set; }

        public decimal? Valor { get; set; }
    }
}

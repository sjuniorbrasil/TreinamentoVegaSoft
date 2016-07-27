using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sergio.Saude.Dominio
{
    public class Medico : Pessoa
        {
            public string Crm { get; set; }

            public string Especialidade { get; set; }
        }
}


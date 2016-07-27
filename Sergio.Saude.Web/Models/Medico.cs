using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sergio.Saude.Web.Models
{
    public class Medico : Pessoa
    {
        public string Crm { get; set; }

        public string Especialidade { get; set; }
    }
}
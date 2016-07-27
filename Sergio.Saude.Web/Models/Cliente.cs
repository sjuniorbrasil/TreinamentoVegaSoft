using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sergio.Saude.Web.Models
{
    public class Cliente : Pessoa
    {
        public string Cnpj { get; set; }

        public List<Funcionario> Funcionarios { get; set; }
    }
}
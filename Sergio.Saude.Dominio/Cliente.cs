using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sergio.Saude.Dominio;

namespace Sergio.Saude.Dominio
{
    public class Cliente : Pessoa
    {
        public string Cnpj { get; set; }

        //public List<Funcionario> Funcionarios { get; set; }
    }
}
using System;
using System.Collections.Generic;
using Sergio.Saude.Dominio;

using System.Linq;
using System.Web;


namespace Sergio.Saude.Dominio
{
    public class Funcionario : Pessoa
    {
        
        public string Funcao { get; set; }

        public Cliente cliente { get; set; }

        
    }
}
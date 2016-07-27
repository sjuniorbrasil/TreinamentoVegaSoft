using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Sergio.Saude.Web.Models
{
    public class Funcionario : Pessoa
    {
        [Display(Name="Função")]
        public string Funcao { get; set; }

        public Cliente cliente { get; set; }

        
    }
}
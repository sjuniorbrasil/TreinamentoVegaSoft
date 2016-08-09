using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sergio.Saude.Web.ViewModel
{
    public class MedicoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        //[Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }

        public string Crm { get; set; }

        public string Especialidade { get; set; }
    }
}
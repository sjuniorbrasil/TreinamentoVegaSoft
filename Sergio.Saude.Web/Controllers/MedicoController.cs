using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sergio.Saude.Web.Models;
using Sergio.Saude.Dominio;
using Sergio.Saude.Repositorio;

namespace Sergio.Saude.Web.Controllers
{
    public class MedicoController : Controller
    {
        // GET: Medico
        public ActionResult Index()
        {
           
            return View(Dados.ListaMedicos());
        }      

        //private static List<Medico> ListaMedicos()
        //{
        //    List<Medico> medicos = new List<Medico>();
        //    medicos.Add(new Medico {Id = 1, Nome = "João", Crm = "11111"});
        //    medicos.Add(new Medico {Id = 2, Nome = "zé", Crm = "11111"});
        //    medicos.Add(new Medico {Id = 3, Nome = "mario", Crm = "11111"});
        //    medicos.Add(new Medico {Id = 4, Nome = "Maira", Crm = "11111"});
        //    medicos.Add(new Medico {Id = 5, Nome = "Sergio", Crm = "11111"});
        //    return medicos;
        //}
    }
}
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
            Dados db = new Dados();
           
            return View(db.ListaMedicos());
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
        public ActionResult Incluir()
        {
            Medico medico = new Medico();

            return View(medico);
        }
       [HttpPost]
        public ActionResult Incluir(Medico medicos)
        {
            try
            {
                Dados db = new Dados();

                db.IncluirMedico(medicos);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
            

            return View();
        }


    }
}
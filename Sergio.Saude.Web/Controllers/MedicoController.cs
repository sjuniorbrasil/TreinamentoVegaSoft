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
        Dados db = new Dados();
        
        // GET: Medico
        public ActionResult Index()
        {
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
        public ActionResult Incluir(Medico medico)
        {
            try
            {
                medico.Id = db.ListaMedicos().Max(x => x.Id) + 1;

                db.IncluirMedico(medico);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        public ActionResult Alterar(int id)
        {

            var medico = db.ListaMedicos().Where(x => x.Id == id).FirstOrDefault();
            return View(medico);

        }

        [HttpPost]
        public ActionResult Alterar(Medico medico)
        {
            try
            {
                

                db.AlterarMedico(medico);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }


        }
        public ActionResult Excluir(int id)
        {

            var medico = db.ListaMedicos().Where(x => x.Id == id).FirstOrDefault();
            return View(medico);

        }
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarExclusao(Medico medico)
        {
            
            db.ExcluirMedico(medico);
            return RedirectToAction("Index");
        }



    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sergio.Saude.Web.Models;
using Sergio.Saude.Dominio;
using Sergio.Saude.Repositorio;
using Sergio.Saude.Repositorio.Contexto;
using Sergio.Saude.Web.ViewModel;

namespace Sergio.Saude.Web.Controllers
{
    //[Authorize]
    public class MedicoController : Controller
    {
        SaudeWebDbContexto db = new SaudeWebDbContexto();
        //Dados db = new Dados();
        
        // GET: Medico
        public ActionResult Index()
        {
            return View(db.Medicos);
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
            
            var model = new MedicoViewModel();
           

            return View(model);
        }
       [HttpPost]
        public ActionResult Incluir(Medico medico)
        {
            try
            {
                medico.Id = db.Clientes.Max(x => x.Id) + 1;

                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        public ActionResult Alterar(int id)
        {
            //var medico = db.Medicos.Where(x => x.Id == id).FirstOrDefault();

            var medico = db.Medicos.FirstOrDefault(x => x.Id == id);
            
            var model = new MedicoViewModel();
            model.Id = medico.Id;
            model.Nome = medico.Nome.ToUpper();
            model.Crm = medico.Crm;
            model.Email = medico.Email;
            model.Especialidade = medico.Especialidade;
            return View(model);

        }

        [HttpPost]
        public ActionResult Alterar(Medico medico)
        {
            try
            {
                
                
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }


        }
        public ActionResult Excluir(int id)
        {

            //var medico = db.Medicos.Where(x => x.Id == id).FirstOrDefault();
            var medico = db.Medicos.FirstOrDefault(x => x.Id == id);
            return View(medico);

        }
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarExclusao(Medico medico)
        {
            try
            {
                var excluir = db.Medicos.FirstOrDefault(x => x.Id == medico.Id);
                db.Medicos.Remove(excluir);
                db.SaveChanges();

            }
            catch (Exception)
            {
                
                throw;
            }
            
            return RedirectToAction("Index");
        }



    }
}
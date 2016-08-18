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
        //SaudeWebDbContexto db = new SaudeWebDbContexto();
        //Dados db = new Dados();
        private RepositorioMedico _repositorio;
        private SaudeWebDbContexto _contexto;
        public MedicoController()
        {
            _contexto = new SaudeWebDbContexto();
            _repositorio = new RepositorioMedico(_contexto);

        }

        // GET: Medico
        public ActionResult Index()
        {
            return View(_repositorio.ObterTodos());
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
        public ActionResult Incluir(MedicoViewModel medicoVm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (_repositorio.ObterTodos().Count() > 0)
                    {
                        medicoVm.Id = _repositorio.ObterTodos().Max(x => x.Id) + 1;

                    }
                    Medico medico = new Medico();
                    medico.Id = medicoVm.Id;
                    medico.Nome = medicoVm.Nome;
                    medico.Crm = medicoVm.Crm;
                    medico.Email = medicoVm.Email;
                    _repositorio.Inserir(medico);
                    _contexto.Commit();

                    //db.Medicos.Add(medico);
                    //db.Commit();

                }
                catch (Exception e)
                {
                    _contexto.Rollback();
                    throw new Exception(e.Message);


                }

            }
            return RedirectToAction("Index");
        }





        public ActionResult Alterar(int id)
        {
            //var medico = db.Medicos.Where(x => x.Id == id).FirstOrDefault();

            var medico = _repositorio.Obter(x => x.Id == id);

            var model = new MedicoViewModel();
            model.Id = medico.Id;
            model.Nome = medico.Nome.ToUpper();
            model.Crm = medico.Crm;
            model.Email = medico.Email;
            model.Especialidade = medico.Especialidade;
            return View(model);

        }

        [HttpPost]
        public ActionResult Alterar(MedicoViewModel medicoVm)
        {
            try
            {


                //db.Entry(medico).State = EntityState.Modified;
                //db.SaveChanges();
                var model = new Medico();
                model.Id = medicoVm.Id;
                model.Nome = medicoVm.Nome.ToUpper();
                model.Crm = medicoVm.Crm;
                model.Email = medicoVm.Email;
                model.Especialidade = medicoVm.Especialidade;
                _repositorio.Atualizar(model);
                _contexto.Commit();

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                _contexto.Rollback();
                throw new Exception(e.Message);
            }


        }
        public ActionResult Excluir(int id)
        {

            //var medico = db.Medicos.Where(x => x.Id == id).FirstOrDefault();
            var medico = _repositorio.Obter(x => x.Id == id);
            return View(medico);

        }
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarExclusao(Medico medico)
        {
            try
            {
                 var excluir = _repositorio.Obter(x => x.Id == medico.Id);
                _repositorio.Excluir(excluir);
                _contexto.Commit();
                //db.Medicos.Remove(medico);
                //db.SaveChanges();

            }
            catch (Exception e)
            {
                _contexto.Rollback();
                throw new Exception(e.Message);
                
            }

            return RedirectToAction("Index");
        }



    }
}

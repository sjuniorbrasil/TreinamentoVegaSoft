using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sergio.Saude.Dominio;
using Sergio.Saude.Repositorio.Contexto;

namespace Sergio.Saude.Web.Controllers
{
    public class AgendaController : Controller
    {
        private SaudeWebDbContexto db = new SaudeWebDbContexto();

        // GET: Agenda
        public ActionResult Index()
        {
            var agenda = db.Agenda.Include(a => a.Cliente).Include(a => a.Funcionario).Include(a => a.Medico);
            return View(agenda.ToList());
        }

        // GET: Agenda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agenda.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // GET: Agenda/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Cnpj");
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "Id", "Funcao");
            ViewBag.MedicoId = new SelectList(db.Medicos, "Id", "Crm");
            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataAgendamento,DataAtendimento,Status,MedicoId,ClienteId,FuncionarioId")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                db.Agenda.Add(agenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Cnpj", agenda.ClienteId);
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "Id", "Funcao", agenda.FuncionarioId);
            ViewBag.MedicoId = new SelectList(db.Medicos, "Id", "Crm", agenda.MedicoId);
            return View(agenda);
        }

        // GET: Agenda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agenda.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Cnpj", agenda.ClienteId);
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "Id", "Funcao", agenda.FuncionarioId);
            ViewBag.MedicoId = new SelectList(db.Medicos, "Id", "Crm", agenda.MedicoId);
            return View(agenda);
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataAgendamento,DataAtendimento,Status,MedicoId,ClienteId,FuncionarioId")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Cnpj", agenda.ClienteId);
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "Id", "Funcao", agenda.FuncionarioId);
            ViewBag.MedicoId = new SelectList(db.Medicos, "Id", "Crm", agenda.MedicoId);
            return View(agenda);
        }

        // GET: Agenda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agenda.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agenda agenda = db.Agenda.Find(id);
            db.Agenda.Remove(agenda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

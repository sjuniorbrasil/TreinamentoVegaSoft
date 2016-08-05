using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sergio.Saude.Web.Models;
using Sergio.Saude.Repositorio;
using Sergio.Saude.Dominio;

namespace Sergio.Saude.Web.Controllers
{
    [Authorize]
    public class FuncionarioController : Controller
    {
        Funcionario funcionario = new Funcionario();
        Dados db = new Dados();
        // GET: Funcionario
        public ActionResult Index()
        {
            Dados db = new Dados();
            return View(db.ListaFuncionario());
        }
        //public static List<Funcionario> ListaFuncionario()
        //{
        //    List<Funcionario> funcionarios = new List<Funcionario>();
        //    funcionarios.Add(new Funcionario { Id = 1, Nome = "João" , Email= "teste@hotmail.com", Funcao = "teste" });
        //    funcionarios.Add(new Funcionario { Id = 2, Nome = "zé", Email = "teste@hotmail.com", Funcao = "teste" });
        //    funcionarios.Add(new Funcionario { Id = 3, Nome = "mario", Email = "teste@hotmail.com", Funcao = "teste" });
        //    funcionarios.Add(new Funcionario { Id = 4, Nome = "Maira", Email = "teste@hotmail.com", Funcao = "teste" });
        //    funcionarios.Add(new Funcionario { Id = 5, Nome = "Sergio", Email = "teste@hotmail.com", Funcao = "teste" });
        //    return funcionarios;
        //}
        public ActionResult Incluir()
        {
            
            return View(funcionario);
        }
        [HttpPost]
        public ActionResult Incluir(Funcionario funcionarios)
        {
            try
            {
                
                db.IncluirFuncionario(funcionarios);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public ActionResult Excluir()
        //{
            
        //    return View(funcionario);
        //}
        //[HttpDelete]
        //public ActionResult Excluir(Funcionario funcionarios)
        //{

        //    try
        //    {
                
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        }
    }

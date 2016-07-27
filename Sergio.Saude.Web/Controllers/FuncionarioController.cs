using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sergio.Saude.Web.Models;
using Sergio.Saude.Repositorio;

namespace Sergio.Saude.Web.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            
            return View(Dados.ListaFuncionario());
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
    }
}
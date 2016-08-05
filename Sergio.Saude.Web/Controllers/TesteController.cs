using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sergio.Saude.Repositorio.Contexto;

namespace Sergio.Saude.Web.Controllers
{
    public class TesteController : Controller
    {
        // GET: Teste
        public ActionResult Index()
        {
            SaudeWebDbContexto db = new SaudeWebDbContexto();
            return View();
        }
    }
}
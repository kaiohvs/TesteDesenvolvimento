using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TesteDesenvolvimento.Models;

namespace TesteDesenvolvimento.Controllers
{
    public class HomeController : Controller
    {     

        public IActionResult Index()
        {
            Empresa tbEmpresa = new Empresa();
            tbEmpresa.NomeEmpresa = "Empresa";
            tbEmpresa.DocumentoEmpresa = "Testes";


            return View(tbEmpresa);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
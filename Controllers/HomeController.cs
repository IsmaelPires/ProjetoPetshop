using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoPetshop.Dominio.Interfaces.Servicos;
using ProjetoPetshop.Models;
using System.Diagnostics;

namespace ProjetoPetshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPetshopServico _petshopServico;

        public HomeController(ILogger<HomeController> logger,
            IPetshopServico petshopServico)
        {
            _logger = logger;
            _petshopServico = petshopServico;

        }

        public IActionResult Index()
        {
            var listaPetshop = _petshopServico.SelecionarTodos();

            return View(listaPetshop);
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

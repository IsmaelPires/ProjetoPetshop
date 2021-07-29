using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoPetshop.Dominio.Interfaces.Servicos;
using ProjetoPetshop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPetshop.Controllers
{
    public class PetController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPetServico _petServico;

        public PetController(ILogger<HomeController> logger,
            IPetServico petServico)
        {
            _logger = logger;
            _petServico = petServico;

        }

        public IActionResult Index()
        {
            var listaPet = _petServico.SelecionarTodos();

            return View("Index", listaPet);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

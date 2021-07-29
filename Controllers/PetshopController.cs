using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoPetshop.Dominio.Interfaces.Servicos;
using ProjetoPetshop.Models;
using System.Diagnostics;

namespace ProjetoPetshop.Controllers
{
    public class PetshopController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPetshopServico _petshopServico;

        public PetshopController(ILogger<HomeController> logger,
            IPetshopServico petshopServico)
        {
            _logger = logger;
            _petshopServico = petshopServico;
        }

        public IActionResult Index()
        {
            var listaPetshop = _petshopServico.SelecionarTodos();

            return View("Index", listaPetshop);
        }

        public IActionResult Cadastro()
        {
            return View("Cadastro");
        }

        public JsonResult Salvar(PetshopViewModel dados)
        {
            try
            {
                var entidade = new Dominio.Entidades.Petshop();
                entidade.Nome = dados.Nome;
                entidade.Endereco = dados.Endereco;
                entidade.QuantidadeVagas = dados.Vagas;

                _petshopServico.Incluir(entidade);

                var retorno = Json(new { sucesso = true });

                return retorno;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

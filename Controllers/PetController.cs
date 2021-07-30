using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoPetshop.Dominio.Entidades;
using ProjetoPetshop.Dominio.Interfaces.Servicos;
using ProjetoPetshop.Models;
using System.Diagnostics;

namespace ProjetoPetshop.Controllers
{
    public class PetController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPetServico _petServico;
        private readonly IPetshopServico _petshopServico;

        public PetController(ILogger<HomeController> logger,
            IPetServico petServico,
            IPetshopServico petshopServico)
        {
            _logger = logger;
            _petServico = petServico;
            _petshopServico = petshopServico;

        }

        public IActionResult Index()
        {
            var listaPet = _petServico.SelecionarTodos();

            return View("Index", listaPet);
        }

        public IActionResult Cadastro()
        {
            ViewBag.ListaPetshop = _petshopServico.SelecionarTodos();
            return View("Cadastro");
        }

        [HttpPost]
        public JsonResult Salvar(PetViewModel dados)
        {
            try
            {
                var petshop = _petshopServico.SelecionarPorId(dados.IdPetshop);

                if (petshop.QuantidadeVagas <= 0) {
                    return Json(new {mensagem = "O petshop escolhido está sem vagas. Por favor, escolha outro." });
                }

                var entidade = new Pet();
                entidade.Nome = dados.Nome;
                entidade.NomeDono = dados.NomeDono;
                entidade.EnderecoDono = dados.EnderecoDono;
                entidade.TelefoneDono = dados.TelefoneDono;
                entidade.EstadoSaude = dados.EstadoSaude;
                entidade.MotivoInternacao = dados.MotivoInternacao;
                entidade.Foto = dados.Foto;

                _petServico.Incluir(entidade);

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

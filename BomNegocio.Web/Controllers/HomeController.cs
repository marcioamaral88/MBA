using BomNegocio.Dados.Repositorios;
using BomNegocio.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BomNegocio.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProdutoRepositorio _produtoRepositorio;      

        public HomeController(ILogger<HomeController> logger, ProdutoRepositorio produtoRepositorio)
        {
            _logger = logger;
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Index(string produto)
        {          
            if (!string.IsNullOrWhiteSpace(produto)) {
                var lista = _produtoRepositorio.ListaTodos().Where(x=>x.Nome.Contains(produto));
                return View(lista);
            }
            var listaTodos = _produtoRepositorio.ListaTodos();
            return View(listaTodos);
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

        public PartialViewResult Mensagem()
        {
            return PartialView();
        }
    }
}

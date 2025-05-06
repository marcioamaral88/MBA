using BomNegocio.Dados.Repositorios;
using BomNegocio.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BomNegocio.Web.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly ProdutoRepositorio _produtoRepositorio;
        private readonly CategoriaRepositorio _categoriaRepositorio;
     
        public ProdutosController(ProdutoRepositorio produtoRepositorio, CategoriaRepositorio categoriaRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(); 
            }
            var produtos = _produtoRepositorio.ListaProdutos().Where(p=> p.VendedorId == userId).ToList();
            return View(produtos);
        }
          public IActionResult Detalhes(int? id)
        {
            if (id == null) return NotFound();

            var produto = _produtoRepositorio.PegaPorid(id.Value);

            if (produto == null) return NotFound();

            return View(produto);
        }

        public IActionResult DetalhesVitrine(int? id)
        {
            if (id == null) return NotFound();

            var produto = _produtoRepositorio.PegaPorid(id.Value);

            if (produto == null) return NotFound();

            return View(produto);
        }

        public IActionResult Novo()
        {
            ViewData["CategoriaId"] = new SelectList(_categoriaRepositorio.ListaTodos(), "Id", "Nome");
      
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Novo(Produto produto, IFormFile? imagemUpload)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            try
            {
                if (imagemUpload != null && imagemUpload.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/produtos", imagemUpload.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        imagemUpload.CopyTo(stream);
                    }
                    produto.ProdutoImagem = "/images/produtos/" + imagemUpload.FileName;
                }

                if (ModelState.IsValid)
                {
                    produto.VendedorId = userId;
                    _produtoRepositorio.Adicionar(produto);
                    return RedirectToAction(nameof(Index));
                }
                ViewData["CategoriaId"] = new SelectList(_categoriaRepositorio.ListaTodos(), "Id", "Nome", produto.CategoriaId);

                return View(produto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Erro ao Cadastrar Produto." + ex.Message);
                return View(produto);
            }
        }

        public IActionResult Editar(int? id)
        {
            if (id == null) return NotFound();

            var produto = _produtoRepositorio.PegaPorid(id.Value);
            if (produto == null) return NotFound();

            ViewData["CategoriaId"] = new SelectList(_categoriaRepositorio.ListaTodos(), "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Produto produto, IFormFile? imagemUpload)
        {
            if (id != produto.Id) return NotFound();

            if (imagemUpload != null && imagemUpload.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/produtos", imagemUpload.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    imagemUpload.CopyTo(stream);
                }
                produto.ProdutoImagem = "/images/produtos/" + imagemUpload.FileName;
            }
            

            if (ModelState.IsValid)
            {
                try
                {
                    _produtoRepositorio.Atualizar(produto);                
                }
                catch (Exception ex)
                {
                    if (!_produtoRepositorio.ExisteId(produto.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_categoriaRepositorio.ListaTodos(), "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var produto = _produtoRepositorio.PegaPorid(id.Value);

            if (produto == null) return NotFound();

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var produto = _produtoRepositorio.PegaPorid(id);
            try
            {          
                if (produto != null) _produtoRepositorio.Remover(produto);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Erro ao excluir Produto." + ex.Message);
                return View(produto);
            }

        }

    }
}

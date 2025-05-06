using BomNegocio.Dados.Repositorios;
using BomNegocio.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BomNegocio.Web.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {
        private readonly CategoriaRepositorio _categoriaRepositorio;

        public CategoriaController(CategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public IActionResult Index()
        {
            var produtos = _categoriaRepositorio.ListaTodos();
            return View(produtos.ToList());
        }

        public IActionResult Detalhes(int? id)
        {
            if (id == null) return NotFound();

            var produto = _categoriaRepositorio.PegaPorid(id.Value);

            if (produto == null) return NotFound();

            return View(produto);
        }

        public IActionResult Novo()
        {
          return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Novo(Categoria categoria)
        {         
            if (ModelState.IsValid)
            {
                _categoriaRepositorio.Adicionar(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null) return NotFound();

            var produto = _categoriaRepositorio.PegaPorid(id.Value);
            if (produto == null) return NotFound();

           return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Categoria categoria)
        {
            if (id != categoria.Id) return NotFound();
                 
            if (ModelState.IsValid)
            {
                try
                {
                    _categoriaRepositorio.Atualizar(categoria);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_categoriaRepositorio.ExisteId(categoria.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var categoria = _categoriaRepositorio.PegaPorid(id.Value);

            if (categoria == null) return NotFound();

            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var categoria = _categoriaRepositorio.PegaPorid(id);
            try
            {

                if (categoria != null) _categoriaRepositorio.Remover(categoria);
               
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {

                ModelState.AddModelError("", "Erro ao excluir a categoria. Certifique-se de que não há produtos vinculados.");
                return View(categoria);
            }
      
        }

    }
}

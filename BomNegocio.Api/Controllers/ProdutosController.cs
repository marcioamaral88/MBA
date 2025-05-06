using BomNegocio.Dados.Repositorios;
using BomNegocio.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BomNegocio.Api.Controllers
{   
    [Authorize]
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoRepositorio _produtoRepositorio;

        public ProdutosController(ProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<IEnumerable<Produto>> GetProdutos()
        {
            if (_produtoRepositorio.ListaProdutos() == null)
            {
                return NotFound();
            }

            return _produtoRepositorio.ListaProdutos().ToList();
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<IEnumerable<Produto>> GetProdutoPorCategoria(int id)
        {
            if (_produtoRepositorio.ListaProdutos() == null)
            {
                return NotFound();
            }

            var produto = _produtoRepositorio.ListaProdutos().Where(x=> x.CategoriaId == id).ToList();

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public ActionResult<Produto> PostProduto(Produto produto)
        {
            if (produto == null)
            {
                return Problem("O produto contém erro, favor verifique novamente!");
            }

            if (ModelState.IsValid)
            {
                _produtoRepositorio.Adicionar(produto);
            }
            else
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = "Um ou mais erros de validação ocorreram!"
                });
            }
            
            return Ok(produto);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.Id) return BadRequest();

            if (!ModelState.IsValid) return ValidationProblem(ModelState);
                       
            try
            {
                _produtoRepositorio.Atualizar(produto);
            }
            catch (Exception ex)
            {
                if (!_produtoRepositorio.ExisteId(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
     
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteProduto(int id)
        {
       
            var produto = _produtoRepositorio.PegaPorid(id);

            if (produto == null)
            {
                return NotFound();
            }

            _produtoRepositorio.Remover(produto);

            return NoContent();
        }
              
    }
}

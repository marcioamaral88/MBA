using BomNegocio.Dados.Contexto;
using BomNegocio.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BomNegocio.Dados.Repositorios
{
    public class ProdutoRepositorio : RepositorioBase<Produto>
    {
        public ProdutoRepositorio(BomNegocioContexto contexto) : base(contexto)
        {
        }
        public IEnumerable<Produto> ListaProdutos()
        {
            var produto = contextoBase.Produto
               .Include(v => v.Categoria)
               .Include(v => v.Vendedor)
               .ToList();

            return produto;
        }
    }
}

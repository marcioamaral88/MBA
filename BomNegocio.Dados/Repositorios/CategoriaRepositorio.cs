using BomNegocio.Dados.Contexto;
using BomNegocio.Modelo;

namespace BomNegocio.Dados.Repositorios
{
    public class CategoriaRepositorio : RepositorioBase<Categoria>
    {
        public CategoriaRepositorio(BomNegocioContexto contexto) : base(contexto)
        {
        }
    }
}

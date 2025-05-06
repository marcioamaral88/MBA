using BomNegocio.Dados.Contexto;
using BomNegocio.Dados.Repositorios;
using BomNegocio.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BomNegocio.Dados.Repositorios
{
    public class VendedorRepositorio : RepositorioBase<Vendedor>
    {
        public VendedorRepositorio(BomNegocioContexto contexto) : base(contexto)
        {

        }

        public Vendedor PegarVendedor(string id)
        {
            var vendedor = contextoBase.Vendedor
               .Include(v => v.Produtos)       
               .FirstOrDefault(m => m.Id == id);

            return vendedor;
        }
    }
}

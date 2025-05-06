using BomNegocio.Dados.Contexto;
using Microsoft.EntityFrameworkCore;

namespace BomNegocio.Dados.Repositorios
{
    public class RepositorioBase<TEntidade> where TEntidade : class
    {
  
        protected readonly BomNegocioContexto contextoBase;

        public RepositorioBase(BomNegocioContexto contexto)
        {
            contextoBase = contexto;
        }
        public IEnumerable<TEntidade> ListaTodos()
        {
            return contextoBase.Set<TEntidade>();
        }
        public bool ExisteId(int id)
        {
            return contextoBase.Set<TEntidade>().Find(id) != null;
        }
        public bool Existe(Func<TEntidade, bool> filtro)
        {
            return contextoBase.Set<TEntidade>().FirstOrDefault(filtro) != null;
        }
        public TEntidade PegaPorid(int id)
        {
            return contextoBase.Set<TEntidade>().Find(id);
        }
        public void Adicionar(TEntidade obj)
        {
            contextoBase.Set<TEntidade>().Add(obj);
            contextoBase.SaveChanges();
        }
        public void Atualizar(TEntidade obj)
        {
            contextoBase.Entry(obj).State = EntityState.Modified;
            contextoBase.SaveChanges();
        }
        public void Remover(TEntidade obj)
        {
            contextoBase.Set<TEntidade>().Remove(obj);
            contextoBase.SaveChanges();
        }
        public void Dispose()
        {
            contextoBase.Dispose();
        }
    }
}

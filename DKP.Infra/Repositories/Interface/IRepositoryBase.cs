using DKP.Dominio.DKP;

using System.Linq.Expressions;

namespace DKP.Infra.Repositories.Interface
{
    public interface IRepositorioBase<T> where T : EntidadeBase, new()
    {
        Task Inserir(T entity);
        Task Excluir(T entity);
        Task<T> ObterPorId(int id);
        Task<List<T>> Buscar(Expression<Func<T, bool>> filter);
        Task<List<T>> Listar();
        Task Atualizar(T entity);
    }
}

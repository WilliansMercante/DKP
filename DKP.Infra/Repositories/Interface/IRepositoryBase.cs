using DKP.Dominio.DKP;

using System.Linq.Expressions;

using static Dapper.SqlMapper;

namespace DKP.Infra.Repositories.Interface
{
    public interface IRepositorioBase<T> where T : EntidadeBase, new()
    {
        Task InserirAsync(T entity);
        Task ExcluirAsync(T entity);
        Task<T> ObterPorIdAsync(int id);
        Task<List<T>> BuscarAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> ListarAsync();
        Task AtualizarAsync(T entity);
    }
}

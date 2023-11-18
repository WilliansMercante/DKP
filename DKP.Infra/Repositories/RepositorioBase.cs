using DKP.Dominio.DKP;
using DKP.Infra.Repositories.Interface;

using Dommel;

using System.Linq.Expressions;

namespace DKP.Infra.Repositories
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : EntidadeBase, new()
    {
        public async Task InserirAsync(TEntity entity)
        {
            using (var connection = DbConnect.Connection)
            {
                await connection.InsertAsync(entity);
            }
        }
        public async Task ExcluirAsync(TEntity entity)
        {
            using (var connection = DbConnect.Connection)
            {
                await connection.DeleteAsync(entity);
            }
        }
        public async Task<List<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (var connection = DbConnect.Connection)
            {
                return (await connection.GetAllAsync<TEntity>()).Where(filter.Compile()).ToList();
            }
        }
        public async Task<TEntity> ObterPorIdAsync(int id)
        {
            using (var connection = DbConnect.Connection)
            {
                return (await connection.GetAsync<TEntity>(id));
            }
        }
        public async Task<List<TEntity>> ListarAsync()
        {
            using (var connection = DbConnect.Connection)
            {
                return (await connection.GetAllAsync<TEntity>()).ToList();
            }
        }

        public async Task AtualizarAsync(TEntity entity)
        {
            using (var connection = DbConnect.Connection)
            {
                await connection.UpdateAsync(entity);
            }
        }
    }
}

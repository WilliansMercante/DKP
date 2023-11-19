using DKP.Dominio.DKP.Cadastro.Entidades;

using System.Linq.Expressions;

namespace DKP.Dominio.DKP.Cadastro.Repository
{
    public interface IClienteRepository
    {

        Task InserirAsync(ClienteEntity obj);
        Task AtualizarAsync(ClienteEntity obj);
        Task<ClienteEntity> ObterPorIdAsync(int id);
        Task InativarAsync(int id);
        Task<List<ClienteEntity>> ListarAsync();
        Task<List<ClienteEntity>> ListarUltimos20AtivosAsync();


        Task<List<ClienteEntity>> BuscarAsync(Expression<Func<ClienteEntity, bool>> filter);
    }
}

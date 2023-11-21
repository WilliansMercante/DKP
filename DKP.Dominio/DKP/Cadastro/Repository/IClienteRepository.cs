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

        Task<IEnumerable<ClienteEntity>> Consultar(string nome, string cpf, DateTime? dtNascimento);
        Task<List<ClienteEntity>> BuscarAsync(Expression<Func<ClienteEntity, bool>> filter);
        Task<List<ClienteEntity>> BuscarCpfQueryAsync(string cpf );
    }
}

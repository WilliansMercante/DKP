using DKP.Dominio.DKP.Cadastro.Entidades;

namespace DKP.Dominio.DKP.Cadastro.Repository
{
    public interface IClienteRepository
    {

        Task InserirAsync(ClienteEntity obj);
        Task AtualizarAsync(ClienteEntity obj);
        Task<ClienteEntity> ObterPorIdAsync(int id);
        Task InativarAsync(int id);

    }
}

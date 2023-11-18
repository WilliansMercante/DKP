using DKP.Dominio.DKP.Cadastro.Entidades;

namespace DKP.Dominio.DKP.Cadastro.Repository
{
    public interface IEnderecoRepository
    {
        Task InserirAsync(EnderecoEntity obj);
        Task AtualizarAsync(EnderecoEntity obj);
        Task<EnderecoEntity> ObterPorIdAsync(int id);
        Task ExcluirAsync(int id);
        Task<List<EnderecoEntity>> ListarAsync();
        Task<List<EnderecoEntity>> ListarPorClienteAsync(int id);
        public Task InativarAsync(int id);
    }
}

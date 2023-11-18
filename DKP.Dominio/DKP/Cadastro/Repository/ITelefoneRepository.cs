using DKP.Dominio.DKP.Cadastro.Entidades;

namespace DKP.Dominio.DKP.Cadastro.Repository
{
    public interface ITelefoneRepository
    {
        Task InserirAsync(TelefoneEntity obj);
        Task AtualizarAsync(TelefoneEntity obj);
        Task<TelefoneEntity> ObterPorIdAsync(int id);
        Task ExcluirAsync(int id);
        Task<List<TelefoneEntity>> ListarAsync();
        Task<List<TelefoneEntity>> ListarPorClienteAsync(int id);
        public Task InativarAsync(int id);
    }
}

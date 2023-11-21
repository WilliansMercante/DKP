using DKP.ViewModel.DKP;

namespace DKP.Aplicacao.DKP.Cadastro.Interfaces
{
    public interface IClienteApp
    {
        Task<int> InserirAsync(ClienteViewModel obj);
        Task AtualizarAsync(ClienteViewModel obj);
        Task<ClienteViewModel> ObterPorIdAsync(int id);
        Task<ClienteViewModel> BuscarPorCPFAsync(string cpf);
        Task<IEnumerable<ClienteViewModel>> ListarAsync();
        Task<IEnumerable<ClienteViewModel>> ListarUltimos20AtivosAsync();
        Task<IEnumerable<ClienteViewModel>> Consultar(string nome, string cpf, DateTime? dtNascimento);
        Task InativarAsync(int id);

    }
}

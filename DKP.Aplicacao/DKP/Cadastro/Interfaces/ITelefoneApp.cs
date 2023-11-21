using DKP.ViewModel.DKP;

namespace DKP.Aplicacao.DKP.Cadastro.Interfaces
{
    public interface ITelefoneApp
    {
        Task InserirAsync(TelefoneViewModel obj);
        Task AtualizarAsync(TelefoneViewModel obj);
        Task<TelefoneViewModel> ObterPorIdAsync(int id);
        Task<IEnumerable<TelefoneViewModel>> ListarAsync();
        Task<IEnumerable<TelefoneViewModel>> ListarPorClienteAsync(int IdCliente);
        void InativarAsync(int id);
    }
}

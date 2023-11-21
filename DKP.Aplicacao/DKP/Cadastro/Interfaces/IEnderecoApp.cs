using DKP.ViewModel.DKP;

namespace DKP.Aplicacao.DKP.Cadastro.Interfaces
{
    public interface IEnderecoApp
    {
        Task IncluirAsync(EnderecoViewModel obj);
        Task AtualizarAsync(EnderecoViewModel obj);
        Task<EnderecoViewModel> ConsultarPorId(int id);
        Task<IEnumerable<EnderecoViewModel>> Listar();
        Task<IEnumerable<EnderecoViewModel>> ListarPorCliente(int IdCliente);
        Task Inativar(int id);
    }
}

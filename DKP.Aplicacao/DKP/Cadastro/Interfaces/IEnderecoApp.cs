using DKP.ViewModel.DKP;

namespace DKP.Aplicacao.DKP.Cadastro.Interfaces
{
    public interface IEnderecoApp
    {
        void Incluir(EnderecoViewModel obj);
        Task Atualizar(EnderecoViewModel obj);
        Task<EnderecoViewModel> ConsultarPorId(int id);
        IEnumerable<EnderecoViewModel> Listar();
        IEnumerable<EnderecoViewModel> ListarPorCliente(int IdCliente);
        void Inativar(int id);
    }
}

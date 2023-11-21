using DKP.ViewModel.DKP;

namespace DKP.Aplicacao.DKP.Cadastro.Interfaces
{
    public interface IClienteApp
    {
        int Incluir(ClienteViewModel obj);
        void Atualizar(ClienteViewModel obj);
        Task<ClienteViewModel> ConsultarPorId(int id);
        Task<ClienteViewModel> ConsultarPorCPF(string cpf);
        IEnumerable<ClienteViewModel> Listar();
        Task<IEnumerable<ClienteViewModel>> ListarUltimos20Ativos();
        Task<IEnumerable<ClienteViewModel>> Consultar(string nome, string cpf, DateTime? dtNascimento);
        void Inativar(int id);

    }
}

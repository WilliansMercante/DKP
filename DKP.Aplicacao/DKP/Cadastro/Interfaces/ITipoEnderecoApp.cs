using DKP.ViewModel.DKP;

namespace DKP.Aplicacao.DKP.Cadastro.Interfaces
{
    public interface ITipoEnderecoApp
    {
        Task<IEnumerable<TipoEnderecoViewModel>> ListarAsync();
    }
}

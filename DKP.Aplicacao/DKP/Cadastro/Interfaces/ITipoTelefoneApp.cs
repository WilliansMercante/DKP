using DKP.ViewModel.DKP;

namespace DKP.Aplicacao.DKP.Cadastro.Interfaces
{
    public interface ITipoTelefoneApp
    {
        Task<IEnumerable<TipoTelefoneViewModel>> ListarAsync();
    }
}

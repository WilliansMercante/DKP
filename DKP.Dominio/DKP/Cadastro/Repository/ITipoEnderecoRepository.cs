using DKP.Dominio.DKP.Cadastro.Entidades;

namespace DKP.Dominio.DKP.Cadastro.Repository
{
    public interface ITipoEnderecoRepository
    {
        Task<List<TipoEnderecoEntity>> ListarAsync();
    }
}

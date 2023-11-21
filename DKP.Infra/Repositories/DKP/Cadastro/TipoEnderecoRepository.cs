using DKP.Dominio.DKP.Cadastro.Entidades;
using DKP.Dominio.DKP.Cadastro.Repository;

namespace DKP.Infra.Repositories.DKP.Cadastro
{
    public sealed class TipoEnderecoRepository : RepositorioBase<TipoEnderecoEntity>, ITipoEnderecoRepository
    {
        public TipoEnderecoRepository()
        {
        }
    }
}

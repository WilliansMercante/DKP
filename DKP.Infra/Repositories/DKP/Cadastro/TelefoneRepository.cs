using DKP.Dominio.DKP.Cadastro.Entidades;
using DKP.Dominio.DKP.Cadastro.Repository;

namespace DKP.Infra.Repositories.DKP.Cadastro
{

    public sealed class TelefoneRepository : RepositorioBase<TelefoneEntity>, ITelefoneRepository
    {
        public TelefoneRepository()
        {
        }

        public Task ExcluirAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task InativarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TelefoneEntity>> ListarPorClienteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

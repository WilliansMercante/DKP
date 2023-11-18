using DKP.Dominio.DKP.Cadastro.Entidades;
using DKP.Dominio.DKP.Cadastro.Repository;

namespace DKP.Infra.Repositories.DKP.Cadastro
{
    public sealed class ClienteRepository : RepositorioBase<ClienteEntity>, IClienteRepository
    {
        public ClienteRepository()
        {
        }

        public async Task InativarAsync(int id)
        {
            var oClienteEntity = await ObterPorIdAsync(id);
            oClienteEntity.FlAtivo = false;
            await AtualizarAsync(oClienteEntity);
        }
    }
}

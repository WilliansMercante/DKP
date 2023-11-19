using Dapper;

using DKP.Dominio.DKP.Cadastro.Entidades;
using DKP.Dominio.DKP.Cadastro.Repository;

namespace DKP.Infra.Repositories.DKP.Cadastro
{
    public sealed class ClienteRepository : RepositorioBase<ClienteEntity>, IClienteRepository
    {
        public ClienteRepository()
        {
        }

        public Task<List<ClienteEntity>> BuscarUltimos20AtivosAsync()
        {
            throw new NotImplementedException();
        }

        public async Task InativarAsync(int id)
        {
            var oClienteEntity = await ObterPorIdAsync(id);
            oClienteEntity.FlAtivo = false;
            await AtualizarAsync(oClienteEntity);
        }

        public async Task<List<ClienteEntity>> ListarUltimos20AtivosAsync()
        {

            using (var connection = DbConnect.Connection)
            {
                return (await connection.QueryAsync<ClienteEntity>("SELECT TOP (20) * FROM DKP.cadastro.TB_CLIENTE ORDER BY DT_CADASTRO DESC")).ToList();
            }
        }
    }
}

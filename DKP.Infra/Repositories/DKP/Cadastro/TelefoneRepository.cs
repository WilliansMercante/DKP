using Dapper;

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

        public async Task<List<TelefoneEntity>> ListarPorClienteAsync(int IdCliente)
        {
            using (var connection = DbConnect.Connection)
            {
                string query = "SELECT * FROM DKP.cadastro.TB_TELEFONE T " +
                               "LEFT JOIN DKP.cadastro.TB_TIPO_TELEFONE TT ON T.ID_TIPO_TELEFONE = TT.ID_TIPO_TELEFONE " +
                               "WHERE T.ID_CLIENTE = @IdCliente";

                var parametros = new { IdCliente };

                var resultados = await connection.QueryAsync<TelefoneEntity, TipoTelefoneEntity, TelefoneEntity>(
                    query,
                    (telefone, tipoTelefone) =>
                    {
                        telefone.TipoTelefone = tipoTelefone;
                        return telefone;
                    },
                    parametros,
                    splitOn: "ID_TIPO_TELEFONE" 
                );

                return resultados.ToList();
            }
        }
    }
}

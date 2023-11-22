using Dapper;

using DKP.Dominio.DKP.Cadastro.Entidades;
using DKP.Dominio.DKP.Cadastro.Repository;

namespace DKP.Infra.Repositories.DKP.Cadastro
{
    public sealed class EnderecoRepository : RepositorioBase<EnderecoEntity>, IEnderecoRepository
    {
        public EnderecoRepository()
        {
        }

        public async Task ExcluirAsync(int id)
        {
           var oEnderecoEntity = await ObterPorIdAsync(id);
            await ExcluirAsync(oEnderecoEntity);
        }

        public async Task InativarAsync(int id)
        {
            var enderecoDM = await ObterPorIdAsync(id);
            enderecoDM.FlAtivo = false;
            await AtualizarAsync(enderecoDM);
        }

        public async Task<List<EnderecoEntity>> ListarPorClienteAsync(int IdCliente)
        {
            using (var connection = DbConnect.Connection)
            {
                string query = "SELECT * FROM DKP.cadastro.TB_ENDERECO E " +
                               "LEFT JOIN DKP.cadastro.TB_TIPO_ENDERECO TE ON E.ID_TIPO_ENDERECO = TE.ID_TIPO_ENDERECO " +
                               "WHERE E.ID_CLIENTE = @IdCliente";

                var parametros = new { IdCliente };

                var resultados = await connection.QueryAsync<EnderecoEntity, TipoEnderecoEntity, EnderecoEntity>(
                    query,
                    (endereco, tipoEndereco) =>
                    {
                        endereco.TipoEndereco = tipoEndereco; // Preenche o tipo de endereço na entidade EnderecoEntity
                        return endereco;
                    },
                    parametros,
                    splitOn: "ID_TIPO_ENDERECO" // Substitua "IdTipoEndereco" pela chave primária real da tabela de tipos de endereço
                );

                return resultados.ToList();
            }
        }
    }
}

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

        public async Task<IEnumerable<ClienteEntity>> Consultar(string nome, string cpf, DateTime? dtNascimento)
        {           

            using (var connection = DbConnect.Connection)
            {

                string query = "SELECT * FROM DKP.cadastro.TB_CLIENTE WHERE 1 = 1";

                // Adiciona condições apenas se os parâmetros não forem nulos ou vazios
                if (!string.IsNullOrEmpty(nome))
                {
                    query += " AND NM_CLIENTE = @Nome";
                }

                if (!string.IsNullOrEmpty(cpf))
                {
                    query += " AND NR_CPF = @CPF";
                }

                // Adiciona a condição opcional para a data de nascimento se for fornecida
                if (dtNascimento.HasValue)
                {
                    query += " AND DT_NASCIMENTO = @DataNascimento";
                }

                // Executa a consulta
                var parametros = new { Nome = nome, CPF = cpf, DataNascimento = dtNascimento };
                var resultados = connection.Query<ClienteEntity>(query, parametros);

                return resultados;
            }
        }

        public async Task<List<ClienteEntity>> BuscarCpfQueryAsync(string cpf)
        {
            using (var connection = DbConnect.Connection)
            {

                string query = "SELECT * FROM DKP.cadastro.TB_CLIENTE WHERE 1 = 1";

          
                if (!string.IsNullOrEmpty(cpf))
                {
                    query += " AND NR_CPF = @CPF";               }

                var parametros = new { CPF = cpf };
                var resultados = connection.Query<ClienteEntity>(query, parametros);

                return resultados.ToList();
            }
        }
    }
}

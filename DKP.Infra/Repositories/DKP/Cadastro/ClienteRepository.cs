using Dapper;

using DKP.Dominio.DKP.Cadastro.Entidades;
using DKP.Dominio.DKP.Cadastro.Repository;

using Dommel;

using static Dapper.SqlMapper;

namespace DKP.Infra.Repositories.DKP.Cadastro
{
    public sealed class ClienteRepository : RepositorioBase<ClienteEntity>, IClienteRepository
    {       
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

        public async Task<IEnumerable<ClienteEntity>> ConsultarAsync(string nome, string cpf, DateTime? dtNascimento)
        {

            using (var connection = DbConnect.Connection)
            {

                string query = "SELECT * FROM DKP.cadastro.TB_CLIENTE WHERE 1 = 1";

                if (!string.IsNullOrEmpty(nome))
                {
                    query += " AND NM_CLIENTE = @Nome";
                }

                if (!string.IsNullOrEmpty(cpf))
                {
                    query += " AND NR_CPF = @CPF";
                }

                if (dtNascimento.HasValue)
                {
                    query += " AND DT_NASCIMENTO = @DataNascimento";
                }

                var parametros = new { Nome = nome, CPF = cpf, DataNascimento = dtNascimento };
                var resultados = connection.Query<ClienteEntity>(query, parametros);

                return resultados;
            }
        }

        public async Task<List<ClienteEntity>> BuscarCpfQueryAsync(string cpf)
        {
            using (var connection = DbConnect.Connection)
            {
                string query = "SELECT * FROM DKP.cadastro.TB_CLIENTE C";

                query += " LEFT JOIN DKP.cadastro.TB_ENDERECO E ON C.ID_CLIENTE = E.ID_CLIENTE";
                query += " LEFT JOIN DKP.cadastro.TB_TELEFONE T ON C.ID_CLIENTE = T.ID_CLIENTE";

                if (!string.IsNullOrEmpty(cpf))
                {
                    query += " WHERE C.NR_CPF = @CPF";
                }

                var parametros = new { CPF = cpf };

                var resultados = await connection.QueryAsync<ClienteEntity, EnderecoEntity, TelefoneEntity, ClienteEntity>(
                     query,
                     (cliente, endereco, telefone) =>
                     {
                         if (cliente.Enderecos == null)
                             cliente.Enderecos = new List<EnderecoEntity>();

                         cliente.Enderecos.Add(endereco);

                         if (cliente.Telefones == null)
                             cliente.Telefones = new List<TelefoneEntity>();

                         cliente.Telefones.Add(telefone);

                         return cliente;
                     },
                     parametros,
                     splitOn: "ID_ENDERECO,ID_TELEFONE" 
                 );

                return resultados.ToList();
            }
        }








        public async Task<int> InserirRetornaIdAsync(ClienteEntity clienteEntity)
        {
            await InserirAsync(clienteEntity);
            var oClienteEntity = await Primeiro(clienteEntity.CPF);
            return oClienteEntity.Id;
        }

        public async Task<ClienteEntity> Primeiro(string cpf)
        {
            using (var connection = DbConnect.Connection)
            {
                var oCLienteEntity = await connection.FirstOrDefaultAsync<ClienteEntity>(p => p.CPF == cpf);
                return oCLienteEntity;
            }
        }
    }
}

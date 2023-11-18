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
            var lstEnderecoEntity = await BuscarAsync(p => p.IdCliente == IdCliente);
            return lstEnderecoEntity;
        }      
    }
}

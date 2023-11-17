using DKP.Dominio.DKP.Cadastro.Entidades;

namespace DKP.Dominio.DKP.Cadastro.Repository
{
    public interface IEnderecoRepository
    {
        void Incluir(EnderecoEntity obj);
        void Atualizar(EnderecoEntity obj);
        EnderecoEntity ConsultarPorId(int id);
        void Excluir(int id);
        IEnumerable<EnderecoEntity> Listar();
        IEnumerable<EnderecoEntity> ListarPorCliente(int IdCliente);
        public void Inativar(int id);
    }
}

using DKP.Dominio.DKP.Cadastro.Entidades;

namespace DKP.Dominio.DKP.Cadastro.Repository
{
    public interface ITelefoneRepository
    {
        void Incluir(TelefoneEntity obj);
        void Atualizar(TelefoneEntity obj);
        TelefoneEntity ConsultarPorId(int id);
        void Excluir(int id);
        IEnumerable<TelefoneEntity> Listar();
        IEnumerable<TelefoneEntity> ListarPorCliente(int idCliente);
        void Inativar(int id);
    }
}

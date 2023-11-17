using DKP.Dominio.DKP.Cadastro.Entidades;

namespace DKP.Dominio.DKP.Cadastro.Repository
{
    public interface ITipoTelefoneRepository
    {
        IEnumerable<TipoTelefoneEntity> Listar();
    }
}

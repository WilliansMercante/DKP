using DKP.Dominio.DKP.Cadastro.Entidades;

namespace DKP.Dominio.DKP.Cadastro.Repository
{
    public interface ITipoEnderecoRepository
    {
        IEnumerable<TipoEnderecoEntity> Listar();
    }
}

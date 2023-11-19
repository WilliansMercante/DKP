using Dapper.FluentMap.Dommel.Mapping;

using DKP.Dominio.DKP.Cadastro.Entidades;

namespace DKP.Infra.Mappings
{
    public class ClienteMapping : DommelEntityMap<ClienteEntity>
    {
        public ClienteMapping()
        {
            ToTable("TB_CLIENTE", "cadastro");
            Map(x => x.Id).ToColumn("ID_CLIENTE").IsKey();
            Map(x => x.Nome).ToColumn("NM_CLIENTE");
            Map(x => x.DtNascimento).ToColumn("DT_NASCIMENTO");
            Map(x => x.CPF).ToColumn("NR_CPF");
            Map(x => x.DtCadastro).ToColumn("DT_CADASTRO");
            Map(x => x.Rg).ToColumn("NR_RG");
            Map(x => x.FlAtivo).ToColumn("FL_ATIVO");
        }
    }
}

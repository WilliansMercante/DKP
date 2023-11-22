using Dapper.FluentMap.Dommel.Mapping;

using DKP.Dominio.DKP.Cadastro.Entidades;

namespace DKP.Infra.Mappings
{
    public class TelefoneMapping : DommelEntityMap<TelefoneEntity>
    {
        public TelefoneMapping()
        {
            ToTable("TB_TELEFONE", "cadastro");
            Map(x => x.Id).ToColumn("ID_TELEFONE").IsKey();
            Map(x => x.IdCliente).ToColumn("ID_CLIENTE");
            Map(x => x.IdTipoTelefone).ToColumn("ID_TIPO_TELEFONE");
            Map(x => x.DDD).ToColumn("NR_DDD");
            Map(x => x.Numero).ToColumn("NR_TELEFONE");
            Map(x => x.DtCadastro).ToColumn("DT_CADASTRO");
            Map(x => x.FlAtivo).ToColumn("FL_ATIVO");
        }
    }
}

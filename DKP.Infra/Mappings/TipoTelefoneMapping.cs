using Dapper.FluentMap.Dommel.Mapping;

using DKP.Dominio.DKP.Cadastro.Entidades;

namespace DKP.Infra.Mappings
{
    public class TipoTelefoneMapping : DommelEntityMap<TipoTelefoneEntity>
    {
        public TipoTelefoneMapping()
        {
            ToTable("TB_TIPO_TELEFONE", "cadastro");
            Map(x => x.Id).ToColumn("ID_TIPO_TELEFONE").IsKey();
            Map(x => x.Tipo).ToColumn("DS_TELEFONE");
            Map(x => x.FlAtivo).ToColumn("FL_ATIVO");
        }
    }

}

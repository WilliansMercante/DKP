using Dapper.FluentMap.Dommel.Mapping;

using DKP.Dominio.DKP.Cadastro.Entidades;

namespace DKP.Infra.Mappings
{
    public class TipoEnderecoMapping : DommelEntityMap<TipoEnderecoEntity>
    {
        public TipoEnderecoMapping()
        {
            ToTable("TB_TIPO_ENDERECO", "cadastro");
            Map(x => x.Id).ToColumn("ID_TIPO_ENDERECO").IsKey();
            Map(x => x.Tipo).ToColumn("DS_TIPO_ENDERECO");
            Map(x => x.FlAtivo).ToColumn("FL_ATIVO");
        }
    }
}

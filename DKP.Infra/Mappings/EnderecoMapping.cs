using Dapper.FluentMap.Dommel.Mapping;

using DKP.Dominio.DKP.Cadastro.Entidades;

namespace DKP.Infra.Mappings
{
    public class EnderecoMapping : DommelEntityMap<EnderecoEntity>
    {
        public EnderecoMapping()
        {
            ToTable("TB_ENDERECO", "cadastro");
            Map(x => x.Id).ToColumn("ID_ENDERECO").IsKey();
            Map(x => x.IdCliente).ToColumn("ID_CLIENTE");
            Map(x => x.IdTipoEndereco).ToColumn("ID_TIPO_ENDERECO");
            Map(x => x.Rua).ToColumn("NM_LOGRADOURO");
            Map(x => x.Numero).ToColumn("NR_LOGRADORO");
            Map(x => x.Cep).ToColumn("NR_CEP");
            Map(x => x.Bairro).ToColumn("NM_BAIRRO");
            Map(x => x.DtCadastro).ToColumn("DT_CADASTRO");
            Map(x => x.FlAtivo).ToColumn("FL_ATIVO");
            Map(x => x.Complemento).ToColumn("NM_COMPLEMENTO");
            Map(x => x.Municipio).ToColumn("NM_MUNICIPIO");
            Map(x => x.UF).ToColumn("UF");
        }
    }
}

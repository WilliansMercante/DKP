using AutoMapper;
using DKP.Dominio.DKP.Cadastro.Entidades;
using DKP.ViewModel.DKP;

namespace DKP.Aplicacao.Mapping
{
    public class MapperConfig
    {
        public static IMapper RegisterMappers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                DKP(cfg);
            });

            return config.CreateMapper();
        }

        private static void DKP(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ClienteEntity, ClienteViewModel>().ReverseMap();
            cfg.CreateMap<TelefoneEntity, TelefoneViewModel>().ReverseMap();
            cfg.CreateMap<TipoEnderecoEntity, TipoEnderecoViewModel>().ReverseMap();
            cfg.CreateMap<TipoTelefoneEntity, TipoTelefoneViewModel>().ReverseMap();
        }
    }
}

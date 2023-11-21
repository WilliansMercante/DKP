using AutoMapper;

using DKP.Aplicacao.DKP.Cadastro.Interfaces;
using DKP.Aplicacao.Mapping;
using DKP.Dominio.DKP.Cadastro.Repository;
using DKP.ViewModel.DKP;

namespace DKP.Aplicacao.DKP.Cadastro
{
    public sealed class TipoEnderecoApp : ITipoEnderecoApp
    {
        private readonly ITipoEnderecoRepository _tipoEnderecoRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        public TipoEnderecoApp
        (
            ITipoEnderecoRepository tipoEnderecoRepository

        )
        {
            _tipoEnderecoRepository = tipoEnderecoRepository;

        }

        public async Task<IEnumerable<TipoEnderecoViewModel>> ListarAsync()
        {
            var lstTipoEnderecoEntity = await _tipoEnderecoRepository.ListarAsync();
            var lstTipoEnderecoViewModel = _mapper.Map<IEnumerable<TipoEnderecoViewModel>>(lstTipoEnderecoEntity);
            return lstTipoEnderecoViewModel;
        }
    }

}

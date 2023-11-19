using AutoMapper;

using DKP.Aplicacao.DKP.Cadastro.Interfaces;
using DKP.Aplicacao.Mapping;
using DKP.Dominio.DKP.Cadastro.Repository;
using DKP.ViewModel.DKP;

namespace DKP.Aplicacao.DKP.Cadastro
{
    public sealed class TipoEnderecoApp /*: ITipoEnderecoApp*/
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

        //public IEnumerable<TipoEnderecoViewModel> Listar()
        //{
        //    var lstTipoEnderecoEntity = _tipoEnderecoRepository.Listar();
        //    var lstTipoEnderecoViewModel = _mapper.Map<IEnumerable<TipoEnderecoViewModel>>(lstTipoEnderecoEntity);
        //    return lstTipoEnderecoViewModel;
        //}
    }

}

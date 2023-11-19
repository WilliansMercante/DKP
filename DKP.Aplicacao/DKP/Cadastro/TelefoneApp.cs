using AutoMapper;

using DKP.Aplicacao.DKP.Cadastro.Interfaces;
using DKP.Aplicacao.Mapping;
using DKP.Dominio.DKP.Cadastro.Entidades;
using DKP.Dominio.DKP.Cadastro.Repository;
using DKP.ViewModel.DKP;

namespace DKP.Aplicacao.DKP.Cadastro
{
    public sealed class TelefoneApp /*: ITelefoneApp*/
    {
        private readonly ITelefoneRepository _TelefoneRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        public TelefoneApp
        (
            ITelefoneRepository telefoneRepository
        )
        {
            _TelefoneRepository = telefoneRepository;
        }

        //public void Atualizar(TelefoneViewModel oTelefoneViewModel)
        //{
        //    var oTelefoneEntity = _mapper.Map<TelefoneEntity>(oTelefoneViewModel);
        //    _TelefoneRepository.Atualizar(oTelefoneEntity);
        //}

        //public TelefoneViewModel ConsultarPorId(int id)
        //{
        //    var oTelefoneEntity = _TelefoneRepository.ConsultarPorId(id);
        //    var oTelefoneViewModel = _mapper.Map<TelefoneViewModel>(oTelefoneEntity);
        //    return oTelefoneViewModel;
        //}

        //public void Inativar(int id)
        //{
        //    _TelefoneRepository.Inativar(id);
        //}

        //public void Incluir(TelefoneViewModel enderecoVM)
        //{
        //    var oTelefoneEntity = _mapper.Map<TelefoneEntity>(enderecoVM);
        //    oTelefoneEntity.FlAtivo = true;
        //    oTelefoneEntity.DtCadastro = DateTime.Now;
        //    _TelefoneRepository.Incluir(oTelefoneEntity);
        //}

        //public IEnumerable<TelefoneViewModel> Listar()
        //{
        //    var lstTelefoneEntity = _TelefoneRepository.Listar();
        //    var lstTelefoneViewModel = _mapper.Map<IEnumerable<TelefoneViewModel>>(lstTelefoneEntity);
        //    return lstTelefoneViewModel;
        //}

        //public IEnumerable<TelefoneViewModel> ListarPorCliente(int IdCliente)
        //{
        //    var lstTelefoneEntity = _TelefoneRepository.ListarPorCliente(IdCliente);
        //    var lstTelefoneViewModel = _mapper.Map<IEnumerable<TelefoneViewModel>>(lstTelefoneEntity);
        //    return lstTelefoneViewModel;
        //}
    }

}

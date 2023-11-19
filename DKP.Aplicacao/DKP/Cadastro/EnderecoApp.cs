using AutoMapper;

using DKP.Aplicacao.DKP.Cadastro.Interfaces;
using DKP.Aplicacao.Mapping;
using DKP.Dominio.DKP.Cadastro.Entidades;
using DKP.Dominio.DKP.Cadastro.Repository;
using DKP.ViewModel.DKP;

namespace DKP.Aplicacao.DKP.Cadastro
{
    public sealed class EnderecoApp /*: IEnderecoApp*/
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        public EnderecoApp
        (
            IEnderecoRepository enderecoRepository
        )
        {
            _enderecoRepository = enderecoRepository;
        }

        //public void Atualizar(EnderecoViewModel oEnderecoViewModel)
        //{
        //    var oEnderecoEntity = _mapper.Map<EnderecoEntity>(oEnderecoViewModel);
        //    _enderecoRepository.Atualizar(oEnderecoEntity);
        //    _unitOfWork.Commit();
        //}

        //public EnderecoViewModel ConsultarPorId(int id)
        //{
        //    var oEnderecoEntity = _enderecoRepository.ConsultarPorId(id);
        //    var oEnderecoViewModel = _mapper.Map<EnderecoViewModel>(oEnderecoEntity);
        //    return oEnderecoViewModel;
        //}

        //public void Inativar(int id)
        //{
        //    _enderecoRepository.Inativar(id);
        //    _unitOfWork.Commit();
        //}

        //public void Incluir(EnderecoViewModel oEnderecoViewModel)
        //{
        //    oEnderecoViewModel.FlAtivo = true;
        //    var oEnderecoEntity = _mapper.Map<EnderecoEntity>(oEnderecoViewModel);
        //    oEnderecoEntity.DtCadastro = DateTime.Now;
        //    _enderecoRepository.Incluir(oEnderecoEntity);

        //    _unitOfWork.Commit();
        //}

        //public IEnumerable<EnderecoViewModel> Listar()
        //{
        //    var lstEnderecoEntity = _enderecoRepository.Listar();
        //    var lstEnderecoViewModel = _mapper.Map<IEnumerable<EnderecoViewModel>>(lstEnderecoEntity);
        //    return lstEnderecoViewModel;
        //}

        //public IEnumerable<EnderecoViewModel> ListarPorCliente(int IdCliente)
        //{
        //    var lstEnderecoEntity = _enderecoRepository.ListarPorCliente(IdCliente);
        //    var lstEnderecoViewModel = _mapper.Map<IEnumerable<EnderecoViewModel>>(lstEnderecoEntity);
        //    return lstEnderecoViewModel;
        //}
    }
}

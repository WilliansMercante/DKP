using AutoMapper;

using DKP.Aplicacao.DKP.Cadastro.Interfaces;
using DKP.Aplicacao.Mapping;
using DKP.Dominio.DKP.Cadastro.Entidades;
using DKP.Dominio.DKP.Cadastro.Repository;
using DKP.Dominio.Helpers;
using DKP.ViewModel.DKP;

namespace DKP.Aplicacao.DKP.Cadastro
{
    public sealed class ClienteApp : IClienteApp
    {
        private readonly IClienteRepository _ClienteRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        public ClienteApp
        (
            IClienteRepository clienteRepository
        )
        {
            _ClienteRepository = clienteRepository;
        }

        public void Atualizar(ClienteViewModel oClienteViewModel)
        {
            var oClienteEntity = _mapper.Map<ClienteEntity>(oClienteViewModel);
            _ClienteRepository.AtualizarAsync(oClienteEntity);
        }

        public ClienteViewModel ConsultarPorId(int id)
        {
            var oClienteEntity = _ClienteRepository.ObterPorIdAsync(id);
            var oClienteViewModel = _mapper.Map<ClienteViewModel>(oClienteEntity);
            return oClienteViewModel;
        }

        public void Inativar(int id)
        {
            _ClienteRepository.InativarAsync(id);
        }

        public int Incluir(ClienteViewModel clienteVM)
        {
            clienteVM.CPF = RetiraCaracterHelper.RetiraCaracteres(clienteVM.CPF);
            ExcecaoDominioHelper.Validar(!VerificaCPFHelper.ValidaCPF(clienteVM.CPF), "CPF Inválido!");

            var oClienteEntity = _mapper.Map<ClienteEntity>(clienteVM);
            oClienteEntity.DtCadastro = DateTime.Now;
            oClienteEntity.FlAtivo = true;
            _ClienteRepository.InserirAsync(oClienteEntity);
            return oClienteEntity.Id;
        }

        public IEnumerable<ClienteViewModel> Listar()
        {
            var lstClienteEntity = _ClienteRepository.Listar();
            var lstClienteViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(lstClienteEntity);
            return lstClienteViewModel;
        }
        public IEnumerable<ClienteViewModel> ListarUltimos20Ativos()
        {
            var lstClienteEntity = _ClienteRepository.ListarUltimos20Ativos();
            var lstClienteViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(lstClienteEntity);
            return lstClienteViewModel;
        }

        public IEnumerable<ClienteViewModel> ListarUltimos20()
        {
            var lstClienteEntity = _ClienteRepository.ListarUltimos20();
            var lstClienteViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(lstClienteEntity);
            return lstClienteViewModel;
        }

        public IEnumerable<ClienteViewModel> Consultar(string nome, string cpf, DateTime? dtNascimento)
        {
            var lstClienteEntity = _ClienteRepository.Consultar(nome, cpf, dtNascimento);
            var lstClienteViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(lstClienteEntity);
            return lstClienteViewModel;
        }

        public ClienteViewModel ConsultarPorCPF(string cpf)
        {
            var oClienteEntity = _ClienteRepository.ConsultarPorCPF(cpf);
            var oClienteViewModel = _mapper.Map<ClienteViewModel>(oClienteEntity);
            return oClienteViewModel;
        }
    }
}

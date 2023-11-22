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

        public async Task AtualizarAsync(ClienteViewModel oClienteViewModel)
        {
            var oClienteEntity = _mapper.Map<ClienteEntity>(oClienteViewModel);
            await _ClienteRepository.AtualizarAsync(oClienteEntity);
        }

        public async Task<ClienteViewModel> ObterPorIdAsync(int id)
        {
            var oClienteEntity = await _ClienteRepository.ObterPorIdAsync(id);
            var oClienteViewModel = _mapper.Map<ClienteViewModel>(oClienteEntity);
            return oClienteViewModel;
        }

        public async Task InativarAsync(int id)
        {
            await _ClienteRepository.InativarAsync(id);
        }

        public async Task<int> InserirAsync(ClienteViewModel clienteVM)
        {
            clienteVM.CPF = RetiraCaracterHelper.RetiraCaracteres(clienteVM.CPF);
            ExcecaoDominioHelper.Validar(!VerificaCPFHelper.ValidaCPF(clienteVM.CPF), "CPF Inválido!");

            var oClienteEntity = _mapper.Map<ClienteEntity>(clienteVM);
            oClienteEntity.DtCadastro = DateTime.Now;
            oClienteEntity.FlAtivo = true;
            var idRetorno = await _ClienteRepository.InserirRetornaIdAsync(oClienteEntity);
            return idRetorno;
        }

        public async Task<IEnumerable<ClienteViewModel>> ListarAsync()
        {
            var lstClienteEntity = await _ClienteRepository.ListarAsync();
            var lstClienteViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(lstClienteEntity);
            return lstClienteViewModel;
        }
        public async Task<IEnumerable<ClienteViewModel>> ListarUltimos20AtivosAsync()
        {
            var lstClienteEntity = await _ClienteRepository.ListarUltimos20AtivosAsync();
            var lstClienteViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(lstClienteEntity);
            return lstClienteViewModel;
        }

        public async Task<IEnumerable<ClienteViewModel>> Consultar(string nome, string cpf, DateTime? dtNascimento)
        {
            var lstClienteEntity = await _ClienteRepository.ConsultarAsync(nome, cpf, dtNascimento);
            var lstClienteViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(lstClienteEntity);
            return lstClienteViewModel;
        }

        public async Task<ClienteViewModel> BuscarPorCPFAsync(string cpf)
        {
            var oClienteEntity = await _ClienteRepository.BuscarCpfQueryAsync(cpf);
            var oClienteViewModel = _mapper.Map<ClienteViewModel>(oClienteEntity.FirstOrDefault());
            return oClienteViewModel;
        }
    }
}

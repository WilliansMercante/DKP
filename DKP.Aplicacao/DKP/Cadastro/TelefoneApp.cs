using AutoMapper;

using DKP.Aplicacao.DKP.Cadastro.Interfaces;
using DKP.Aplicacao.Mapping;
using DKP.Dominio.DKP.Cadastro.Entidades;
using DKP.Dominio.DKP.Cadastro.Repository;
using DKP.ViewModel.DKP;

namespace DKP.Aplicacao.DKP.Cadastro
{
    public sealed class TelefoneApp : ITelefoneApp
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

        public async Task AtualizarAsync(TelefoneViewModel oTelefoneViewModel)
        {
            var oTelefoneEntity = _mapper.Map<TelefoneEntity>(oTelefoneViewModel);
            await _TelefoneRepository.AtualizarAsync(oTelefoneEntity);
        }

        public async Task<TelefoneViewModel> ObterPorIdAsync(int id)
        {
            var oTelefoneEntity = await _TelefoneRepository.ObterPorIdAsync(id);
            var oTelefoneViewModel = _mapper.Map<TelefoneViewModel>(oTelefoneEntity);
            return oTelefoneViewModel;
        }

        public void InativarAsync(int id)
        {
            _TelefoneRepository.InativarAsync(id);
        }

        public async Task InserirAsync(TelefoneViewModel enderecoVM)
        {
            var oTelefoneEntity = _mapper.Map<TelefoneEntity>(enderecoVM);
            oTelefoneEntity.FlAtivo = true;
            oTelefoneEntity.DtCadastro = DateTime.Now;
            await _TelefoneRepository.InserirAsync(oTelefoneEntity);
        }

        public async Task<IEnumerable<TelefoneViewModel>> ListarAsync()
        {
            var lstTelefoneEntity = await _TelefoneRepository.ListarAsync();
            var lstTelefoneViewModel = _mapper.Map<IEnumerable<TelefoneViewModel>>(lstTelefoneEntity);
            return lstTelefoneViewModel;
        }

        public async Task<IEnumerable<TelefoneViewModel>> ListarPorClienteAsync(int IdCliente)
        {
            var lstTelefoneEntity = await _TelefoneRepository.ListarPorClienteAsync(IdCliente);
            var lstTelefoneViewModel = _mapper.Map<IEnumerable<TelefoneViewModel>>(lstTelefoneEntity);
            return lstTelefoneViewModel;
        }
    }

}

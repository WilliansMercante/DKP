﻿using AutoMapper;

using DKP.Aplicacao.DKP.Cadastro.Interfaces;
using DKP.Aplicacao.Mapping;
using DKP.Dominio.DKP.Cadastro.Repository;
using DKP.ViewModel.DKP;

namespace DKP.Aplicacao.DKP.Cadastro
{
    public sealed class TipoTelefoneApp : ITipoTelefoneApp
    {
        private readonly ITipoTelefoneRepository _tipoTelefoneRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        public TipoTelefoneApp
        (
            ITipoTelefoneRepository tipoTelefoneRepository

        )
        {
            _tipoTelefoneRepository = tipoTelefoneRepository;

        }

        public async Task<IEnumerable<TipoTelefoneViewModel>> ListarAsync()
        {
            var lstTipoTelefoneEntity = await _tipoTelefoneRepository.ListarAsync();
            var lstTipoTelefoneViewModel = _mapper.Map<IEnumerable<TipoTelefoneViewModel>>(lstTipoTelefoneEntity);
            return lstTipoTelefoneViewModel;
        }
    }

}

using DKP.Aplicacao.DKP.Cadastro;
using DKP.Aplicacao.DKP.Cadastro.Interfaces;
using DKP.Dominio.DKP.Cadastro.Repository;
using DKP.Infra.Repositories.DKP.Cadastro;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKP.IoC
{
    public static class InjectionDependencyCore
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            AddRepositories(services);
            AddApplication(services);
        }

        private static void AddApplication(IServiceCollection services)
        {
            services.AddScoped<IClienteApp, ClienteApp>();
            services.AddScoped<IEnderecoApp, EnderecoApp>();
            services.AddScoped<ITelefoneApp, TelefoneApp>();
            services.AddScoped<ITipoTelefoneApp, TipoTelefoneApp>();
            services.AddScoped<ITipoEnderecoApp, TipoEnderecoApp>();
        }

       

        private static void AddRepositories(IServiceCollection services)
        {
  
            #region Cadastro

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<ISexoRepository, SexoRepository>();
            services.AddScoped<ITipoTelefoneRepository, TipoTelefoneRepository>();
            services.AddScoped<ITipoEnderecoRepository, TipoEnderecoRepository>();

            #endregion

            services.AddScoped<IUnitOfWork<ProjetoPousadaContext>, UnitOfWork<ProjetoPousadaContext>>();
        }
    }

}

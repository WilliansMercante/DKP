using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace DKP.UI.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IConfiguration _configuration;
        protected IDataProtectionProvider _protectionProvider;

        public BaseController()
        {
        }

        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BaseController(IConfiguration configuration, IDataProtectionProvider protectionProvider)
        {
            _configuration = configuration;
            _protectionProvider = protectionProvider;
        }

        public enum TipoMensagem
        {
            Sucesso,
            Erro,
            Alerta,
            Informacao
        }

        public void ExibirMensagem(string mensagem, TipoMensagem tipoMensagem)
        {
            if (!string.IsNullOrEmpty(mensagem))
            {
                switch (tipoMensagem)
                {
                    case TipoMensagem.Sucesso:

                        TempData.Remove("Sucesso");
                        TempData.Add("Sucesso", mensagem);
                        break;

                    case TipoMensagem.Erro:

                        TempData.Remove("Erro");
                        TempData.Add("Erro", mensagem);
                        break;

                    case TipoMensagem.Alerta:

                        TempData.Remove("Alerta");
                        TempData.Add("Alerta", mensagem);
                        break;

                    case TipoMensagem.Informacao:

                        TempData.Remove("Informacao");
                        TempData.Add("Informacao", mensagem);
                        break;
                }
            }
        }
    }
}

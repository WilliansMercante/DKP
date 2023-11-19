using DKP.Aplicacao.DKP.Cadastro.Interfaces;
using DKP.UI.Web.Areas.DKP.ViewModels;
using DKP.UI.Web.Controllers;

using Microsoft.AspNetCore.Mvc;

namespace DKP.UI.Web.Areas.DKP.Controllers
{
    [Area("DKP")]
    public class ClienteController : BaseController
    {
        private readonly IClienteApp _clienteApp;
        //private readonly ITelefoneApp _telefoneApp;
        //private readonly IEnderecoApp _enderecoApp;
        //private readonly ITipoTelefoneApp _tipoTelefoneApp;
        //private readonly ITipoEnderecoApp _tipoEnderecoApp;


        public ClienteController
        (
            IClienteApp clienteApp
            //ITelefoneApp telefoneApp,
            //IEnderecoApp enderecoApp,
            //ITipoTelefoneApp tipoTelefoneApp,
            //ITipoEnderecoApp tipoEnderecoApp

        )
        {
            _clienteApp = clienteApp;
            //_telefoneApp = telefoneApp;
            //_enderecoApp = enderecoApp;
            //_tipoTelefoneApp = tipoTelefoneApp;
            //_tipoEnderecoApp = tipoEnderecoApp;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IndexViewModel indexVM = new IndexViewModel();

            try
            {
                indexVM.Clientes = await _clienteApp.ListarUltimos20Ativos();
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return View(indexVM);
        }

        [HttpGet]
        [Route("Pesquisar")]
        public JsonResult Pesquisar(string nome, string cpf, DateTime? dtNascimento)
        {

            try
            {
                var lstClientesVM = _clienteApp.Consultar(nome, cpf, dtNascimento);
                return Json(new { flSucesso = true, lstClientes = lstClientesVM });
            }
            catch (Exception ex)
            {
                return Json(new { flSucesso = false, mensagem = ex.Message });
            }
        }


        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}

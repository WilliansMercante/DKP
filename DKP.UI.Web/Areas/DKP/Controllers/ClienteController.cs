using DKP.Aplicacao.DKP.Cadastro.Interfaces;
using DKP.UI.Web.Areas.DKP.ViewModels;
using DKP.UI.Web.Controllers;
using DKP.ViewModel.DKP;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DKP.UI.Web.Areas.DKP.Controllers
{
    [Area("DKP")]
    public class ClienteController : BaseController
    {
        private readonly IClienteApp _clienteApp;
        private readonly ITipoTelefoneApp _tipoTelefoneApp;
        private readonly ITipoEnderecoApp _tipoEnderecoApp;

        public ClienteController
        (
            IClienteApp clienteApp,
            ITipoTelefoneApp tipoTelefoneApp,
            ITipoEnderecoApp tipoEnderecoApp

        )
        {
            _clienteApp = clienteApp;
            _tipoTelefoneApp = tipoTelefoneApp;
            _tipoEnderecoApp = tipoEnderecoApp;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IndexViewModel indexVM = new IndexViewModel();

            try
            {
                indexVM.Clientes = await _clienteApp.ListarUltimos20AtivosAsync();
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return View(indexVM);
        }

        [HttpGet]
        public async Task<JsonResult> Pesquisar(string nome, string cpf, DateTime? dtNascimento)
        {
            try
            {
                var lstClientesVM = await _clienteApp.Consultar(nome, cpf, dtNascimento);
                return Json(new { flSucesso = true, lstClientes = lstClientesVM });
            }
            catch (Exception ex)
            {
                return Json(new { flSucesso = false, mensagem = ex.Message });
            }
        }


        [HttpGet]
        public async Task<IActionResult> Cadastro()
        {
            CadastroViewModel cadastroVM = new CadastroViewModel();

            try
            {
                cadastroVM.LstTiposEndereco = new SelectList(await _tipoEnderecoApp.ListarAsync(), "Id", "Tipo").ToList();
                cadastroVM.LstTiposTelefone = new SelectList(await _tipoTelefoneApp.ListarAsync(), "Id", "Tipo").ToList();
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return View("Cadastro", cadastroVM);
        }

        [HttpGet]
        public async Task<JsonResult> PesquisarCPF(string cpf)
        {
            try
            {
                ClienteViewModel oClienteVM = await _clienteApp.BuscarPorCPFAsync(cpf);
                return Json(new { flSucesso = true, oCliente = oClienteVM });
            }
            catch (Exception ex)
            {
                return Json(new { flSucesso = false, mensagem = ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> Cadastro(ClienteViewModel clienteVM)
        {
            try
            {
                if (clienteVM.Id > 0)
                {
                    await _clienteApp.AtualizarAsync(clienteVM);
                    return Json(new { FlSucesso = true, Mensagem = "Dados alterados com sucesso!", IdCliente = clienteVM.Id, FlEditar = true });
                }

                else
                {
                    clienteVM.Id = await _clienteApp.InserirAsync(clienteVM);
                    return Json(new { FlSucesso = true, Mensagem = "Dados inseridos com sucesso, por favor continue o cadastro!", IdCliente = clienteVM.Id, FlEditar = false });
                }

            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            CadastroViewModel cadastroVM = new CadastroViewModel();

            try
            {
                cadastroVM.Cliente = await _clienteApp.ObterPorIdAsync(id);
                cadastroVM.LstTiposEndereco = new SelectList(await _tipoEnderecoApp.ListarAsync(), "Id", "Tipo").ToList();
                cadastroVM.LstTiposTelefone = new SelectList(await _tipoTelefoneApp.ListarAsync(), "Id", "Tipo").ToList();
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return View("Cadastro", cadastroVM);
        }
    }
}

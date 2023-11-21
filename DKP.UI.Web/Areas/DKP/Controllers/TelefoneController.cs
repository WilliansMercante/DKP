using DKP.Aplicacao.DKP.Cadastro.Interfaces;
using DKP.Dominio.Helpers;
using DKP.ViewModel.DKP;

using Microsoft.AspNetCore.Mvc;

namespace DKP.UI.Web.Areas.DKP.Controllers
{
    [Area("DKP")]
    public class TelefoneController : Controller
    {
        private readonly ITelefoneApp _telefoneApp;

        public TelefoneController
        (
            ITelefoneApp telefoneApp

        )
        {
            _telefoneApp = telefoneApp;
        }

        [Route("Cadastro")]
        [HttpPost]
        public async Task<JsonResult> Cadastro(TelefoneViewModel telefoneVM)
        {
            try
            {

                ExcecaoDominioHelper.Validar(telefoneVM.Numero == null || telefoneVM.DDD == null || telefoneVM.IdTipoTelefone == 0, "Telefone Inválido!");
                telefoneVM.Numero = RetiraCaracterHelper.RetiraCaracteres(telefoneVM.Numero);
                await _telefoneApp.InserirAsync(telefoneVM);

                return Json(new { FlSucesso = true, Mensagem = "Telefone inserido com sucesso" });

            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }

        [HttpGet]
        [Route("ListarPorCliente/{idCliente}")]
        public async Task<JsonResult> ListarPorCliente(int idCLiente)
        {
            try
            {

                ExcecaoDominioHelper.Validar(idCLiente == 0, "Sem parâmetro");
                var lstEnderecoVM = await _telefoneApp.ListarPorClienteAsync(idCLiente);

                return Json(new { FlSucesso = true, LstEndereco = lstEnderecoVM });

            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }
    }
}

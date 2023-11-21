using DKP.Aplicacao.DKP.Cadastro.Interfaces;
using DKP.Dominio.Helpers;
using DKP.ViewModel.DKP;

using Microsoft.AspNetCore.Mvc;

namespace DKP.UI.Web.Areas.DKP.Controllers
{
    [Area("DKP")]
    public class EnderecoController : Controller
    {

        private readonly IEnderecoApp _enderecoApp;

        public EnderecoController
        (
            IEnderecoApp enderecoApp
        )
        {
            _enderecoApp = enderecoApp;
        }


        [HttpGet]
        public async Task<JsonResult> ListarPorCliente(int idCLiente)
        {
            try
            {
                ExcecaoDominioHelper.Validar(idCLiente == 0, "Sem parâmetro");
                var lstEnderecoVM = await _enderecoApp.ListarPorCliente(idCLiente);

                return Json(new { FlSucesso = true, LstEndereco = lstEnderecoVM });

            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> Cadastro(EnderecoViewModel enderecoVM)
        {
            try
            {

                ExcecaoDominioHelper.Validar(enderecoVM.Rua == null || enderecoVM.Bairro == null || enderecoVM.Cep == null || enderecoVM.UF == null, "Endereco Inválido!");
                enderecoVM.Cep = RetiraCaracterHelper.RetiraCaracteres(enderecoVM.Cep);
                await _enderecoApp.IncluirAsync(enderecoVM);

                return Json(new { FlSucesso = true, Mensagem = "Endereço inserido com sucesso" });

            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }
    }
}

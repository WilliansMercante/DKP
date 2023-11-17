using DKP.ViewModel.DKP;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DKP.UI.Web.Areas.DKP.ViewModels
{
    public class CadastroViewModel
    {
        public ClienteViewModel Cliente { get; set; }

        public EnderecoViewModel Endereco { get; set; }
        public TelefoneViewModel Telefone { get; set; }
        public TipoEnderecoViewModel TipoEndereco { get; set; }
        public TipoTelefoneViewModel TipoTelefone { get; set; }
        public List<SelectListItem> LstTiposEndereco { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> LstTiposTelefone { get; set; } = new List<SelectListItem>();


    }
}

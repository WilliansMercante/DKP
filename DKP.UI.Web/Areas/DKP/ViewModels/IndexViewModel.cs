using DKP.ViewModel.DKP;

namespace DKP.UI.Web.Areas.DKP.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<ClienteViewModel> Clientes { get; set; }
        public ClienteViewModel Cliente { get; set; }
    }
}

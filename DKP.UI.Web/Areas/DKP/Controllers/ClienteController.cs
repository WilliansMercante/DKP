using Microsoft.AspNetCore.Mvc;

namespace DKP.UI.Web.Areas.DKP.Controllers
{
    [Area("DKP")]
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.Areas.CustomerArea.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

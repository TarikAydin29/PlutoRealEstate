using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.Areas.AdminArea.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

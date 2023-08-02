using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.Controllers
{
    public class AdminPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

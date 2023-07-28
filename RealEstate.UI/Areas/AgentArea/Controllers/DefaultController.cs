using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.Areas.AgentArea.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

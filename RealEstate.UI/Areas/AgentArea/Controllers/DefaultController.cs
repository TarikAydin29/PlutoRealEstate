using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.Areas.AgentArea.Controllers
{
    public class DefaultController : AgentBaseController
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index","Property","Agent");
        }
    }
}

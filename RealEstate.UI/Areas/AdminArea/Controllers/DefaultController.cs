using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.Areas.AdminArea.Controllers
{
    public class DefaultController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

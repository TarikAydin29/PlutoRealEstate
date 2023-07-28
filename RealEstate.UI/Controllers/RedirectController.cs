using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RealEstate.UI.Controllers
{
    public class RedirectController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity!.IsAuthenticated)
            {
                var role = User.FindFirstValue(ClaimTypes.Role);
                return Redirect($"/{role}/Default");
            }
            return View();
        }
    }
}

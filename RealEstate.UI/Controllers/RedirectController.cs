using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Entities.Entities;
using System.Security.Claims;

namespace RealEstate.UI.Controllers
{
    public class RedirectController : Controller
    {        
        public async Task<IActionResult> Index()
        {
            if (User.Identity!.IsAuthenticated)
            {              
                var role = User.FindFirstValue(ClaimTypes.Role);
                return Redirect($"/{role}Area/Default");
            }
            return View();
        }
    }
}

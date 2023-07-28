using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Entities.Entities;
using RealEstate.UI.Models;

namespace RealEstate.UI.Controllers
{
    public class ConfirmMailController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.username = TempData["Username"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ConfirmEmailVM vm)
        {
            var user = await userManager.FindByNameAsync(vm.Username);
            if (user.ConfirmCode == vm.ConfirmEmailCode)
            {
                user.EmailConfirmed = true;
                await userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}

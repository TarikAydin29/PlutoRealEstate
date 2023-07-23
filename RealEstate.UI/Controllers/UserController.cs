using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Entities.Entities;
using RealEstate.UI.Models;

namespace RealEstate.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public UserController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginVM vm)
        {
            var result = await signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, true);
            var user = await userManager.FindByNameAsync(vm.Username);
            
            if (result.Succeeded && user.EmailConfirmed == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (result.Succeeded && user.EmailConfirmed == false)
            {
                return RedirectToAction("Index", "ConfirmEmail");
            }
            return View();
        }
    }
}

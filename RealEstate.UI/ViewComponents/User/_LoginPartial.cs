using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstate.Entities.Entities;
using RealEstate.UI.Models;

namespace RealEstate.UI.ViewComponents.User
{
    public class _LoginPartial : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public _LoginPartial(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        //public async Task<IViewComponentResult> Invoke(LoginVM vm)
        //{
        //    var result = await signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, true);
        //    var user = await userManager.FindByNameAsync(vm.Username);

        //    if (result.Succeeded && user.EmailConfirmed == true)
        //    {
        //        return RedirectToActionResult("Index", "Admin");
        //    }
        //    else if (result.Succeeded && user.EmailConfirmed == false)
        //    {
        //        return RedirectToAction("Index", "ConfirmEmail");
        //    }
        //    return View();
        //}
    }
}

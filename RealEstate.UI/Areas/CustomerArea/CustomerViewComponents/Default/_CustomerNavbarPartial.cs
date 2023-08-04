using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Entities.Entities;
using System.Security.Claims;

namespace RealEstate.UI.Areas.CustomerArea.CustomerViewComponents.Default
{
    public class _CustomerNavbarPartial : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;

        public _CustomerNavbarPartial(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = UserClaimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);
            return View(user);
        }
    }
}


using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Entities.Entities;
using System.Security.Claims;

namespace RealEstate.UI.Areas.AgentArea.AgentViewComponents.Default
{
    public class _NavbarPartial : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;

        public _NavbarPartial(UserManager<AppUser> userManager)
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

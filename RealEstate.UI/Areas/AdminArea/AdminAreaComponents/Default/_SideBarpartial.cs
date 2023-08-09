using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Entities.Entities;
using System.Security.Claims;

namespace RealEstate.UI.Areas.AdminArea.AdminAreaComponents.Default
{
    public class _SideBarpartial : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;

        public _SideBarpartial(UserManager<AppUser> userManager)
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

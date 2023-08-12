using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.ViewComponents.Default
{
    public class _BannerPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

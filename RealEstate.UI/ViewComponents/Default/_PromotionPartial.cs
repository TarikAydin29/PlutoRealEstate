using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.ViewComponents.Default
{
    public class _PromotionPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

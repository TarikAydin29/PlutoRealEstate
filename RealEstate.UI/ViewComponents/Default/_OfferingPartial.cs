using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.ViewComponents.Default
{
    public class _OfferingPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

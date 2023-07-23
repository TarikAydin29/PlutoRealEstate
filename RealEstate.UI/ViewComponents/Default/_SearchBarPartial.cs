using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.ViewComponents.Default
{
    public class _SearchBarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

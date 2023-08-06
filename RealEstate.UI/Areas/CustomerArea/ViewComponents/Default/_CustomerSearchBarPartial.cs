using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.Areas.CustomerArea.ViewComponents.Default
{
    public class _CustomerSearchBarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

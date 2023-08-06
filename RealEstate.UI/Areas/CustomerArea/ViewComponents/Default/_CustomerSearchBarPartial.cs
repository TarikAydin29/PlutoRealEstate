using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate.DAL.Concrete;

namespace RealEstate.UI.Areas.CustomerArea.ViewComponents.Default
{
    public class _CustomerSearchBarPartial : ViewComponent
    {
        private readonly Context context;

        public _CustomerSearchBarPartial(Context context)
        {
            this.context = context;
        }
        public IViewComponentResult Invoke()
        {
            var cities = context.sehir.ToList();
            ViewBag.sehir = new SelectList(cities, "sehir_key", "sehir_title");
            return View();
        }
    }
}

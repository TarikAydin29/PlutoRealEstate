using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstate.BLL.Abstract;

namespace RealEstate.UI.ViewComponents.Default
{
    public class _BannerPartial : ViewComponent
    {
        private readonly IPropertyService propertyService;

        public _BannerPartial(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await propertyService.TGetAllAsync();
            return View(values.Take(3));
        }
    }
}

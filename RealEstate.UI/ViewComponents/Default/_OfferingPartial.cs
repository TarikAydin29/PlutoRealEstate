using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;

namespace RealEstate.UI.ViewComponents.Default
{
    public class _OfferingPartial : ViewComponent
    {
        private readonly IPropertyService propertyService;

        public _OfferingPartial(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var properties = propertyService.TGetAllAsync();
            return View(properties);
        }
    }
}

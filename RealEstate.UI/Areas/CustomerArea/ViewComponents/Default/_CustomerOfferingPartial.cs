using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;

namespace RealEstate.UI.Areas.CustomerArea.ViewComponents.Default
{
    public class _CustomerOfferingPartial : ViewComponent
    {
        private readonly IPropertyService propertyService;

        public _CustomerOfferingPartial(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var properties = await propertyService.TGetAllAsync();
            return View(properties.Take(6));
        }
    }
}

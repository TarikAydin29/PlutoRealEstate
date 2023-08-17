using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;

namespace RealEstate.UI.Areas.CustomerArea.ViewComponents.Default
{
    public class _PropertyDetailSimilarPropsCustomerPartial : ViewComponent
    {
        private readonly IPropertyService propertyService;

        public _PropertyDetailSimilarPropsCustomerPartial(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var properties = await propertyService.TGetAllAsync();
            return View(properties.OrderByDescending(x => x.Id).Take(3));
        }
    }
}

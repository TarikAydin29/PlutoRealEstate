using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;

namespace RealEstate.UI.Areas.CustomerArea.ViewComponents.Default
{
<<<<<<<< HEAD:RealEstate.UI/Areas/CustomerArea/ViewComponents/Default/_CustomerPropertyDetailSimilarPropsPartial.cs
    public class _CustomerPropertyDetailSimilarPropsPartial : ViewComponent
    {
        private readonly IPropertyService propertyService;

        public _CustomerPropertyDetailSimilarPropsPartial(IPropertyService propertyService)
========
    public class _PropertyDetailSimilarPropsCustomerPartial : ViewComponent
    {
        private readonly IPropertyService propertyService;

        public _PropertyDetailSimilarPropsCustomerPartial(IPropertyService propertyService)
>>>>>>>> origin/trk28:RealEstate.UI/Areas/CustomerArea/ViewComponents/Default/_PropertyDetailSimilarPropsCustomerPartial.cs
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

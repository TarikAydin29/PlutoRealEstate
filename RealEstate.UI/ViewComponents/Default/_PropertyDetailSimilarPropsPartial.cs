﻿using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;

namespace RealEstate.UI.ViewComponents.Default
{
    public class _PropertyDetailSimilarPropsPartial : ViewComponent
    {
        private readonly IPropertyService propertyService;

        public _PropertyDetailSimilarPropsPartial(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var properties = await propertyService.TGetAllAsync();
            return View(properties.OrderByDescending(x=>x.Id).Take(3));
        }
    }
}

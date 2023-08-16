using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities;
using System.Security.Claims;

namespace RealEstate.UI.Areas.CustomerArea.ViewComponents.Default
{
    public class _CustomerCommandPartial : ViewComponent
    {
        private readonly ITestimonialService testimonialService;

        public _CustomerCommandPartial(ITestimonialService testimonialService)
        {
            this.testimonialService = testimonialService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await testimonialService.TGetAllAsync();
            return View(values);
        }

    }
}

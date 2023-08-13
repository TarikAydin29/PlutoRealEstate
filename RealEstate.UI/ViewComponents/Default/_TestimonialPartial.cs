using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities;
using RealEstate.UI.Areas.AdminArea.Controllers;
using RealEstate.UI.Areas.AdminArea.Models.TestimonialVMs;

namespace RealEstate.UI.ViewComponents.Default
{

    public class _TestimonialPartial : ViewComponent
    {
        private readonly IMapper _mapper;
        private ITestimonialService _testimonialService;
        private readonly ILogger<AdminBaseController> _logger;

        public _TestimonialPartial(IMapper mapper, ITestimonialService testimonialService, ILogger<AdminBaseController> logger)
        {
            _mapper = mapper;
            _testimonialService = testimonialService;
            _logger = logger;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values =await _testimonialService.TGetAllAsync();
            return View(values);
        }

      
        //public  IViewComponentResult CreateTestimonial(CreateTestimonialVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Testimonial testimonial = _mapper.Map<CreateTestimonialVM, Testimonial>(model);
        //       _testimonialService.TInsertAsync(testimonial);
        //        return View("Index");
        //    }
        //    return View(model);
        //}

    }
}

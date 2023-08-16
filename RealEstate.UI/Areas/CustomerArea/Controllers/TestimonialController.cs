using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities;
using RealEstate.UI.Areas.AdminArea.Controllers;
using RealEstate.UI.Areas.AdminArea.Models.TestimonialVMs;

namespace RealEstate.UI.Areas.CustomerArea.Controllers
{
    public class TestimonialController : CustomerBaseController
    {
        private readonly IMapper _mapper;
        private ITestimonialService _testimonialService;
        private readonly ILogger<AdminBaseController> _logger;

        public TestimonialController(IMapper mapper, ITestimonialService testimonialService, ILogger<AdminBaseController> logger)
        {
            _mapper = mapper;
            _testimonialService = testimonialService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateTestimonial()
        {
            return View();
        }

      
        //[HttpPost]
        //public async Task<IActionResult> CreateTestimonial(CreateTestimonialVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Testimonial testimonial = _mapper.Map<CreateTestimonialVM, Testimonial>(model);
        //        await _testimonialService.TInsertAsync(testimonial);
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}
    }
}

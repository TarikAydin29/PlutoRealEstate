using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities; 
using RealEstate.UI.Areas.AdminArea.Models.TestimonialVMs;

namespace RealEstate.UI.Areas.AdminArea.Controllers
{
    public class TestimonialController : AdminBaseController
    {
        private readonly IMapper _mapper;
        private ITestimonialService _testimonialService;

        public TestimonialController(IMapper mapper, ITestimonialService testimonialService)
        {
            _mapper = mapper;
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: /AdminArea/Testimonial/AddTestimonial
        public IActionResult AddTestimonial()
        {
            return View();
        }

        // POST: /AdminArea/Testimonial/AddTestimonial
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialVM model)
        {
            if (ModelState.IsValid)
            {
                Testimonial testimonial = _mapper.Map<CreateTestimonialVM, Testimonial>(model);
                await _testimonialService.TInsertAsync(testimonial);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTestimonial(Guid id)
        {

            var value = await _testimonialService.TGetByIdAsync(id);
            _testimonialService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(Guid id)
        {
            var value = await _testimonialService.TGetByIdAsync(id);
            if (value == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<UpdateTestimonialVM>(value);
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTestimonial()
        {
            var value = await _testimonialService.TGetAllAsync();
            var valusemap = _mapper.Map<List<GettAllTestimonialVM>>(value);
            return View(valusemap);
        }
    }
}

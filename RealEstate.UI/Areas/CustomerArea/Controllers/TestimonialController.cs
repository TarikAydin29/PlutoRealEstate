using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities;
using RealEstate.UI.Areas.AdminArea.Controllers;
using RealEstate.UI.Areas.AdminArea.Models.TestimonialVMs;
using System.Security.Claims;

namespace RealEstate.UI.Areas.CustomerArea.Controllers
{
    public class TestimonialController : CustomerBaseController
    {
        private readonly IMapper _mapper;
        private ITestimonialService _testimonialService;
        private readonly ILogger<AdminBaseController> _logger;
        private readonly UserManager<AppUser> userManager;

        public TestimonialController(IMapper mapper, ITestimonialService testimonialService, ILogger<AdminBaseController> logger, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _testimonialService = testimonialService;
            _logger = logger;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}

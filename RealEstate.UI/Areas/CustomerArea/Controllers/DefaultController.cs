using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate.BLL.Abstract;
using RealEstate.DAL.Concrete;
using RealEstate.Entities.Entities;
using RealEstate.UI.Areas.AgentArea.Models;
using RealEstate.UI.Areas.CustomerArea.Models;
using System.Security.Claims;

namespace RealEstate.UI.Areas.CustomerArea.Controllers
{
    public class DefaultController : CustomerBaseController
    {
        private readonly Context _context;
        private readonly IPropertyService _propertyService;
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;

        public DefaultController(Context context, IPropertyService propertyService, IMapper mapper, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _propertyService = propertyService;
            _mapper = mapper;
            _signInManager = signInManager;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cities = _context.sehir.ToList();
            ViewBag.sehir = new SelectList(cities, "sehir_key", "sehir_title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CustomerListPropertyVM vm)
        {
            var city = _context.sehir.FirstOrDefault(x => x.sehir_key == Convert.ToInt32(vm.City));
            var county = _context.ilce.FirstOrDefault(x => x.ilce_key == Convert.ToInt32(vm.County));
            var district = _context.mahalle.FirstOrDefault(x => x.mahalle_key == Convert.ToInt32(vm.District));
            vm.City = city.sehir_title;
            vm.County = county.ilce_title;
            vm.District = district.mahalle_title;

            var property = _mapper.Map<Property>(vm);
            if (ModelState.IsValid)
            {
                await _propertyService.TInsertAsync(property);
                return RedirectToAction("Index");
            }

            return View(property);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }





        [HttpGet]
        public JsonResult GetIlce(int sehirKey)
        {
            var ilce = _context.ilce
                .Where(i => i.ilce_sehirkey == sehirKey)
                .Select(i => new { i.ilce_key, i.ilce_title })
                .ToList();
            return Json(ilce);
        }
        [HttpGet]
        public JsonResult GetMahalle(int ilceKey)
        {
            var mahalle = _context.mahalle
                .Where(i => i.mahalle_ilcekey == ilceKey)
                .Select(i => new { i.mahalle_key, i.mahalle_title })
                .ToList();
            return Json(mahalle);
        }
    }
}

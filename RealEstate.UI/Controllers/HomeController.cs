using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate.BLL.Abstract;
using RealEstate.DAL.Concrete;
using RealEstate.UI.Models;
using System.Diagnostics;

namespace RealEstate.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context context;
        private readonly ICategoryService categoryService;
        private readonly IPropertyStatusService propertyStatusService;
        private readonly IPropertyService propertyService;

        public HomeController(ILogger<HomeController> logger, Context context, ICategoryService categoryService, IPropertyStatusService propertyStatusService, IPropertyService propertyService)
        {
            _logger = logger;
            this.context = context;
            this.categoryService = categoryService;
            this.propertyStatusService = propertyStatusService;
            this.propertyService = propertyService;
        }

        public async Task<IActionResult> Index()
        {
            var cities = context.sehir.ToList();
            ViewBag.sehir = new SelectList(cities, "sehir_key", "sehir_title");
            var categories = await categoryService.TGetAllAsync();
            ViewBag.cats = new SelectList(categories, "Id", "Name");
            var propStatuses = await propertyStatusService.TGetAllAsync();
            ViewBag.stats = new SelectList(propStatuses, "Id", "Status");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchFilter([FromBody] SearchVM vm)
        {
            var props = await propertyService.TGetAllAsync();
            if (!string.IsNullOrEmpty(vm.sehir))
            {
                props = props.Where(x => x.City == vm.sehir).ToList();
            }
            if (!string.IsNullOrEmpty(vm.ilce))
            {
                props = props.Where(x => x.County == vm.ilce).ToList();
            }

            if (!string.IsNullOrEmpty(vm.mahalle))
            {
                props = props.Where(x => x.District == vm.mahalle).ToList();
            }

            if (vm.category != null)
            {
                props = props.Where(x => x.CategoryID == new Guid(vm.category)).ToList();
            }
            if (vm.status != null)
            {
                props = props.Where(x => x.PropertyStatusID == new Guid(vm.status)).ToList();
            }
            if (vm.minPrice != null)
            {
                props = props.Where(p => p.Price >= Convert.ToDecimal(vm.minPrice)).ToList();
            }
            if (vm.maxPrice != null)
            {
                props = props.Where(p => p.Price <= Convert.ToDecimal(vm.maxPrice)).ToList();
            }
            props = props.Where(p => p.BedroomCount >= Convert.ToInt32(vm.roomNumber)).ToList();

            return Json(props);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }







        [HttpGet]
        public JsonResult GetIlce(int sehirKey)
        {
            var ilce = context.ilce
                .Where(i => i.ilce_sehirkey == sehirKey)
                .Select(i => new { i.ilce_key, i.ilce_title })
                .ToList();
            return Json(ilce);
        }
        [HttpGet]
        public JsonResult GetMahalle(int ilceKey)
        {
            var mahalle = context.mahalle
                .Where(i => i.mahalle_ilcekey == ilceKey)
                .Select(i => new { i.mahalle_key, i.mahalle_title })
                .ToList();
            return Json(mahalle);
        }

    }
}
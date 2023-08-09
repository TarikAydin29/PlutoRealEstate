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

        public HomeController(ILogger<HomeController> logger, Context context, ICategoryService categoryService,IPropertyStatusService propertyStatusService)
        {
            _logger = logger;
            this.context = context;
            this.categoryService = categoryService;
            this.propertyStatusService = propertyStatusService;
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
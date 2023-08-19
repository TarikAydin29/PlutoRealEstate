using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate.BLL.Abstract;

namespace RealEstate.UI.Areas.CustomerArea.Controllers
{
    public class PropertyController : CustomerBaseController
    {
        private readonly ISehirService sehirService;
        private readonly IIlceService ılceService;
        private readonly IMahalleService mahalleService;
        private readonly ICategoryService categoryService;
        private readonly IPropertyStatusService propertyStatusService;
        private readonly IPropertyService propertyService;

        public PropertyController(ISehirService sehirService, IIlceService ılceService, IMahalleService mahalleService, ICategoryService categoryService, IPropertyStatusService propertyStatusService,IPropertyService propertyService)
        {
            this.sehirService = sehirService;
            this.ılceService = ılceService;
            this.mahalleService = mahalleService;
            this.categoryService = categoryService;
            this.propertyStatusService = propertyStatusService;
            this.propertyService = propertyService;
        }
        public async Task<IActionResult> Index()
        {
            var cities = sehirService.TGetSehirs();
            ViewBag.sehir = new SelectList(cities, "sehir_key", "sehir_title");
            var categories = await categoryService.TGetAllAsync();
            ViewBag.cats = new SelectList(categories, "Id", "Name");
            var propStatuses = await propertyStatusService.TGetAllAsync();
            ViewBag.stats = new SelectList(propStatuses, "Id", "Status");
            return View();
        }



        public async Task <IActionResult> GetAllProperties()
        {
            var props = await propertyService.TGetAllAsync();
            var jsonresult = JsonConvert.SerializeObject(props);
            return Json(jsonresult);
        }




        [HttpGet]
        public JsonResult GetIlce(int sehirKey)
        {
            var ilce = ılceService.TGetIlces()
                .Where(i => i.ilce_sehirkey == sehirKey)
                .Select(i => new { i.ilce_key, i.ilce_title })
                .ToList();
            return Json(ilce);
        }
        [HttpGet]
        public JsonResult GetMahalle(int ilceKey)
        {
            var mahalle = mahalleService.TGetMahalles()
                .Where(i => i.mahalle_ilcekey == ilceKey)
                .Select(i => new { i.mahalle_key, i.mahalle_title })
                .ToList();
            return Json(mahalle);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate.BLL.Abstract;
using RealEstate.DAL.Concrete;
using RealEstate.Entities.Entities;
using RealEstate.UI.Areas.AgentArea.Models;
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
        private readonly IAgentService agentService;
        private readonly IPropertyPhotoService propertyPhotoService;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger, Context context, ICategoryService categoryService, IPropertyStatusService propertyStatusService, IPropertyService propertyService, IAgentService agentService, IMapper mapper, IPropertyPhotoService propertyPhotoService)
        {
            _logger = logger;
            this.context = context;
            this.categoryService = categoryService;
            this.propertyStatusService = propertyStatusService;
            this.propertyService = propertyService;
            this.agentService = agentService;
            this.mapper = mapper;
            this.propertyPhotoService = propertyPhotoService;
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
                var city = context.sehir.FirstOrDefault(x => x.sehir_key == Convert.ToInt32(vm.sehir));
                vm.sehir = city.sehir_title;
                props = props.Where(x => x.City == vm.sehir).ToList();
            }
            if (!string.IsNullOrEmpty(vm.ilce))
            {
                var county = context.ilce.FirstOrDefault(x => x.ilce_key == Convert.ToInt32(vm.ilce));
                vm.ilce = county.ilce_title;
                props = props.Where(x => x.County == vm.ilce).ToList();
            }

            if (!string.IsNullOrEmpty(vm.mahalle))
            {
                var district = context.mahalle.FirstOrDefault(x => x.mahalle_key == Convert.ToInt32(vm.mahalle));
                vm.mahalle = district.mahalle_title;
                props = props.Where(x => x.District == vm.mahalle).ToList();
            }

            if (!string.IsNullOrEmpty(vm.category))
            {
                props = props.Where(x => x.CategoryID == new Guid(vm.category)).ToList();
            }
            if (!string.IsNullOrEmpty(vm.status))
            {
                props = props.Where(x => x.PropertyStatusID == new Guid(vm.status)).ToList();
            }
            if (!string.IsNullOrEmpty(vm.minPrice))
            {
                props = props.Where(p => p.Price >= Convert.ToDecimal(vm.minPrice)).ToList();
            }
            if (!string.IsNullOrEmpty(vm.maxPrice))
            {
                props = props.Where(p => p.Price <= Convert.ToDecimal(vm.maxPrice)).ToList();
            }
            props = props.Where(p => p.BedroomCount >= Convert.ToInt32(vm.roomNumber)).ToList();

            var value = JsonConvert.SerializeObject(props);

            return Json(value);
        }


        public async Task<IActionResult> PropertyDetails(Guid id)
        {
            var values = await propertyService.TGetByIdAsync(id);
            var agent = await agentService.TGetByIdAsync(values.AgentID);

            var mappedProps = mapper.Map<PropListVM>(values);
            mappedProps.Agent = agent;

            List<PropertyPhoto> imgs = propertyPhotoService.TGetByPropertyIdList(id).ToList();
            foreach (var item in imgs)
            {
                mappedProps.Photos.Add(item);
            }
            return View(mappedProps);
        }
        public async Task<IActionResult> PropertList()
        {
            var values = await propertyService.TGetAllAsync();
            return View(values);
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



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
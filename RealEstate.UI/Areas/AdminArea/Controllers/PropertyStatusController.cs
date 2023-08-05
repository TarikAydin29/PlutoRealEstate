using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities;
using RealEstate.UI.Areas.AdminArea.Models.CategoryVMs;
using RealEstate.UI.Areas.AdminArea.Models.PropertyStatusVMs;

namespace RealEstate.UI.Areas.AdminArea.Controllers
{
    public class PropertyStatusController : AdminBaseController
    {
        private readonly IMapper _mapper;
        private IPropertyStatusService _propertyStatusService;

        public PropertyStatusController(IMapper mapper, IPropertyStatusService propertyStatusService)
        {
            _mapper = mapper;
            _propertyStatusService = propertyStatusService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(CreatePropertyStatusVM vm)
        {
            var mappedStatus = _mapper.Map<PropertyStatus>(vm);
            await _propertyStatusService.TInsertAsync(mappedStatus);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPropertyStatus()
        {
            var property = await _propertyStatusService.TGetAllAsync();
            var propertyViewModels = _mapper.Map<List<GettAllPropertyStatusViewModel>>(property);
            return View(propertyViewModels);
        }
    }
}

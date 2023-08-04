using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities;
using RealEstate.UI.Areas.AdminArea.Models.CategoryVMs;
using RealEstate.UI.Areas.AdminArea.Models.PropertyStatusVMs;

namespace RealEstate.UI.Areas.AdminArea.Controllers
{
    public class PropertyStatusController : Controller
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

        [HttpGet]
        public async Task<IActionResult> GetAllPropertyStatus()
        {
            var property = await _propertyStatusService.TGetAllAsync();
            var propertyViewModels = _mapper.Map<List<GettAllPropertyStatusViewModel>>(property);
            return View(propertyViewModels);
        }
    }
}

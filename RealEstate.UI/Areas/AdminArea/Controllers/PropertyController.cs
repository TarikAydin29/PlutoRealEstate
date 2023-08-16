using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.UI.Areas.AgentArea.Models;

namespace RealEstate.UI.Areas.AdminArea.Controllers
{
    public class PropertyController : AdminBaseController
    {
        private readonly IPropertyService _propertyService;
        private readonly IMapper _mapper;

        public PropertyController(IPropertyService propertyService, IMapper mapper)
        {
            _propertyService = propertyService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProperty()
        {
            var property = await _propertyService.TGetAllAsync();
            var propertyViewModels = _mapper.Map<List<GetAllPropertyVms>>(property);
            return View(propertyViewModels);
        }
    }
}

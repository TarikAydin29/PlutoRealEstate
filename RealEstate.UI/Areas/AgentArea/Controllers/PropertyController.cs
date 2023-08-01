using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities;
using System.Security.Claims;

namespace RealEstate.UI.Areas.AgentArea.Controllers
{
    public class PropertyController : AgentBaseController
    {

        private readonly IPropertyService _propertyService;
        private readonly UserManager<AppUser> userManager;
        private readonly IAgentService agentService;
        private readonly IMapper mapper;

        public PropertyController(IPropertyService propertyService, UserManager<AppUser> userManager, IAgentService agentService,IMapper mapper)
        {
            _propertyService = propertyService;
            this.userManager = userManager;
            this.agentService = agentService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var userMail = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(userMail);
            var agent = agentService.TGetByEmail(user.Email);
            List<Property> properties = _propertyService.TGetByAgentIdList(agent.Id).ToList();
            return View(properties);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            Property property = await _propertyService.TGetByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Property property)
        {
            if (ModelState.IsValid)
            {
                await _propertyService.TInsertAsync(property);
                return RedirectToAction("Index");
            }

            return View(property);
        }

        public async Task<IActionResult> Update(Guid id)
        {
            Property property = await _propertyService.TGetByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, Property property)
        {
            if (id != property.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _propertyService.TUpdateAsync(property);
                return RedirectToAction("Index");
            }

            return View(property);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            Property property = await _propertyService.TGetByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Property property = await _propertyService.TGetByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            _propertyService.TDelete(property);
            return RedirectToAction("Index");
        }



    }
}

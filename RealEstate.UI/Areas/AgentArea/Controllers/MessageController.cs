using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities;
using RealEstate.UI.Areas.AgentArea.Models.MessageVMs;
using System.Security.Claims;

namespace RealEstate.UI.Areas.AgentArea.Controllers
{
    public class MessageController : AgentBaseController
    {
        private readonly IPropertyService propertyService;
        private readonly IMessageService messageService;
        private readonly UserManager<AppUser> userManager;
        private readonly IAgentService agentService;
        private readonly IMapper mapper;

        public MessageController(IPropertyService propertyService, IMessageService messageService, UserManager<AppUser> userManager, IAgentService agentService, IMapper mapper)
        {
            this.propertyService = propertyService;
            this.messageService = messageService;
            this.userManager = userManager;
            this.agentService = agentService;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var userMail = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(userMail);
            var agent = agentService.TGetByEmail(user.Email);
            var messages = messageService.TGetAllAsync().Result.Where(x => x.AgentId == agent.Id).ToList();
            var mappedMessages = mapper.Map<List<ListMessageVM>>(messages);
            foreach (var item in mappedMessages)
            {
                item.Property = await propertyService.TGetByIdAsync(item.PropertyId);
            }
            return View(mappedMessages);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var message = await messageService.TGetByIdAsync(id);
            messageService.TDelete(message);
            return RedirectToAction("Index");
        }

    }
}

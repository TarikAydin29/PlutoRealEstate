using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities;
using RealEstate.UI.Areas.AgentArea.Models.AgentVM;
using System.Security.Claims;

namespace RealEstate.UI.Areas.AgentArea.Controllers
{

    public class DefaultController : AgentBaseController
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IPropertyService propertyService;
        private readonly UserManager<AppUser> userManager;
        private readonly IAgentService agentService;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public DefaultController(SignInManager<AppUser> signInManager, IPropertyService propertyService, UserManager<AppUser> userManager, IAgentService agentService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this._signInManager = signInManager;
            this.propertyService = propertyService;
            this.userManager = userManager;
            this.agentService = agentService;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var userMail = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(userMail);
            var agent = agentService.TGetByEmail(user.Email);
            int activePropsC = propertyService.TGetByAgentIdList(agent.Id).Where(x => x.IsActive == true).ToList().Count;
            int inactivePropsC = propertyService.TGetByAgentIdList(agent.Id).Where(x => x.IsActive == false).ToList().Count;
            ViewBag.activePropCount = activePropsC;
            ViewBag.inactivePropCount = inactivePropsC;
            var activeProps = propertyService.TGetByAgentIdList(agent.Id).Where(x => x.IsActive == true).ToList().Take(5);
            return View(activeProps);
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var userMail = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(userMail);
            var agent = agentService.TGetByEmail(user.Email);
            var mappedAgent = mapper.Map<UpdateAgentVM>(agent);
            if (mappedAgent.ImageUrl != null)
                HttpContext.Session.SetString("image", mappedAgent.ImageUrl);

            return View(mappedAgent);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UpdateAgentVM vm, IFormFile image)
        {
            if (image == null)
            {
                vm.ImageUrl = HttpContext.Session.GetString("image");
            }
            else
            {
                vm.ImageUrl = ResimYukle(image);
            }
            var agent = mapper.Map<Agent>(vm);
            AppUser user = await UpdateIdentityUser(vm);

            await userManager.UpdateAsync(user);
            await agentService.TUpdateAsync(agent);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }





        private async Task<AppUser> UpdateIdentityUser(UpdateAgentVM vm)
        {
            var userMail = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(userMail);
            user.Name = vm.Name;
            user.Surname = vm.Surname;
            user.PhoneNumber = vm.PhoneNumber;
            user.Email = vm.Email;
            user.ImageUrl = vm.ImageUrl;
            return user;
        }

        private string ResimYukle(IFormFile image)
        {
            string ext = Path.GetExtension(image.FileName);
            string resimAd = Guid.NewGuid() + ext;
            string dosyaYolu = Path.Combine(webHostEnvironment.WebRootPath, "Images", "Uploads", resimAd);
            using (var stream = new FileStream(dosyaYolu, FileMode.Create))
            {
                image.CopyTo(stream);
            }
            return resimAd;
        }

        private void ResimKontrol(IFormFile image)
        {
            string[] izinVerilenler = { ".jpg", ".png", ".jpeg" };
            if (image != null)
            {
                string ext = Path.GetExtension(image.FileName);
                if (!izinVerilenler.Contains(ext))
                {
                    ModelState.AddModelError("image", "İzin verilen dosya uzantıları jpeg,jpg,png");
                }
                else if (image.Length > 1000 * 5000 * 1) // 5 MB tekabül ediyor
                {
                    ModelState.AddModelError("image", "İzin verilen resim boyutu 5 MB");
                }
            }
            else
            {
                ModelState.AddModelError("image", "Resim Zorunlu");
            }
        }
    }
}

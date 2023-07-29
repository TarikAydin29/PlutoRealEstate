using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities;
using RealEstate.UI.Areas.AdminArea.Models.AgentVMs;

namespace RealEstate.UI.Areas.AdminArea.Controllers
{
    public class AgentController : AdminBaseController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IAgentService agentService;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AgentController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IAgentService agentService, IMapper mapper,IWebHostEnvironment webHostEnvironment)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.agentService = agentService;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }






        [HttpGet]
        public IActionResult CreateAgent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAgent(CreateAgentVM vm,IFormFile image)
        {
            ResimKontrolleri(image);
            AppUser user = new AppUser()
            {
                Name = vm.Name,
                Surname = vm.Surname,
                Email = vm.Email,
                UserName = vm.Username,
                EmailConfirmed = true,
                PhoneNumber = vm.PhoneNumber,
                ImageUrl = ResimYukle(image)
            };
            if (vm.Password == vm.ConfirmPassword)
            {
                var result = await userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Agent");
                    vm.ImageUrl = user.ImageUrl;
                    var agent = mapper.Map<Agent>(vm);
                    await agentService.TInsertAsync(agent);
                    return RedirectToAction("Index", "Default","AdminArea");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View();
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

        private void ResimKontrolleri(IFormFile image)
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

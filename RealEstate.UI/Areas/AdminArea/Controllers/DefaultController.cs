using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Entities.Entities;
using RealEstate.UI.Areas.AdminArea.Models.AdminVMs;
using System.Security.Claims;

namespace RealEstate.UI.Areas.AdminArea.Controllers
{
    public class DefaultController : AdminBaseController
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly SignInManager<AppUser> signInManager;

        public DefaultController(IMapper mapper, UserManager<AppUser> userManager, IWebHostEnvironment webHostEnvironment,SignInManager<AppUser> signInManager)
        { 
            _mapper = mapper;
            _userManager = userManager;
            this.webHostEnvironment = webHostEnvironment;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AdminPhoto()
        {
            var userMail = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(userMail);

            var mappedAdmin = _mapper.Map<UpdateAdminVM>(user);

            if (mappedAdmin.ImageUrl != null)
            {
                HttpContext.Session.SetString("image", mappedAdmin.ImageUrl);
            }

            return View(mappedAdmin);
        }



        [HttpPost]
        public async Task<IActionResult> AdminPhoto(UpdateAdminVM vm, IFormFile image)
        {
            if (image == null)
            {
                vm.ImageUrl = HttpContext.Session.GetString("image");
            }
            else
            {
                vm.ImageUrl = UploadPhoto(image, "user_avatar_" + Guid.NewGuid().ToString() + ".jpg");
            }
            AppUser user = await UpdateIdentityUser(vm);

            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index");
        }
        private async Task<AppUser> UpdateIdentityUser(UpdateAdminVM vm)
        {
            var userMail = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(userMail);

            _mapper.Map(vm, user);

            return user;
        }
       
        private string UploadPhoto(IFormFile image, string uniqueFileName)
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

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync(); ;
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
    }
}

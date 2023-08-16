using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate.BLL.Abstract;
using RealEstate.DAL.Concrete;
using RealEstate.Entities.Entities;
using RealEstate.UI.Areas.AdminArea.Models.AdminVMs;
using RealEstate.UI.Areas.AgentArea.Models;
using RealEstate.UI.Areas.CustomerArea.Models;
using RealEstate.UI.Models;
using System.Security.Claims;

namespace RealEstate.UI.Areas.CustomerArea.Controllers
{
    public class DefaultController : CustomerBaseController
    {
        private readonly Context _context;
        private readonly ICategoryService _categoryService;
        private readonly IPropertyService _propertyService;
        private readonly IPropertyStatusService _propertyStatusService;
        private readonly IMapper _mapper;
        private readonly IAgentService _agentService;
        private readonly IPropertyPhotoService _propertyPhotoService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment webHostEnvironment;


        public DefaultController(Context context, IPropertyService propertyService, IMapper mapper, SignInManager<AppUser> signInManager, ICategoryService categoryService, IPropertyStatusService propertyStatusService, IAgentService agentService, IPropertyPhotoService propertyPhotoService, UserManager<AppUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _propertyService = propertyService;
            _mapper = mapper;
            _signInManager = signInManager;
            _categoryService = categoryService;
            _propertyStatusService = propertyStatusService;
            _agentService = agentService;
            _propertyPhotoService = propertyPhotoService;
            _userManager = userManager;
            this.webHostEnvironment = webHostEnvironment;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cities = _context.sehir.ToList();
            ViewBag.sehir = new SelectList(cities, "sehir_key", "sehir_title");
            var categories = await _categoryService.TGetAllAsync();
            ViewBag.cats = new SelectList(categories, "Id", "Name");
            var propStatuses = await _propertyStatusService.TGetAllAsync();
            ViewBag.stats = new SelectList(propStatuses, "Id", "Status");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchFilter([FromBody] CustomerListPropertyVM vm)
        {
            var props = await _propertyService.TGetAllAsync();
            if (!string.IsNullOrEmpty(vm.sehir))
            {
                var city = _context.sehir.FirstOrDefault(x => x.sehir_key == Convert.ToInt32(vm.sehir));
                vm.sehir = city.sehir_title;
                props = props.Where(x => x.City == vm.sehir).ToList();
            }
            if (!string.IsNullOrEmpty(vm.ilce))
            {
                var county = _context.ilce.FirstOrDefault(x => x.ilce_key == Convert.ToInt32(vm.ilce));
                vm.ilce = county.ilce_title;
                props = props.Where(x => x.County == vm.ilce).ToList();
            }

            if (!string.IsNullOrEmpty(vm.mahalle))
            {
                var district = _context.mahalle.FirstOrDefault(x => x.mahalle_key == Convert.ToInt32(vm.mahalle));
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
            var values = await _propertyService.TGetByIdAsync(id);
            var agent = await _agentService.TGetByIdAsync(values.AgentID);

            var mappedProps = _mapper.Map<PropListVM>(values);
            mappedProps.Agent = agent;

            List<PropertyPhoto> imgs = _propertyPhotoService.TGetByPropertyIdList(id).ToList();
            foreach (var item in imgs)
            {
                mappedProps.Photos.Add(item);
            }
            return View(mappedProps);
        }

        [HttpGet]
        public async Task<IActionResult> CustomerEditProfile()
        {
            var userMail = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(userMail);

            var mappedCustomerPhoto = _mapper.Map<CustomerEditProfileEditVM>(user);

            if (mappedCustomerPhoto.ImageUrl != null)
            {
                HttpContext.Session.SetString("image", mappedCustomerPhoto.ImageUrl);
            }

            return View(mappedCustomerPhoto);
        }



        [HttpPost]
        public async Task<IActionResult> CustomerEditProfile(CustomerEditProfileEditVM vm, IFormFile image)
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

        private async Task<AppUser> UpdateIdentityUser(CustomerEditProfileEditVM vm)
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
        public JsonResult GetIlce(int sehirKey)
        {
            var ilce = _context.ilce
                .Where(i => i.ilce_sehirkey == sehirKey)
                .Select(i => new { i.ilce_key, i.ilce_title })
                .ToList();
            return Json(ilce);
        }
        [HttpGet]
        public JsonResult GetMahalle(int ilceKey)
        {
            var mahalle = _context.mahalle
                .Where(i => i.mahalle_ilcekey == ilceKey)
                .Select(i => new { i.mahalle_key, i.mahalle_title })
                .ToList();
            return Json(mahalle);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
    }
}


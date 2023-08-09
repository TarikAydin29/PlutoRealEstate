using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealEstate.BLL.Abstract;
using RealEstate.DAL.Concrete;
using RealEstate.Entities.Entities;
using RealEstate.UI.Areas.AgentArea.Models;
using System.Security.Claims;

namespace RealEstate.UI.Areas.AgentArea.Controllers
{
    public class PropertyController : AgentBaseController
    {

        private readonly IPropertyService _propertyService;
        private readonly UserManager<AppUser> userManager;
        private readonly IAgentService agentService;
        private readonly IMapper mapper;
        private readonly Context context;
        private readonly ICategoryService categoryService;
        private readonly IPropertyStatusService propertyStatusService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IPropertyPhotoService propertyPhotoService;

        public PropertyController(IPropertyService propertyService, UserManager<AppUser> userManager, IAgentService agentService, IMapper mapper, Context context, ICategoryService categoryService, IPropertyStatusService propertyStatusService, IWebHostEnvironment webHostEnvironment, IPropertyPhotoService propertyPhotoService)
        {
            _propertyService = propertyService;
            this.userManager = userManager;
            this.agentService = agentService;
            this.mapper = mapper;
            this.context = context;
            this.categoryService = categoryService;
            this.propertyStatusService = propertyStatusService;
            this.webHostEnvironment = webHostEnvironment;
            this.propertyPhotoService = propertyPhotoService;
        }

        public async Task<IActionResult> Index()
        {
            var userMail = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(userMail);
            var agent = agentService.TGetByEmail(user.Email);
            List<Property> properties = _propertyService.TGetByAgentIdList(agent.Id).Where(x => x.IsActive == true).ToList();
            var mappedProps = mapper.Map<List<ListPropertyVM>>(properties);
            return View(mappedProps);
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


        public async Task<IActionResult> Create()
        {
            var cities = context.sehir.ToList();
            ViewBag.sehir = new SelectList(cities, "sehir_key", "sehir_title");
            var categories = await categoryService.TGetAllAsync();
            ViewBag.category = new SelectList(categories, "Id", "Name");
            var statuses = await propertyStatusService.TGetAllAsync();
            ViewBag.status = new SelectList(statuses, "Id", "Status");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreatePropertyVM vm, IFormFile image, List<IFormFile> images)
        {
            KeyToTitleCreate(vm);

            vm.ImageUrl = ResimYukle(image);
            var userMail = User.FindFirstValue(ClaimTypes.Email);

            var agent = agentService.TGetByEmail(userMail);
            vm.AgentID = agent.Id;

            var property = mapper.Map<Property>(vm);
            if (ModelState.IsValid)
            {
                await _propertyService.TInsertAsync(property);

                foreach (var file in images)
                {
                    var photoPath = ResimYukle(file);
                    var photo = new PropertyPhoto
                    {
                        PhotoPath = photoPath,
                        PropertyId = property.Id,
                        IsActive = true
                    };
                    await propertyPhotoService.TInsertAsync(photo);
                }
                return RedirectToAction("Index");
            }

            return View(property);
        }

       

        public async Task<IActionResult> Update(Guid id)
        {
            var cities = context.sehir.ToList();
            ViewBag.sehir = new SelectList(cities, "sehir_key", "sehir_title");
            var categories = await categoryService.TGetAllAsync();
            ViewBag.category = new SelectList(categories, "Id", "Name");
            var statuses = await propertyStatusService.TGetAllAsync();
            ViewBag.status = new SelectList(statuses, "Id", "Status");


            Property property = await _propertyService.TGetByIdAsync(id);

            if (property == null)
            {
                return NotFound();
            }
            var vm = mapper.Map<UpdatePropertyVM>(property);
            HttpContext.Session.SetString("image", vm.ImageUrl);

            TitleToKey(vm);

            List<PropertyPhoto> imgs = propertyPhotoService.TGetByPropertyIdList(id).ToList();
            foreach (var item in imgs)
            {
                vm.Photos.Add(item);
            }

            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdatePropertyVM vm,IFormFile? image, List<IFormFile> images)
        {
            if (image == null)
            {
                vm.ImageUrl = HttpContext.Session.GetString("image");
            }
            else
            {
                vm.ImageUrl = ResimYukle(image);
            }

            if (images.Count >0)
            {
                foreach (var file in images)
                {
                    var photoPath = ResimYukle(file);
                    var photo = new PropertyPhoto
                    {
                        PhotoPath = photoPath,
                        PropertyId = vm.Id,
                        IsActive = true
                    };
                    await propertyPhotoService.TInsertAsync(photo);
                }
            }
            KeyToTitleUpdate(vm);
            var property = mapper.Map<Property>(vm);
            if (ModelState.IsValid)
            {
                await _propertyService.TUpdateAsync(property);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            Property property = await _propertyService.TGetByIdAsync(id);
            property.IsActive = false;
            await _propertyService.TUpdateAsync(property);
            if (property == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
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

        private void TitleToKey(UpdatePropertyVM vm)
        {
            var city = context.sehir.FirstOrDefault(x => x.sehir_title == vm.City);
            var county = context.ilce.FirstOrDefault(x => x.ilce_title == vm.County);
            var district = context.mahalle.FirstOrDefault(x => x.mahalle_title == vm.District);
            vm.City = city.sehir_key.ToString();
            vm.County = county.ilce_key.ToString();
            vm.District = district.mahalle_key.ToString();
        }
        private void KeyToTitleUpdate(UpdatePropertyVM vm)
        {
            var city = context.sehir.FirstOrDefault(x => x.sehir_key == Convert.ToInt32(vm.City));
            var county = context.ilce.FirstOrDefault(x => x.ilce_key == Convert.ToInt32(vm.County));
            var district = context.mahalle.FirstOrDefault(x => x.mahalle_key == Convert.ToInt32(vm.District));
            vm.City = city.sehir_title;
            vm.County = county.ilce_title;
            vm.District = district.mahalle_title;
        }

        private void KeyToTitleCreate(CreatePropertyVM vm)
        {
            var city = context.sehir.FirstOrDefault(x => x.sehir_key == Convert.ToInt32(vm.City));
            var county = context.ilce.FirstOrDefault(x => x.ilce_key == Convert.ToInt32(vm.County));
            var district = context.mahalle.FirstOrDefault(x => x.mahalle_key == Convert.ToInt32(vm.District));
            vm.City = city.sehir_title;
            vm.County = county.ilce_title;
            vm.District = district.mahalle_title;
        }



        [HttpPost]
        public async Task<JsonResult> DeletePhoto(Guid id)
        {
            var photo = propertyPhotoService.TGetByIdAsync(id);
            if (photo != null)
            {
                var yoluSil = Path.Combine(webHostEnvironment.WebRootPath, "Images", "Uploads", photo.Result.PhotoPath);
                if (System.IO.File.Exists(yoluSil))
                {
                    System.IO.File.Delete(yoluSil);
                }
                propertyPhotoService.TDelete(photo.Result);
            }
            return Json(Ok());
        }
        public async Task<IActionResult> UploadPhotos([FromRoute] List<IFormFile> files, [FromRoute] Guid realEstateId)
        {
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images", "Uploads");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var photo = new PropertyPhoto
                    {
                        PhotoPath = "/Images/Uploads/" + uniqueFileName,
                        PropertyId = realEstateId
                    };

                    await propertyPhotoService.TInsertAsync(photo);
                }
            }
            return RedirectToAction("Index");
        }

    }
}

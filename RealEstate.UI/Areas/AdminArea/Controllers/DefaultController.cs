using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.UI.Areas.AdminArea.Models.AdminVMs;

namespace RealEstate.UI.Areas.AdminArea.Controllers
{
    public class DefaultController : AdminBaseController
    {
        private readonly IMapper _mapper;
        private readonly IAdminService _adminService;

        public DefaultController(IMapper mapper, IAdminService adminService)
        {
            _mapper = mapper;
            _adminService = adminService; 
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AdminPhoto()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AdminPhoto(Guid id, IFormFile photo)
        {
            var adminEntity = await _adminService.TGetByIdAsync(id);
            if (adminEntity == null)
            {
                return NotFound();
            }

            if (photo != null && photo.Length > 0)
            {
             
                if (!string.IsNullOrEmpty(adminEntity.ImageUrl))
                {
                    var existingFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", Path.GetFileName(adminEntity.ImageUrl));
                    if (System.IO.File.Exists(existingFilePath))
                    {
                        System.IO.File.Delete(existingFilePath);
                    }
                }

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);
                UploadPhoto(photo, uniqueFileName);

           
                adminEntity.ImageUrl = uniqueFileName;

          
                await _adminService.TUpdateAsync(adminEntity);
            }

            var viewModel = _mapper.Map<UpdateAdminVM>(adminEntity);


            return RedirectToAction("AdminPhoto", "Default");
        }



        private void UploadPhoto(IFormFile photo, string uniqueFileName)
        {
            if (photo != null && photo.Length > 0)
            {
                try
                {
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Uploads/");
                    var filePath = Path.Combine(uploadPath, uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(stream);
                    }
                    ViewBag.Message = "Photo uploaded successfully.";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "An error occurred: " + ex.Message;
                }
            }
            else
            {
                ViewBag.Message = "No photo selected.";
            }
        }


    }
}

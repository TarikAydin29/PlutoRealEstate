using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities;
using RealEstate.UI.Areas.AdminArea.Models.AgentVMs;
using RealEstate.UI.Areas.AdminArea.Models.CategoryVMs;

namespace RealEstate.UI.Areas.AdminArea.Controllers
{
    public class CategoryController : AdminBaseController
    {
        private readonly IMapper _mapper;
        private ICategoryService _categoryService;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
           _mapper = mapper;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(model);
                await _categoryService.TInsertAsync(category);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var category = await _categoryService.TGetAllAsync();
            var categoryViewModels = _mapper.Map<List<GettAllCategoryViewModel>>(category);
            return View(categoryViewModels);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities;
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
              
            }
            return RedirectToAction("GetAllCategory");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var category = await _categoryService.TGetAllAsync();
            var categoryViewModels = _mapper.Map<List<GettAllCategoryViewModel>>(category);
            return View(categoryViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var category = await _categoryService.TGetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryService.TDelete(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(Guid id)
        {
            var categoryStatus = await _categoryService.TGetByIdAsync(id);
            if (categoryStatus == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<UpdateCategoryStatusVM>(categoryStatus);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Guid id, UpdateCategoryStatusVM viewModel)
        {
            if (id != viewModel.Id)
            {

                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var existingCategory = await _categoryService.TGetByIdAsync(id);
                if (existingCategory == null)
                {
                    return NotFound();
                }
                existingCategory.Id = viewModel.Id;
                await _categoryService.TUpdateAsync(existingCategory);

                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities;

namespace RealEstate.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _categoryService.TGetAllAsync();
            return View(categories);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            Category category = await _categoryService.TGetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.TInsertAsync(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public async Task<IActionResult> Update(Guid id)
        {
            Category category = await _categoryService.TGetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Category category)
        {
            if (id != category.CategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _categoryService.TUpdateAsync(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            Category category = await _categoryService.TGetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
    }
}

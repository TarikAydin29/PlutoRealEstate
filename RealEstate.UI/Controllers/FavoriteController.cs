using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities;

namespace RealEstate.UI.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }


        public async Task<IActionResult> Index()
        {
            List<Favorite> favorites = await _favoriteService.TGetAllAsync();
            return View(favorites);
        }


        public async Task<IActionResult> Details(Guid id)
        {
            Favorite favorite = await _favoriteService.TGetByIdAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }

            return View(favorite);
        }

        public IActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        public async Task<IActionResult> Create(Favorite favorite)
        {
            if (ModelState.IsValid)
            {
                await _favoriteService.TInsertAsync(favorite);
                return RedirectToAction("Index");
            }

            return View(favorite);
        }


        public async Task<IActionResult> Update(Guid id)
        {
            Favorite favorite = await _favoriteService.TGetByIdAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }
            return View(favorite);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, Favorite favorite)
        {
            if (id != favorite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _favoriteService.TUpdateAsync(favorite);
                return RedirectToAction("Index");
            }

            return View(favorite);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            Favorite favorite = await _favoriteService.TGetByIdAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }

            return View(favorite);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Favorite favorite = await _favoriteService.TGetByIdAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }

            _favoriteService.TDelete(favorite);
            return RedirectToAction("Index");
        }
    }
}

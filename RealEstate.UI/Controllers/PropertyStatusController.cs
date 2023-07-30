using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities;

namespace RealEstate.UI.Controllers
{
    public class PropertyStatusController : Controller
    {
        private readonly IPropertyStatusService _propertyStatusService;

        public PropertyStatusController(IPropertyStatusService propertyStatusService)
        {
            _propertyStatusService = propertyStatusService;
        }

        public async Task<IActionResult> Index()
        {
            List<PropertyStatus> propertyStatuses = await _propertyStatusService.TGetAllAsync();
            return View(propertyStatuses);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            PropertyStatus propertyStatus = await _propertyStatusService.TGetByIdAsync(id);
            if (propertyStatus == null)
            {
                return NotFound();
            }

            return View(propertyStatus);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyStatus propertyStatus)
        {
            if (ModelState.IsValid)
            {
                await _propertyStatusService.TInsertAsync(propertyStatus);
                return RedirectToAction("Index");
            }

            return View(propertyStatus);
        }

        public async Task<IActionResult> Update(Guid id)
        {
            PropertyStatus propertyStatus = await _propertyStatusService.TGetByIdAsync(id);
            if (propertyStatus == null)
            {
                return NotFound();
            }

            return View(propertyStatus);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, PropertyStatus propertyStatus)
        {
            if (id != propertyStatus.PropertyStatusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _propertyStatusService.TUpdateAsync(propertyStatus);
                return RedirectToAction("Index");
            }

            return View(propertyStatus);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            PropertyStatus propertyStatus = await _propertyStatusService.TGetByIdAsync(id);
            if (propertyStatus == null)
            {
                return NotFound();
            }

            return View(propertyStatus);
        }

        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            PropertyStatus propertyStatus = await _propertyStatusService.TGetByIdAsync(id);
            if (propertyStatus == null)
            {
                return NotFound();
            }

            _propertyStatusService.TDelete(propertyStatus);
            return RedirectToAction("Index");
        }
    }
}

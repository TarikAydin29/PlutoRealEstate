using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public async Task<IActionResult> Index()
        {
            List<Property> properties = await _propertyService.TGetAllAsync();
            return View(properties);
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Property property)
        {
            if (ModelState.IsValid)
            {
                await _propertyService.TInsertAsync(property);
                return RedirectToAction("Index");
            }

            return View(property);
        }

        public async Task<IActionResult> Update(Guid id)
        {
            Property property = await _propertyService.TGetByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, Property property)
        {
            if (id != property.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _propertyService.TUpdateAsync(property);
                return RedirectToAction("Index");
            }

            return View(property);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            Property property = await _propertyService.TGetByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Property property = await _propertyService.TGetByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            _propertyService.TDelete(property);
            return RedirectToAction("Index");
        }
    }
}

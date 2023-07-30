using Microsoft.AspNetCore.Mvc;
using RealEstate.BLL.Abstract;
using RealEstate.Entities.Entities;

namespace RealEstate.UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            List<Customer> customers = await _customerService.TGetAllAsync();
            return View(customers);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            Customer customer = await _customerService.TGetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.TInsertAsync(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public async Task<IActionResult> Update(Guid id)
        {
            Customer customer = await _customerService.TGetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _customerService.TUpdateAsync(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            Customer customer = await _customerService.TGetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Customer customer = await _customerService.TGetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _customerService.TDelete(customer);
            return RedirectToAction("Index");
        }
    }
}

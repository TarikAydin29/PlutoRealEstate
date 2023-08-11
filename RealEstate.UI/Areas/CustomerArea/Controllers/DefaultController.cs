﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate.BLL.Abstract;
using RealEstate.DAL.Concrete;
using RealEstate.Entities.Entities;
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
        private readonly SignInManager<AppUser> _signInManager;

        public DefaultController(Context context, IPropertyService propertyService, IMapper mapper, SignInManager<AppUser> signInManager, ICategoryService categoryService, IPropertyStatusService propertyStatusService)
        {
            _context = context;
            _propertyService = propertyService;
            _mapper = mapper;
            _signInManager = signInManager;
            _categoryService = categoryService;
            _propertyStatusService = propertyStatusService;
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
                props = props.Where(x => x.City == vm.sehir).ToList();
            }
            if (!string.IsNullOrEmpty(vm.ilce))
            {
                props = props.Where(x => x.County == vm.ilce).ToList();
            }

            if (!string.IsNullOrEmpty(vm.mahalle))
            {
                props = props.Where(x => x.District == vm.mahalle).ToList();
            }

            if (vm.category != null)
            {
                props = props.Where(x => x.CategoryID == new Guid(vm.category)).ToList();
            }
            if (vm.status != null)
            {
                props = props.Where(x => x.PropertyStatusID == new Guid(vm.status)).ToList();
            }
            if (vm.minPrice != null)
            {
                props = props.Where(p => p.Price >= Convert.ToDecimal(vm.minPrice)).ToList();
            }
            if (vm.maxPrice != null)
            {
                props = props.Where(p => p.Price <= Convert.ToDecimal(vm.maxPrice)).ToList();
            }
            props = props.Where(p => p.BedroomCount >= Convert.ToInt32(vm.roomNumber)).ToList();

            return Json(props);
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

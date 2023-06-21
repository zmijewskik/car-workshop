﻿using CarWorkshopApplication.CarWorkshop;
using CarWorkshopApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshopMVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly ICarWorkshopService _carWorkshopService;

        public CarWorkshopController(ICarWorkshopService carWorkshopService)
        {
            _carWorkshopService = carWorkshopService;
        }

        public async Task<IActionResult> Index()
        {
            var carWorkshops = await _carWorkshopService.GetAll();
            return View(carWorkshops);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarWorkshopDto carWorkshop)
        {
            if (!ModelState.IsValid)
            {
                return View(carWorkshop);
            }
            await _carWorkshopService.Create(carWorkshop);
            return RedirectToAction(nameof(Index));
        }
    }
}

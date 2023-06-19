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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarWorkshopDomain.Entities.CarWorkshop carWorkshop)
        {
            await _carWorkshopService.Create(carWorkshop);
            return RedirectToAction(nameof(Create)); // TODO: refactor
        }
    }
}

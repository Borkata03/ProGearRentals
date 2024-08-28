using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Models.Home;
using ProGearRentals.Models;
using System.Diagnostics;


namespace ProGearRentals.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEquipmentService equipmentService;


        public HomeController(ILogger<HomeController> logger
            ,IEquipmentService _equipmentService)
        {
            _logger = logger;
            equipmentService = _equipmentService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await equipmentService.LastThreeEquipments();

            return View(model);
        }


        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
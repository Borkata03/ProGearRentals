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
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated == false)
            {
                return View();
            }

            return RedirectToAction(nameof(EquipmentController.All), "Equipment");
        }


        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if(statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace ProGearRentals.Areas.AdminArea.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}

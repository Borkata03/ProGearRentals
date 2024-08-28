using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProGearRentals.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
       
    }
}

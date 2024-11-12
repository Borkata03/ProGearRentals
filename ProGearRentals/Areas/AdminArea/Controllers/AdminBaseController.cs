using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ProGearRentals.Core.Constants.AdministratorConstants;

namespace ProGearRentals.Areas.AdminArea.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
     
    }
}

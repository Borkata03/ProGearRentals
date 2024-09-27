using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ProGearRentals.Core.Constants.RoleConstants;

namespace ProGearRentals.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
     
    }
}

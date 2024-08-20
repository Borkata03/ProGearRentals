using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProGearRentals.Core.Models.Agent;

namespace ProGearRentals.Controllers
{
    [Authorize]
    public class AgentController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Become()
		{
			var model = new BecomeAgentFormModel();
			return View(model);
		}

		[HttpPost]

		public async Task<IActionResult> Become(BecomeAgentFormModel model)
		{
			return RedirectToAction(nameof(EquipmentController.All), "Equipment");
		}

		


	}
}

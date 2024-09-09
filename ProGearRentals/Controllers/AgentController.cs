using Consul;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Models.Agent;
using ProGearRentals.Extensions;

namespace ProGearRentals.Controllers
{
   
    public class AgentController : BaseController
	{
		private readonly IAgentService agentservice;
		public AgentController(IAgentService _agentservice)
		{
			agentservice = _agentservice;
		}

		[HttpGet]
		public async Task<IActionResult> Become()
		{
			if (await agentservice.ExistByIdAsync(User.Id()))
			{
				return BadRequest();
			}
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

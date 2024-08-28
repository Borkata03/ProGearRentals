﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Models.Agent;

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
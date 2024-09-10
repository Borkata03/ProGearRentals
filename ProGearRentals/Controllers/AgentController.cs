using Consul;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProGearRentals.Attributes;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Models.Agent;
using System.Security.Claims;
using static ProGearRentals.Core.Constants.MessageConstants;

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
		[NotAnAgent]
		public IActionResult Become()
		{
			var model = new BecomeAgentFormModel();

			return View(model);

		}

		[HttpPost]
		[NotAnAgent]

		public async Task<IActionResult> Become(BecomeAgentFormModel model)
		{
			if (await agentservice.UserWithPhoneNumberExistAsync(model.PhoneNumber))
			{
				ModelState.AddModelError(nameof(model.PhoneNumber), phoneExists);
			}


			if (await agentservice.UserHasRentsAsync(User.Id()))
			{
				ModelState.AddModelError("Error", HasRents);
			}


			if (ModelState.IsValid == false)
			{
				return View(model);
			}

			await agentservice.CreateAsync(User.Id(),model.PhoneNumber);

			return RedirectToAction(nameof(EquipmentController.All), "Equipment");
		}

		


	}
}

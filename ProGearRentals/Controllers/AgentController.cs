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
        private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
            agentService = _agentService;
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
            if (await agentService.UserWithPhoneNumberExistAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), phoneExists);
            }

            if (await agentService.UserHasRentsAsync(User.Id()))
            {
                ModelState.AddModelError("Error", HasRents);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await agentService.CreateAsync(User.Id(), model.PhoneNumber);

            return RedirectToAction(nameof(EquipmentController.All), "Equipment");
        }
    }
}

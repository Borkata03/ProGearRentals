using Microsoft.AspNetCore.Mvc;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Models.Admin;
using ProGearRentals.Core.Models.Equipment;
using System.Security.Claims;

namespace ProGearRentals.Areas.AdminArea.Controllers
{
    public class EquipmentController : AdminBaseController
    {
        private readonly IAgentService agentService;
        private readonly IEquipmentService equipmentService;

        public EquipmentController(IAgentService _agentService,IEquipmentService _equipmentService)
        {
                agentService = _agentService;
                equipmentService = _equipmentService;
        }
        public  async Task<IActionResult> Mine()
        {
			IEnumerable<EquipmentServiceModel> myEquipments;

			var userId = User.Id();

			if (await agentService.ExistByIdAsync(userId))
			{
				int currentAgentId = await agentService.GetAgentIdAsync(userId) ?? 0;

				myEquipments = await equipmentService.AllEquipmentsByAgentId(currentAgentId);
			}
			else
			{
				myEquipments = await equipmentService.AllEquipmentsByUserId(userId);
			}

			return View(myEquipments);
		}

		[HttpGet]	
		public async Task<IActionResult> Approve()
		{
			var model = await equipmentService.GetUnApprovedAsync();
			
			return View(model);	
		}

		[HttpPost]
		public async Task<IActionResult> Approve(int equipmentId)
		{
			await equipmentService.ApproveEquipmentAsync(equipmentId);

			return RedirectToAction(nameof(Approve));	
		}
    }
}

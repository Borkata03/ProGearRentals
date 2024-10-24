using Consul;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProGearRentals.Attributes;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Services.Equipments;
using ProGearRentals.Core.Services;
using System.Security.Claims;
using ProGearRentals.Core.Models.Reservation;

namespace ProGearRentals.Controllers
{
    [Authorize]
    public class ReservationController : BaseController
    {
        private readonly IReservationService reservationService;
        private readonly IEquipmentService equipmentService;
        private readonly IAgentService agentService;

        public ReservationController(IReservationService _reservationService, IEquipmentService _equipmentService
            , IAgentService _agentService)
        {
                reservationService = _reservationService;
            equipmentService = _equipmentService;
            agentService = _agentService;
        }
        [HttpGet]
        [NotAnAgent]
        public async Task<IActionResult> Create(int id)
        {
            var model = await reservationService.GetFormModelForReservation(id);

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        [NotAnAgent]
        public async Task<IActionResult> Create(AddReservationFormViewModel model)
        {
            if (await equipmentService.ExistAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (await agentService.ExistByIdAsync(User.Id()) && User.IsAdmin() == false)

            {
                return Unauthorized();
            }

            if (await equipmentService.IsRentedAsync(model.Id))
            {
                return BadRequest();
            }

            await reservationService.CreateAsync(model, User.Id());

            await reservationService.RentAsync(model.Id, User.Id());


            return RedirectToAction(nameof(EquipmentController.Mine), "Equipment");

        }










    }
}

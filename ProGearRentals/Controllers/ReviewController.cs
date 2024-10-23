using Microsoft.AspNetCore.Mvc;
using ProGearRentals.Attributes;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Models.Review;
using System.Security.Claims;

namespace ProGearRentals.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly IEquipmentService equipmentService;
        private readonly IAgentService agentService;
        private readonly IReviewService reviewService;

        public ReviewController(IEquipmentService _equipmentservice,IAgentService _agentservice,IReviewService _reviewservice)
        {
               equipmentService = _equipmentservice;
               agentService = _agentservice;   
               reviewService = _reviewservice;    
        }
        [HttpGet]
        [NotAnAgent]
        public async Task<IActionResult> Add(int id)
        {
            if (await agentService.ExistByIdAsync(User.Id()))
            {
                return BadRequest();
            }

            if (!await equipmentService.IsRentedByUserWithIdAsync(id,User.Id()))
            {
                return BadRequest();
            }

            var model  = await reviewService.GetModelForReviewByIdAsync();

            return View(model);
        }

        [HttpPost]
        [NotAnAgent]
        public async Task<IActionResult> Add(AddReviewFormViewModel model)
        {
            if (await agentService.ExistByIdAsync(User.Id()))
            {
                return BadRequest();
            }

            if (!await equipmentService.IsRentedByUserWithIdAsync(model.Id,User.Id()))
            {
                return BadRequest();
            }

            await reviewService.CreateReviewAsync(model,User.Id());

            return RedirectToAction(nameof(EquipmentController.Mine), "Equipment");
        }

        [HttpGet]
        [NotAnAgent]
        public async Task<IActionResult> All(int id)
        {
            if (await agentService.ExistByIdAsync(User.Id()))
            {
                return BadRequest();
            }

            if (await equipmentService.IsRentedByUserWithIdAsync(id,User.Id()))
            {
                return BadRequest();
            }

            var model = await reviewService.GetAllReviewsAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);

        }
    }
}

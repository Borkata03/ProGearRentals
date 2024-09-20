using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProGearRentals.Attributes;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Exceptions;
using ProGearRentals.Core.Extensions;
using ProGearRentals.Core.Models.Equipment;
using System.Security.Claims;

namespace ProGearRentals.Controllers
{

    
    public class EquipmentController : BaseController
    {
        private readonly IEquipmentService equipmentService;
        private readonly IAgentService agentService;

        private readonly ILogger logger;

        public EquipmentController(IEquipmentService _equipmentService
            , IAgentService _agentService
            , ILogger<EquipmentController> _logger)
        {
            equipmentService = _equipmentService;
            agentService = _agentService;
            logger  = _logger;
        }

        [AllowAnonymous]

        [HttpGet] 
        public async Task<IActionResult> All([FromQuery]AllEquipmentsQueryModel query)
        {
            var model = await equipmentService.AllAsync(query.Category
                ,query.SearchItem
                ,query.Sorting
                ,query.CurrentPage
                ,query.EquipmentsPerPage);


            query.TotalEquipmentsCount = model.TotalEquipmentsCount;
             query.Equipments = model.Equipments;
            query.Categories = await equipmentService.AllCategoriesNames();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            IEnumerable<EquipmentServiceModel> myEquipments;

            var userId = User.Id();

            if (await agentService.ExistByIdAsync(userId))
            {
                int currentAgentId = await agentService.GetAgentIdAsync(userId) ?? 0;

                myEquipments =  await equipmentService.AllEquipmentsByAgentId(currentAgentId);
            }
            else
            {
                myEquipments = await equipmentService.AllEquipmentsByUserId(userId);
            }

            return View(myEquipments);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id,string info)
        {

            if (await equipmentService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

           
            var model = await equipmentService.EqipmentDetailsByIdAsync(id);

           /* if (info != model.GetInformation())
            {
                return BadRequest();
            }*/

            return View(model);
        }

        [HttpGet]
        [MustBeAgent]
        public async Task<IActionResult> Add()
        {
           
            var model = new EquipmentFormModel()
            {
                Categories = await equipmentService.AllCategoriesAsync()
            };
            return View(model);
        }

        [HttpPost]
        [MustBeAgent]
        public async Task<IActionResult> Add(EquipmentFormModel model)
        {
            if (await equipmentService.CategoryExistAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), " ");
            }
            if (ModelState.IsValid == false)
            {
                model.Categories = await equipmentService.AllCategoriesAsync();

                return View(model);
            }

            int? agentid = await agentService.GetAgentIdAsync(User.Id());

            int newEquipmentId = await equipmentService.CreateAsync(model, agentid ?? 0);
            
            return RedirectToAction(nameof(Details) , new {id = newEquipmentId});
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await equipmentService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (await equipmentService.HasAgentWithIdAsync(id,User.Id()) == false)
            {
                return Unauthorized();
            }

           
            var model = await equipmentService.GetEquipmentFormModelByIdAsync(id);

            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id ,EquipmentFormModel model)
        {
            if (await equipmentService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (await equipmentService.HasAgentWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            if (await equipmentService.CategoryExistAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await equipmentService.AllCategoriesAsync();

                return View(model);
            }

            await equipmentService.EditAsync(model, id);

            return RedirectToAction(nameof (Details) , new {id});  
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await equipmentService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (await equipmentService.HasAgentWithIdAsync(id,User.Id()) == false)
            {
                return Unauthorized();
            }

           
            var equipment = await equipmentService.EqipmentDetailsByIdAsync(id);

            var model = new EquipmentDetailsViewModel()
            {
                Id = equipment.Id,
                Title = equipment.Title,
                ImageUrl = equipment.ImageUrl,
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, EquipmentDetailsServiceModel model)
        {
            if (await equipmentService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (await equipmentService.HasAgentWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

           await equipmentService.DeleteAsync(model.Id);
            
            return RedirectToAction(nameof(All));

        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            if (await equipmentService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (await agentService.ExistByIdAsync(User.Id())
              )
            {
                return Unauthorized();
            }

            if (await equipmentService.IsRentedAsync(id))
            {
                return BadRequest();
            }

            await equipmentService.RentAsync(id, User.Id());

        

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if (await equipmentService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            try
            {
                await equipmentService.LeaveAsync(id, User.Id());

            }
            catch (UnauthorizedActionException ua)
            {
                logger.LogError(ua, "EquipmentController/Leave");

                return Unauthorized();
            }



            return RedirectToAction(nameof(All));
        }


    }
}
    
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProGearRentals.Attributes;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Models.Equipment;
using System.Security.Claims;

namespace ProGearRentals.Controllers
{

    
    public class EquipmentController : BaseController
    {
        private readonly IEquipmentService equipmentService;
        private readonly IAgentService agentService;

        public EquipmentController(IEquipmentService _equipmentService, IAgentService _agentService)
        {
            equipmentService = _equipmentService;
            agentService = _agentService;
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
        public async Task<IActionResult> Details(int id)
        {

            if (await equipmentService.ExistAsync(id) == false)
            {
                return BadRequest();
            }
            var model = await equipmentService.EqipmentDetailsByIdAsync(id);

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
            var model = new EquipmentFormModel();

            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id ,EquipmentFormModel model)
        {
            return RedirectToAction(nameof (Details) , new {id = 1});  
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new EquipmentDetailsServiceModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, EquipmentDetailsServiceModel model)
        {
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }


    }
}
    
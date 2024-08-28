using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProGearRentals.Core.Models.Equipment;

namespace ProGearRentals.Controllers
{

    
    public class EquipmentController : BaseController
    {

        [AllowAnonymous]
        [HttpGet] 
        public async Task<IActionResult> All()
        {
            var model = new AllEquipmentsQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var model = new AllEquipmentsQueryModel();

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Details()
        {

            var model = new EquipmentDetailsViewModel();
            return View(model); 
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EquipmentFormModel model)
        {
            return RedirectToAction(nameof(Details) , new {id = 1});
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
            var model = new EquipmentDetailsViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, EquipmentDetailsViewModel model)
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
    
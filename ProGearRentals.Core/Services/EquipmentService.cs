using Microsoft.EntityFrameworkCore;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Models.Equipment;
using ProGearRentals.Core.Models.Home;
using ProGearRentals.Infrastructure.Data.Common;
using ProGearRentals.Infrastructure.Data.Models;

namespace ProGearRentals.Core.Services.Equipments
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IRepository repository;

        public EquipmentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<EquipmentCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => new EquipmentCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                     
                }).ToListAsync();
        }

        public async Task<bool> CategoryExistAsync(int categoryId)
        {
           return await repository.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }
        public async Task<int> CreateAsync(EquipmentFormModel model,int agentId)
        {
            Equipment equipment = new Equipment()
            {
                Description = model.Description,
                AgentId = agentId,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl,
                Title = model.Title,
                PricePerMonth = model.PricePerMonth,
            };

            await repository.AddAsync(equipment);
            await repository.SaveChangesAsync();

            return equipment.Id;
        }



        public async Task<IEnumerable<EquipmentIndexModel>> LastThreeEquipmentsAsync()
        {
            return await repository
                .AllReadOnly<Infrastructure.Data.Models.Equipment>()
                .OrderByDescending(e => e.Id)
                .Take(3)
                .Select(e => new EquipmentIndexModel()
                {
                    Id = e.Id,
                    Imageurl = e.ImageUrl,
                    Title = e.Title,
                }).ToListAsync();
        }
    }
}

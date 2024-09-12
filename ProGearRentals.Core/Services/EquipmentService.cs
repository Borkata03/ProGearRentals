using Microsoft.EntityFrameworkCore;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Enumeration;
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

        public async Task<EquipmentQueryServiceModel> AllAsync(string? category = null,
            string? searchTerm = null,
            EquipmentSorting sorting = EquipmentSorting.Newest,
            int currentpage = 1,
            int equipmentPerPage = 1)
        {
            var equipmentsToShow = repository.AllReadOnly<Equipment>();

            if (category != null)
            {
                equipmentsToShow = equipmentsToShow.Where(h => h.Category.Name == category);
            }

            if(searchTerm != null)
            {
                string normalized = searchTerm.ToLower();
                equipmentsToShow = equipmentsToShow.Where(h => (
                h.Title.ToLower().Contains(normalized) ||
                h.Description.ToLower().Contains(normalized)));
            }

            equipmentsToShow = sorting switch
            {
                EquipmentSorting.Price => equipmentsToShow.OrderByDescending(h => h.PricePerMonth),

                EquipmentSorting.NotRentedFirst => equipmentsToShow.OrderBy(h => h.RenterId == null)
                .ThenByDescending(h => h.Id),
          
                _ => equipmentsToShow.
                OrderByDescending(h => h.Id)
            };

            var equipment = await equipmentsToShow
                .Skip((currentpage - 1) * equipmentPerPage)
                .Take(equipmentPerPage)
                .Select(p => new EquipmentServiceModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    ImageUrl = p.ImageUrl,
                    IsRented = p.RenterId != null,
                    PricePerMonth = p.PricePerMonth,

                }).ToListAsync();

            int totalEquipment = await equipmentsToShow.CountAsync();

            return new EquipmentQueryServiceModel()
            {
                Equipments = equipment,
                TotalEquipmentsCount = totalEquipment,
            };

        }
        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repository.AllReadOnly<Category>()
                 .Select(c => c.Name).Distinct().ToListAsync();
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

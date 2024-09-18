using Microsoft.EntityFrameworkCore;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Enumeration;
using ProGearRentals.Core.Models.Equipment;
using ProGearRentals.Core.Models.Home;
using ProGearRentals.Infrastructure.Data.Common;
using ProGearRentals.Infrastructure.Data.Models;
using System.Net.WebSockets;

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
                EquipmentSorting.Price => equipmentsToShow.OrderBy(h => h.PricePerMonth),

                EquipmentSorting.NotRentedFirst => equipmentsToShow.OrderBy(h => h.RenterId == null)
                .ThenByDescending(h => h.Id),
          
                _ => equipmentsToShow.
                OrderByDescending(h => h.Id)
            };

            var equipment = await equipmentsToShow
                .Skip((currentpage - 1) * equipmentPerPage)
                .Take(equipmentPerPage)
                .ProjectEquipment()
                .ToListAsync();

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

        public async Task<IEnumerable<EquipmentServiceModel>> AllEquipmentsByAgentId(int agentId)
        {
            return await repository.AllReadOnly<Equipment>()
                .Where(a => a.AgentId == agentId)
                .ProjectEquipment()
                .ToListAsync();
        }

        public async Task<IEnumerable<EquipmentServiceModel>> AllEquipmentsByUserId(string userId)
        {
            return await repository.AllReadOnly<Equipment>()
                .Where(u => u.RenterId == userId)
                .ProjectEquipment()
                .ToListAsync();   
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllReadOnly<Equipment>()
                .AnyAsync(e => e.Id == id);
        }

        public async Task<EquipmentDetailsServiceModel> EqipmentDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Equipment>().
                 Where(e => e.Id == id)
                 .Select(e => new EquipmentDetailsServiceModel()
                 {
                     Id=e.Id,
                     Agent = new Models.Agent.AgentServiceModel()
                     {
                         Email = e.Agent.User.Email,
                         PhoneNumber = e.Agent.PhoneNumber
                     },
                     Category = e.Category.Name,
                     Description = e.Description,   
                     ImageUrl = e.ImageUrl,
                     IsRented = e.RenterId != null,
                     PricePerMonth = e.PricePerMonth,
                     Title = e.Title,



                 }).FirstAsync();

        }

        public async Task EditAsync(EquipmentFormModel model, int equipmentId)
        {
            var equipment = await repository.GetByIdAsync<Equipment>(equipmentId);


            if (equipment != null)
            {
                equipment.Title = model.Title;
                equipment.Description = model.Description;
                equipment.ImageUrl = model.ImageUrl;
                equipment.PricePerMonth = model.PricePerMonth;
                equipment.CategoryId = model.CategoryId;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> HasAgentWithIdAsync(int equipmentId, string userId)
        {
            return await repository.AllReadOnly<Equipment>()
                .AnyAsync(h => h.Id == equipmentId && h.Agent.UserId == userId);
        }

        public async Task<EquipmentFormModel?> GetEquipmentFormModelByIdAsync(int id)
        {
            var equipment =  await repository.AllReadOnly<Equipment>()
                .Where(h => h.Id == id)
                .Select(h => new EquipmentFormModel()
                {
                    Description = h.Description,
                    CategoryId = h.CategoryId,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    Title = h.Title,

                }).FirstOrDefaultAsync();

            if (equipment != null)
            {
                equipment.Categories = await AllCategoriesAsync();
            }
            

            return equipment;
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync<Equipment>(id);
            await repository.SaveChangesAsync();

        }
    }
}

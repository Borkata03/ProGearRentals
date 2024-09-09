using Microsoft.EntityFrameworkCore;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Models.Home;
using ProGearRentals.Infrastructure.Data.Common;

namespace ProGearRentals.Core.Services.Equipment
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IRepository repository;

        public EquipmentService(IRepository _repository)
        {
            repository = _repository;
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

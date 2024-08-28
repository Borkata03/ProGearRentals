using Microsoft.EntityFrameworkCore;
using ProGearRentals.Core.Contracts.Equipment;
using ProGearRentals.Core.Models.Home;
using ProGearRentals.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Core.Services.Equipment
{
    public class EquipmentService  : IEquipmentService
    {
        private readonly IRepository repository;

        public EquipmentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<EquipmentIndexModel>> LastThreeEquipments()
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

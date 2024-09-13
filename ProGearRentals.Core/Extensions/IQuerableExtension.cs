using ProGearRentals.Core.Models.Equipment;
using ProGearRentals.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class IQuerableEquipmentExtension
    {
        public static IQueryable<EquipmentServiceModel> ProjectEquipment(this IQueryable<Equipment> equipments)
        {
            return equipments.Select(e => new EquipmentServiceModel
            {
                Id = e.Id,
                Title = e.Title,
                PricePerMonth = e.PricePerMonth,
                ImageUrl = e.ImageUrl,
                IsRented = e.RenterId != null,
            });
                


        
        }
    }
}

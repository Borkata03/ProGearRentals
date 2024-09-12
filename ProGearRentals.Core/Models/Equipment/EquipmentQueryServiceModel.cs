using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Core.Models.Equipment
{
    public class EquipmentQueryServiceModel
    {
        public int TotalEquipmentsCount { get; set; }

        public IEnumerable<EquipmentServiceModel> Equipments { get; set; } = new List<EquipmentServiceModel>();
    }
}

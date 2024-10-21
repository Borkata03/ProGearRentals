using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProGearRentals.Core.Models.Agent;

namespace ProGearRentals.Core.Models.Equipment
{
    public class EquipmentDetailsServiceModel : EquipmentServiceModel
    {
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public AgentServiceModel Agent { get; set; } = null!;
    }
}

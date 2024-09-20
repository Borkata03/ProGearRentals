using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Core.Contracts
{
    public interface IEquipmentModel
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}

using ProGearRentals.Core.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Core.Models.Equipment
{
    public class AllEquipmentsQueryModel
    {
        public int EquipmentsPerPage { get; } = 3;

        public string Category { get; init; } = null!;

        [Display(Name = "Search by text")]
        public string SearchItem { get; set; } = null!;

        public EquipmentSorting Sorting { get; set; }

        public int CurrentPage { get; init; } = 1;

        public int TotalEquipmentsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<EquipmentServiceModel> Equipments { get; set; } = new List<EquipmentServiceModel>();
    }
}

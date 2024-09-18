using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Core.Models.Equipment
{
	public class EquipmentDetailsViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
	}
}

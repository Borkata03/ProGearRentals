using ProGearRentals.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Core.Models.Reservation
{
    public class AddReservationFormViewModel
    {
        public int Id {  get; set; }

        [Required]
        public string StartDate { get; set; } = string.Empty;

        [Required]
        public string EndDate { get; set; } = string.Empty;

        [Required]
        public int EquipmentId {  get; set; }

        [Required]
        public string UserId {  get; set; } = string.Empty;

        public IEnumerable<ReservationViewModel> RentedDates { get; set; } = new List<ReservationViewModel>();
    }
}

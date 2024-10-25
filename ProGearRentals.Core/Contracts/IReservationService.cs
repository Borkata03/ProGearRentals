using ProGearRentals.Core.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Core.Contracts
{
    public interface IReservationService
    {
        Task<AddReservationFormViewModel?> GetFormModelForReservation(int id);

        Task CreateAsync(AddReservationFormViewModel model,string userId);

        Task RentAsync(int id, string userId);

        Task<ReservationViewModel?> GetModelForAvailableDates(int id);

     
    }
}

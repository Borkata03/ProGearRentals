using Microsoft.EntityFrameworkCore;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Models.Reservation;
using ProGearRentals.Infrastructure.Data.Common;
using ProGearRentals.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository repository;

        public ReservationService(IRepository _repository)
        {
                repository = _repository;
        }

        public async Task CreateAsync(AddReservationFormViewModel model, string userId)
        {
            DateTime start = DateTime.Parse(model.StartDate);
            DateTime end = DateTime.Parse(model.EndDate);   

            var reservation = new Reservation()
            {
                StartDate = start,
                EndDate = end,  
                EquipmentId = model.Id,    
                UserId = userId
            };

            await repository.AddAsync<Reservation>(reservation);    

            await repository.SaveChangesAsync();    

        }

        public async Task<AddReservationFormViewModel?> GetFormModelForReservation(int id)
        {
            
            return await repository.AllReadOnly<Equipment>()
                .Where(r => r.Id == id)
                .Select(r => new AddReservationFormViewModel
                {

                   EquipmentId = r.Id
                    
                }).FirstOrDefaultAsync();

        }
        public async Task RentAsync(int id, string userId)
        {
            var equipment = await repository.GetByIdAsync<Equipment>(id);

            if (equipment != null)
            {
                equipment.RenterId = userId;
                await repository.SaveChangesAsync();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Services;
using ProGearRentals.Infrastructure.Data.Common;
using ProGearRentals.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProGearRentals.Infrastructure.Data.Models;
using ProGearRentals.Core.Models.Reservation;

namespace ProGearRentals.Services.Tests
{
    public class ReservationUnitTests
    {
        private IRepository repository;
        private IReservationService reservationService;
        private ProGearRentalsDbContext dbContext;

        [SetUp]
        public void Setup()
        {

            var contextOption = new DbContextOptionsBuilder<ProGearRentalsDbContext>()
                .UseInMemoryDatabase("ProGearRentalsDb")
                .Options;

            dbContext = new ProGearRentalsDbContext(contextOption);


            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();


            repository = new Repository(dbContext);
            reservationService = new ReservationService(repository);
        }

        [TearDown]
        public void Teardown()
        {

            dbContext.Dispose();
        }

        [Test]
        public async Task CreateReservationAsyncShouldCreateReservation()
        {
            string userId = "testId";

            var equipment = new Equipment
            {
                Id = 6,
                Title = "hat"
            };

            await dbContext.AddAsync(equipment);
            await dbContext.SaveChangesAsync();

            var model = new AddReservationFormViewModel
            {
                Id = equipment.Id,
                StartDate = "2022-10-22",
                EndDate = "2022-10-26",
                UserId = userId
            };

           await reservationService.CreateAsync(model, userId);
           await dbContext.SaveChangesAsync();  

           var reservation = await dbContext.Reservations.FirstOrDefaultAsync(r => r.EquipmentId == equipment.Id && r.UserId == userId);

            Assert.That(reservation, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(reservation.UserId, Is.EqualTo(userId));
                Assert.That(reservation.EquipmentId, Is.EqualTo(equipment.Id), "EquipmentId should match the provided equipment ID.");
                Assert.That(reservation.StartDate, Is.EqualTo(DateTime.Parse("2022-10-22")), "StartDate should match the provided start date.");
                Assert.That(reservation.EndDate, Is.EqualTo(DateTime.Parse("2022-10-26")), "EndDate should match the provided end date.");
            });
        }

        [Test]
        public async Task GetFormModelForReseravtaionShouldReturnModelIfExists()
        {
            var equipment = new Equipment
            {
                Id = 4,
                Title = "Jacket"
            };

            await dbContext.Equipments.AddAsync(equipment); 
            await dbContext.SaveChangesAsync();


            var result = await reservationService.GetFormModelForReservation(equipment.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.EquipmentId, Is.EqualTo(equipment.Id));

        }

        [Test]

        public async Task GetRentedDateShouldReturnRentedDates()
        {
            var equipment = new Equipment
            {
                Id = 4,
                Title = "Snowboard"
            };
            await dbContext.Equipments.AddAsync(equipment);
            await dbContext.SaveChangesAsync();

            var reservation = new Reservation
            {

                StartDate = DateTime.Parse("2022-10-22"),
                EndDate = DateTime.Parse("2022-10-26"),
                EquipmentId = equipment.Id,
            };

            dbContext.Reservations.Add(reservation);
            await dbContext.SaveChangesAsync();

            var renteddates = await reservationService.GetRentedDates(equipment.Id);

            Assert.That(renteddates, Is.Not.Null);  
            Assert.That(renteddates.Count, Is.EqualTo(1));
          


        }

        [Test]

        public async Task RentShouldMakeReservation()
        {
            string userId = "testId";

            var equipment = new Equipment
            {
                Id = 4,
                Title = "Snowboard"
            };
            await dbContext.Equipments.AddAsync(equipment);
            await dbContext.SaveChangesAsync();

            var reservation = new Reservation
            {
              
                StartDate = DateTime.Parse("2024-11-10"),
                EndDate = DateTime.Parse("2024-11-15"),
                EquipmentId = 4
            };
            dbContext.Reservations.Add(reservation);
            await dbContext.SaveChangesAsync();

            var updatedReservation = await dbContext.Reservations.FirstOrDefaultAsync(r => r.EquipmentId == equipment.Id);
            

            await reservationService.RentAsync(equipment.Id, userId);

            Assert.That(reservation.UserId, Is.EqualTo(userId));
        }

        [Test]
        public async Task RentedDates_ReturnsTrue_WhenDatesOverlap()
        {
            
            var equipmentId = 1;
            var reservation = new Reservation
            {
                EquipmentId = equipmentId,
                StartDate = DateTime.Parse("2024-11-10"),
                EndDate = DateTime.Parse("2024-11-15")
            };
            dbContext.Reservations.Add(reservation);
            await dbContext.SaveChangesAsync();

       
            bool result = await reservationService.RentedDates(equipmentId, DateTime.Parse("2024-11-12"), DateTime.Parse("2024-11-14"));

          
            Assert.That(result, Is.True, "Method should return true for overlapping dates.");
        }

        [Test]
        public async Task RentedDatesReturnsFalseWhenDatesDoNotOverlap()
        {
           
            var equipmentId = 1;
            var reservation = new Reservation
            {
                EquipmentId = equipmentId,
                StartDate = DateTime.Parse("2024-11-10"),
                EndDate = DateTime.Parse("2024-11-15")
            };
            dbContext.Reservations.Add(reservation);
            await dbContext.SaveChangesAsync();

            bool result = await reservationService.RentedDates(equipmentId, DateTime.Parse("2024-11-16"), DateTime.Parse("2024-11-20"));

            Assert.That(result, Is.False, "Method should return false for non-overlapping dates.");
        }

    }

}

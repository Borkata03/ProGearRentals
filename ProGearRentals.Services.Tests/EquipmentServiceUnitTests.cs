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
using ProGearRentals.Core.Services.Equipments;
using ProGearRentals.Infrastructure.Data.Models;
using ProGearRentals.Core.Models.Equipment;
using ProGearRentals.Core.Exceptions;

namespace ProGearRentals.Services.Tests
{
    public class EquipmentServiceUnitTests
    {
        private IRepository repository;
        private IEquipmentService equipmentService;
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
            equipmentService = new EquipmentService(repository);
        }

        [TearDown]
        public void Teardown()
        {
            dbContext.Dispose();
        }

        [Test]  
        public async Task GetAllCategoriesNamesShouldReturnAllCategories()
        {
            var category1 = new Category { Id = 6, Name = "WinterEquipment" };
            var category2 = new Category { Id = 7, Name = "WaterEquipment" };
            var category3 = new Category { Id = 8, Name = "SummerEquipment" }; 

            dbContext.Categories.AddRange(category1, category2, category3);
            await dbContext.SaveChangesAsync();

         
            var categoryNames = await equipmentService.AllCategoriesNames();


            Assert.That(categoryNames, Is.Not.Null);
            Assert.That(categoryNames, Contains.Item("WinterEquipment"));
            Assert.That(categoryNames, Contains.Item("WaterEquipment"));

        }

        [Test]
        public async Task AllCategoriesAsync()
        {
            var category1 = new Category { Id = 6, Name = "WinterEquipment" };
            var category2 = new Category { Id = 7, Name = "WaterEquipment" };
            var category3 = new Category { Id = 8, Name = "SummerEquipment" };

            dbContext.Categories.AddRange(category1, category2, category3);
            await dbContext.SaveChangesAsync();


            var categories = await equipmentService.AllCategoriesAsync();


            Assert.That(categories, Is.Not.Null);
            Assert.That(categories, Has.Exactly(1).Matches<EquipmentCategoryServiceModel>(c => c.Id == 7 && c.Name == "WaterEquipment"));
            Assert.That(categories, Has.Exactly(1).Matches<EquipmentCategoryServiceModel>(c => c.Id == 8 && c.Name == "SummerEquipment"));
        }

        [Test]
        public async Task CategoryExistShouldReturnIfCategoryExists()
        {
            var category = new Category { Id = 6, Name = "WinterEquipment" };

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            var categoryResult = await equipmentService.CategoryExistAsync(category.Id);

            Assert.That(categoryResult, Is.True);

        }

        [Test]
        public async Task CategoryExistShouldReturnFalseBecauseCategoryDoesNotExist()
        {
           
            var categoryResult = await equipmentService.CategoryExistAsync(8);

            Assert.That(categoryResult, Is.False);

        }

        [Test]

        public async Task CreateAsyncShouldCreateNewEquipment()
        {
            var model = new EquipmentFormModel
            {
                Description = "That is very good",
                CategoryId = 3,
                ImageUrl = "Image",
                Title = "Shoes",
                PricePerMonth = 50.00m
            };
            int agentId = 1;

            
            int equipmentId = await equipmentService.CreateAsync(model, agentId);

          
            var equipment = await dbContext.Equipments.FindAsync(equipmentId);
            Assert.That(equipment, Is.Not.Null, "Equipment was not added to the database.");
            Assert.Multiple(() =>
            {
                Assert.That(equipment.Description, Is.EqualTo(model.Description));
                Assert.That(equipment.AgentId, Is.EqualTo(agentId));
                Assert.That(equipment.CategoryId, Is.EqualTo(model.CategoryId));
                Assert.That(equipment.ImageUrl, Is.EqualTo(model.ImageUrl));
                Assert.That(equipment.Title, Is.EqualTo(model.Title));
                Assert.That(equipment.PricePerMonth, Is.EqualTo(model.PricePerMonth));
            });
        }

        [Test]

        public async Task AllEquipmentsByAgentId()
        {
            int agentId = 3;

            var equipment = new Equipment()
            {
                AgentId = agentId,
            };

            await dbContext.Equipments.AddAsync(equipment); 

            await dbContext.SaveChangesAsync(); 


            var equipmentsByAgent = await equipmentService.AllEquipmentsByAgentId(agentId);

            Assert.That(equipmentsByAgent, Is.Not.Null);
            
        }

        [Test]
        public async Task GetAllEquipmentsByUserId_ShouldReturnEquipmentsForTheUser()
        {
            string userId = "testId";

            var reservation = new Reservation()
            {
                UserId = userId,
            };

            await dbContext.Reservations.AddAsync(reservation);

            await dbContext.SaveChangesAsync();

            var equipmentsByAgent = await equipmentService.AllEquipmentsByUserId(userId);

            Assert.That(equipmentsByAgent, Is.Not.Null);
        }


        [Test]
        public async Task ExistAsyncShouldReturnTrueIfEquipmentExists()
        {
            var equipment = new Equipment()
            {
                Id = 5,
                Description = "That is very good",
                CategoryId = 3,
                ImageUrl = "Image",
                Title = "Shoes",
                PricePerMonth = 50.00m
            };


            await dbContext.Equipments.AddAsync(equipment);
            await dbContext.SaveChangesAsync();

       

            var existsEquipment = await equipmentService.ExistAsync(equipment.Id);

            Assert.That(existsEquipment, Is.True);    
        }

        [Test]
        public async Task ExistAsyncShouldFalseIfEquipmentDoesNotExist()
        {
            var equipment = new Equipment()
            {
                Id = 5,
                Description = "That is very good",
                CategoryId = 3,
                ImageUrl = "Image",
                Title = "Shoes",
                PricePerMonth = 50.00m
            };

            await dbContext.Equipments.AddAsync(equipment);
            await dbContext.SaveChangesAsync();



            var existsEquipment = await equipmentService.ExistAsync(6);

            Assert.That(existsEquipment, Is.False);
        }

        [Test]
        public async Task EditAsync_ShouldUpdateEquipment_WhenEquipmentExists()
        {
            
            var equipment = new Equipment
            {
                Id = 5,
                Title = "Old Title",
                Description = "Old Description",
                ImageUrl = "old_image.jpg",
                PricePerMonth = 100.00m,
                CategoryId = 1
            };

            await dbContext.Equipments.AddAsync(equipment);
            await dbContext.SaveChangesAsync();

            var model = new EquipmentFormModel
            {
                Title = "New Title",
                Description = "New Description",
                ImageUrl = "new_image.jpg",
                PricePerMonth = 150.00m,
                CategoryId = 2
            };

        
            await equipmentService.EditAsync(model, equipment.Id);

         
            var updatedEquipment = await dbContext.Equipments.FindAsync(equipment.Id);

            Assert.That(updatedEquipment, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(updatedEquipment.Title, Is.EqualTo("New Title"));
                Assert.That(updatedEquipment.Description, Is.EqualTo("New Description"));
                Assert.That(updatedEquipment.ImageUrl, Is.EqualTo("new_image.jpg"));
                Assert.That(updatedEquipment.PricePerMonth, Is.EqualTo(150.00m));
                Assert.That(updatedEquipment.CategoryId, Is.EqualTo(2));
            });
        }
        [Test]
        public async Task HasAgentWithIdAsync_ShouldReturnTrue_WhenAgentWithUserIdExists()
        {
         
            var agent = new Agent
            {
                Id = 5,
                UserId = "TestUserId"
            };

            var equipment = new Equipment
            {
                Id = 5,
                Agent = agent,
                AgentId = agent.Id
            };

            await dbContext.Agents.AddAsync(agent);
            await dbContext.Equipments.AddAsync(equipment);
            await dbContext.SaveChangesAsync();

            
            var result = await equipmentService.HasAgentWithIdAsync(5, "TestUserId");

            
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task HasAgentWithIdAsync_ShouldReturnFalse_WhenAgentWithUserIdDoesNotExist()
        {
           
            var agent = new Agent
            {
                Id = 5,
                UserId = "DifferentUserId"
            };

            var equipment = new Equipment
            {
                Id = 5,
                Agent = agent,
                AgentId = agent.Id
            };

            await dbContext.Agents.AddAsync(agent);
            await dbContext.Equipments.AddAsync(equipment);
            await dbContext.SaveChangesAsync();

          
            var result = await equipmentService.HasAgentWithIdAsync(5, "NonMatchingUserId");

            
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task HasAgentWithIdAsync_ShouldReturnFalse_WhenEquipmentDoesNotExist()
        {
            
            var result = await equipmentService.HasAgentWithIdAsync(999, "TestUserId"); 

            
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetEquipmentFormModelByIdAsync_ShouldReturnEquipmentFormModel_WhenEquipmentExists()
        {
            
            var category1 = new Category
            {
                Id = 7,
                Name = "WinterEquipment"
            };

            var category2 = new Category
            {
                Id = 8,
                Name = "SummerEquipment"
            };

            await dbContext.Categories.AddAsync(category1);
            await dbContext.Categories.AddAsync(category2);
            await dbContext.SaveChangesAsync();

            var equipment = new Equipment
            {
                Id = 5,
                Title = "Ski Gear",
                Description = "High-quality ski gear.",
                ImageUrl = "image.jpg",
                PricePerMonth = 75.00m,
                CategoryId = category1.Id, 
                Category = category1
            };

            await dbContext.Equipments.AddAsync(equipment);
            await dbContext.SaveChangesAsync();

   
            var result = await equipmentService.GetEquipmentFormModelByIdAsync(5);

         
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Title, Is.EqualTo("Ski Gear"));
                Assert.That(result.Description, Is.EqualTo("High-quality ski gear."));
                Assert.That(result.ImageUrl, Is.EqualTo("image.jpg"));
                Assert.That(result.PricePerMonth, Is.EqualTo(75.00m));
                Assert.That(result.Categories, Is.Not.Null);
                Assert.That(result.Categories.Any(c => c.Name == "WinterEquipment"), Is.True);
                Assert.That(result.Categories.Any(c => c.Name == "SummerEquipment"), Is.True);
            });
        }

        [Test]
        public async Task GetEquipmentFormModelByIdAsync_ShouldReturnNull_WhenEquipmentDoesNotExist()
        {
         
            var result = await equipmentService.GetEquipmentFormModelByIdAsync(999);

           
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteEquipmentAndItsAssociatedReviewsAndReservations()
        {
           
            var category = new Category
            {
                Id = 8,
                Name = "WinterEquipment"
            };

            var equipment = new Equipment
            {
                Id = 5,
                Title = "Ski Gear",
                Description = "High-quality ski gear.",
                ImageUrl = "image.jpg",
                PricePerMonth = 75.00m,
                CategoryId = category.Id,
                Category = category
            };

            var review1 = new Review
            {
                Id = 4,
                EquipmentId = 5,
                Rating = 5,
                Comment = "Excellent equipment"
            };

            var review2 = new Review
            {
                Id = 5,
                EquipmentId = 5,
                Rating = 4,
                Comment = "Good quality, but a bit expensive"
            };

            var reservation = new Reservation
            {
                Id = 4,
                EquipmentId = 5,
                UserId = "TestUserId"
            };

            await dbContext.Categories.AddAsync(category);
            await dbContext.Equipments.AddAsync(equipment);
            await dbContext.Reviews.AddRangeAsync(review1, review2);
            await dbContext.Reservations.AddAsync(reservation);
            await dbContext.SaveChangesAsync();

          
            await equipmentService.DeleteAsync(5); 

           
            var deletedEquipment = await dbContext.Equipments.FindAsync(5);
            var deletedReviews = await dbContext.Reviews.Where(r => r.EquipmentId == 5).ToListAsync();
            var deletedReservations = await dbContext.Reservations.Where(r => r.EquipmentId == 5).ToListAsync();

            Assert.Multiple(() =>
            {
                Assert.That(deletedEquipment, Is.Null);
                Assert.That(deletedReviews, Is.Empty);
                Assert.That(deletedReservations, Is.Empty);
            });
        }

        [Test]
        public async Task IsRentedAsync_ShouldReturnTrue_WhenEquipmentIsRented()
        {
            var reservation = new Reservation
            {
                Id = 5,
                EquipmentId = 5,
                UserId = "testId"
            };

            await dbContext.Reservations.AddAsync(reservation);
            await dbContext.SaveChangesAsync();

            var r = dbContext.Reservations.ToList();

            var result = await equipmentService.IsRentedAsync(5);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsRentedAsync_ShouldReturnFalse_WhenEquipmentIsNotRented()
        {
            var result = await equipmentService.IsRentedAsync(999); 

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task IsRentedByUserWithIdAsync_ShouldReturnTrue_WhenUserRentedEquipment()
        {
            var reservation = new Reservation
            {
                EquipmentId = 5,
                UserId = "testId"
            };

            await dbContext.Reservations.AddAsync(reservation);
            await dbContext.SaveChangesAsync();

            var result = await equipmentService.IsRentedByUserWithIdAsync(5, "testId");

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsRentedByUserWithIdAsync_ShouldReturnFalse_WhenUserDidNotRentEquipment()
        {
            var reservation = new Reservation
            {
                EquipmentId = 5,
                UserId = "testId"
            };

            await dbContext.Reservations.AddAsync(reservation);
            await dbContext.SaveChangesAsync();

            var result = await equipmentService.IsRentedByUserWithIdAsync(5, "testId2");

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task LeaveAsync_ShouldDeleteReservation_WhenUserIsTheRenter()
        {
            var reservation = new Reservation
            {
                EquipmentId = 5,
                UserId = "testId"
            };

            await dbContext.Reservations.AddAsync(reservation);
            await dbContext.SaveChangesAsync();

            await equipmentService.LeaveAsync(5, "testId");

            var deletedReservation = await dbContext.Reservations
                .FirstOrDefaultAsync(r => r.EquipmentId == 5 && r.UserId == "testId");

            Assert.That(deletedReservation, Is.Null);
        }

       

       

    }


}

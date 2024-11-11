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

namespace ProGearRentals.Services.Tests
{
    public class UserServiceUnitTest
    {

        private IRepository repository;
        private IUserService userService;
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
            userService = new UserService(repository);
        }

        [TearDown]
        public void Teardown()
        {

            dbContext.Dispose();
        }

        [Test]
        public async Task GetAllUsersAsyncShouldReturnAllUsers()
        {
           
            var user1 = new ApplicationUser { Id = "1", FirstName = "John", LastName = "Doe", Email = "john@example.com", Agent = new Agent { PhoneNumber = "1234567890" } };
            var user2 = new ApplicationUser { Id = "2", FirstName = "Jane", LastName = "Smith", Email = "jane@example.com" }; 

            dbContext.Users.AddRange(user1, user2);
            await dbContext.SaveChangesAsync();

            
            var users = await userService.GetAllUsersAsync();

            
           
            Assert.That(users.Any(u => u.Email == "john@example.com" && u.FullName == "John Doe" && u.PhoneNumber == "1234567890" && u.IsAgent), Is.True);
            Assert.That(users.Any(u => u.Email == "jane@example.com" && u.FullName == "Jane Smith" && u.PhoneNumber == null && !u.IsAgent), Is.True);
        }
        [Test]
        public async Task UserFullNameAsync_ReturnsFullName_WhenUserExists()
        {
            
            var userId = "1";
            var user = new ApplicationUser { Id = userId, FirstName = "John", LastName = "Doe" };
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            var fullName = await userService.UserFullNameAsync(userId);

          
            Assert.That(fullName, Is.EqualTo("John Doe"));
        }

        [Test]
        public async Task UserFullNameAsync_ReturnsEmptyString_WhenUserDoesNotExist()
        {
          
            var fullName = await userService.UserFullNameAsync("nonExistentUserId");

            
            Assert.That(fullName, Is.Empty);
        }



    }
}

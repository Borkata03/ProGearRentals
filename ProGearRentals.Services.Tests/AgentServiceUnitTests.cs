using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Services;
using ProGearRentals.Infrastructure.Data;
using ProGearRentals.Infrastructure.Data.Common;
using ProGearRentals.Infrastructure.Data.Models;
using System.Threading.Tasks;

namespace ProGearRentals.Tests
{
    public class AgentServiceUnitTests
    {
        private IRepository repository;
        private IAgentService agentService;
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
            agentService = new AgentService(repository);
        }

        [TearDown]
        public void Teardown()
        {
           
            dbContext.Dispose();
        }


        [Test]
        public async Task CreateAgentShouldCreateAgent()
        {
            var userId = "testUserId";
            var phoneNumber = "0882091920";

            await agentService.CreateAsync(userId, phoneNumber);    

            var agent = await dbContext.Agents.FirstOrDefaultAsync(f => f.UserId == userId);

            Assert.That(agent, Is.Not.Null);
            Assert.That(agent.PhoneNumber, Is.EqualTo(phoneNumber));

        }

        [Test]
        public async Task GetAgentByIdShoudReturnIdIfAgentIdExists()
        {
            var userId = "existingUserId";

            dbContext.Agents.Add(new Agent { UserId = userId });
            await dbContext.SaveChangesAsync(); 

            var agentId = await agentService.ExistByIdAsync(userId);    

            Assert.That(agentId, Is.True);

        }

        [Test]
        public async Task UserHasRentsShouldReturnTrueIfUserHasRents()
        {
            var userId = "testUserId";

            dbContext.Reservations.Add(new Reservation { UserId = userId });    
            await dbContext.SaveChangesAsync(); 

            var rents = await agentService.UserHasRentsAsync(userId);

            Assert.That(rents, Is.True);   

        }

        [Test]
        public async Task UserWithPhoneNumberExistsShouldReturnTrueIfUserWithThisPhoneNumberExist()
        {
            var phoneNumber = "0885091920";

            dbContext.Agents.Add(new Agent { PhoneNumber = phoneNumber }); 
            await dbContext.SaveChangesAsync(); 

            var phonenumber = await agentService.UserWithPhoneNumberExistAsync(phoneNumber);

            Assert.That(phonenumber, Is.True);


        }

        

    }

}
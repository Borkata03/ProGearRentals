using Microsoft.EntityFrameworkCore;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Infrastructure.Data.Common;
using ProGearRentals.Infrastructure.Data.Models;

namespace ProGearRentals.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly IRepository repository;

        public AgentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task CreateAsync(string userId, string phoneNumber)
        {
            await repository.AddAsync(new Agent() 
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            });

            await repository.SaveChangesAsync();    

        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Agent>()
                .AnyAsync(i => i.UserId == userId); 
        }

        public async Task<bool> UserWithPhoneNumberExistAsync(string phoneNumber)
        {
            return await repository.AllReadOnly<Agent>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);

             
        }

        public async Task<bool> UserHasRentsAsync(string userId)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Equipment>()
                 .AnyAsync(h => h.RenterId == userId);
        }

        public async Task<int?> GetAgentIdAsync(string userId)
        {
            return (await repository.AllReadOnly<Agent>()
                 .FirstOrDefaultAsync(a => a.UserId == userId))?.Id;
        }
    }
}

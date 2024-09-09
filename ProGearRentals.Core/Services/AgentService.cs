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

        public Task CreateAsync(string userId, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Agent>()
                .AnyAsync(i => i.UserId == userId); 
        }

        public Task<bool> UserWithPhoneNumberExistAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UsesHasRentsAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}

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

        public async Task<bool> ExistById(string userId)
        {
            return await repository.AllReadOnly<Agent>()
                .AnyAsync(i => i.UserId == userId); 
        }
    }
}

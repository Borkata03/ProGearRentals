using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Core.Contracts
{
    public interface IAgentService
    {
        Task<bool> ExistById(string userId);
    }
}

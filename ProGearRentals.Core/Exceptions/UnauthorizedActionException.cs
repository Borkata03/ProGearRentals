using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Core.Exceptions
{
    public class UnauthorizedActionException : Exception
    {
        public UnauthorizedActionException()
        {
        }

        public UnauthorizedActionException(string message)
            : base(message)
        {

        }
    }
}

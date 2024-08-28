using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace ProGearRentals.Extensions
{
    public static   class ClaimPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}

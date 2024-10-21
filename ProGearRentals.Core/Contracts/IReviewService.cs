using ProGearRentals.Core.Models.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Core.Contracts
{
    public interface IReviewService
    {
         Task<AddReviewFormViewModel?> GetModelForReviewByIdAsync(int id);

        Task CreateReviewAsync(AddReviewFormViewModel model,string userId);
    }
}

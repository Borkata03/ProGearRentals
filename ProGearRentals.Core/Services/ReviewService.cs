using Microsoft.EntityFrameworkCore;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Core.Models.Review;
using ProGearRentals.Infrastructure.Data.Common;
using ProGearRentals.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository repository;

        public ReviewService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task CreateReviewAsync(AddReviewFormViewModel model,string userId)
        {
            var review = new Review()
            {
                Id = model.Id,  
                Comment = model.Comment,
                Rating = model.Rating,
                EquipmentId = model.EquipmentId,
                ReviewerId = userId,  
            };

            await repository.AddAsync<Review>(review);  
            await repository.SaveChangesAsync();
        }

        public async Task<AddReviewFormViewModel?> GetModelForReviewByIdAsync(int id)
        {
           return await repository.AllReadOnly<Review>()
                .Where(e => e.Id == id)
                .Select(e => new AddReviewFormViewModel
                {
                    Id = e.Id,
                    Comment = e.Comment,
                    Rating = e.Rating,  
                    EquipmentId = e.EquipmentId,   
                    ReviewerId = e.ReviewerId,

                }).FirstOrDefaultAsync();    
        }
    }
}

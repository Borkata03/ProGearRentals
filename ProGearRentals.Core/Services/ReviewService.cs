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
                Comment = model.Comment,
                Rating = model.Rating,
                EquipmentId = model.Id,
                ReviewerId = userId,  
            };

            await repository.AddAsync<Review>(review);  
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllReviewQueryModel>> GetAllReviewsAsync(int id)
        {
            return await repository.AllReadOnly<Review>()
                .Where(r => r.EquipmentId == id)
                .Select(r => new AllReviewQueryModel
                {
                    Id = r.Id,
                    Comment = r.Comment,    
                    Rating = r.Rating,  
                    Name = r.Equipment.Title,
                })
                .ToListAsync();
        }

        public async Task<AddReviewFormViewModel?> GetModelForReviewByIdAsync()
        {
           return await repository.AllReadOnly<Review>()
                .Select(e => new AddReviewFormViewModel
                {
                    Comment = e.Comment,
                    Rating = e.Rating,  
                    EquipmentId = e.EquipmentId,   
                    ReviewerId = e.ReviewerId,

                }).FirstOrDefaultAsync();    
        }
    }
}

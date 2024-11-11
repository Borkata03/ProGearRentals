using Microsoft.EntityFrameworkCore;
using ProGearRentals.Core.Contracts;
using ProGearRentals.Infrastructure.Data.Common;
using ProGearRentals.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProGearRentals.Core.Services;
using ProGearRentals.Infrastructure.Data.Models;
using ProGearRentals.Core.Models.Review;

namespace ProGearRentals.Services.Tests
{
    public class ReviewServiceUnitTests
    {
        private IRepository repository;
        private IReviewService reviewService;
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
            reviewService = new ReviewService(repository);
        }

        [TearDown]
        public void Teardown()
        {
            
            dbContext.Dispose();
        }

        [Test]
        public async Task CreateReviewShouldCreateReview()
        {
            string userId = "testUserId";
            var equipment = new Equipment
            {
                Title = "Winer Shoes",
                Id = 4,
            };
            dbContext.Equipments.Add(equipment);
            await dbContext.SaveChangesAsync();

            var model = new AddReviewFormViewModel()
            {
                Id = 4,
                ReviewerId = userId,
                Comment = "very good",
                Rating = 5
            };


            await reviewService.CreateReviewAsync(model, userId);

            var reviewCountBefore = await dbContext.Reviews.ToListAsync();

            await dbContext.SaveChangesAsync(); 

            var fetchedReview = await dbContext.Reviews.Where(r => r.EquipmentId == equipment.Id && r.ReviewerId == userId).FirstOrDefaultAsync();


            Assert.That(fetchedReview, Is.Not.Null, "Review was not found in the database.");
            Assert.Multiple(() =>
            {
                Assert.That(fetchedReview.ReviewerId, Is.EqualTo(userId));
                Assert.That(fetchedReview.EquipmentId, Is.EqualTo(model.Id));
                Assert.That(fetchedReview.Comment, Is.EqualTo("very good"));
                Assert.That(fetchedReview.Rating, Is.EqualTo(5));
            });
        }

        [Test]

        public async Task GetAllReviewsShouldReturnAllReviews()
        {
            var equipment = new Equipment
            {
                Id = 4,
                Title = "Shoes"
            };

            await dbContext.Equipments.AddAsync(equipment);
            await dbContext.SaveChangesAsync();   



            var review = new List<Review>
            {
                new() {Comment = "Very Good", Rating = 5, EquipmentId = equipment.Id,ReviewerId = "testId" },
                new() {Comment = "Good", Rating = 4, EquipmentId = equipment.Id,ReviewerId = "testId" },
            };

           await dbContext.Reviews.AddRangeAsync(review);
        
            await dbContext.SaveChangesAsync();

          

            var reviews = await reviewService.GetAllReviewsAsync(equipment.Id);

            var reviewList = reviews.ToList();

            Assert.That(reviews, Is.Not.Null);
            Assert.That(reviews.Count, Is.EqualTo(2));


            Assert.Multiple(() =>
            {
                Assert.That(reviewList[0].Comment, Is.EqualTo("Very Good"));
                Assert.That(reviewList[0].Rating, Is.EqualTo(5));
            });
            Assert.Multiple(() =>
            {
                Assert.That(reviewList[1].Comment, Is.EqualTo("Good"));
                Assert.That(reviewList[1].Rating, Is.EqualTo(4));
            });
        }

        [Test]
        public async Task GetModelForReviewByIdAsyncShouldReturnModelIfExists()
        {
           
            var equipment = new Equipment
            {
                Id = 5,
                Title = "Shoes"
            };
            dbContext.Equipments.Add(equipment);
            await dbContext.SaveChangesAsync();

            
            var result = await reviewService.GetModelForReviewByIdAsync(equipment.Id);

          
            Assert.That(result, Is.Not.Null, "Result should not be null.");
            Assert.That(result!.EquipmentId, Is.EqualTo(equipment.Id), "EquipmentId should match the provided equipment Id.");
        }
    }
    
}

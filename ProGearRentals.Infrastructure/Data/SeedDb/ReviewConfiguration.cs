using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProGearRentals.Infrastructure.Data.Models;

namespace ProGearRentals.Infrastructure.Data.SeedDb
{
    internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {

            builder
                .HasOne(r => r.Equipment)
                .WithMany(e => e.Reviews)
                .HasForeignKey(r => r.EquipmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(r => r.Reviewer)
                .WithMany()
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);


            var data = new SeedData();

            builder.HasData(new Review[] {data.FirstReview,data.SecondReview,data.ThirdReview}); 

        }
    }
}

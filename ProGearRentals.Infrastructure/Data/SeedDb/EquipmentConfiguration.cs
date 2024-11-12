using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProGearRentals.Infrastructure.Data.Models;

namespace ProGearRentals.Infrastructure.Data.SeedDb
{
    internal class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
           builder
                .HasOne(e => e.Category)
                .WithMany(h => h.Equipments)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(a => a.Agent)
                .WithMany(e => e.Equipments)
                .HasForeignKey(a => a.AgentId)
                .OnDelete(DeleteBehavior.Restrict);


            var data = new SeedData();

            builder.HasData(new Equipment[] { data.FirstEquipment, data.SecondEquipment, data.ThirdEquipment });
        }
    }
}

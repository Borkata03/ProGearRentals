using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProGearRentals.Infrastructure.Data.Models;
using ProGearRentals.Infrastructure.Data.SeedDb;
using System.Reflection.Emit;

namespace ProGearRentals.Infrastructure.Data
{
    public class ProGearRentalsDbContext : IdentityDbContext<ApplicationUser>
    {
        public ProGearRentalsDbContext(DbContextOptions<ProGearRentalsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AgentConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());
            builder.ApplyConfiguration(new ReservationConfiguration());
            builder.ApplyConfiguration(new EquipmentConfiguration());

            base.OnModelCreating(builder);
        }




        public DbSet<Equipment> Equipments { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Reservation> Reservations { get; set; } = null!;

        public DbSet<Review> Reviews { get; set; } = null!;

        public DbSet<Agent> Agents { get; set; } = null!;


       

    }
}
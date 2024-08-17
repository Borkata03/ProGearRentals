using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProGearRentals.Infrastructure.Data.Models;
using System.Reflection.Emit;

namespace ProGearRentals.Infrastructure.Data
{
    public class ProGearRentalsDbContext : IdentityDbContext
    {
        public ProGearRentalsDbContext(DbContextOptions<ProGearRentalsDbContext> options)
            : base(options)
        {
        }

       

        public DbSet<Equipment> Equipments { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Reservation> Reservations { get; set; } = null!;

        public DbSet<Review> Reviews { get; set; } = null!;

        public DbSet<Agent> Agents { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Review>()
                .HasKey(r => r.Id); 

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Equipment)
                .WithMany(e => e.Reviews)
                .HasForeignKey(r => r.EquipmentId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Reviewer)
                .WithMany()
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict); 

        
            modelBuilder.Entity<Reservation>()
                .HasKey(r => r.Id); 

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Equipment)
                .WithMany(e => e.Reservations) 
                .HasForeignKey(r => r.EquipmentId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany() 
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict); 
        }


    }
}
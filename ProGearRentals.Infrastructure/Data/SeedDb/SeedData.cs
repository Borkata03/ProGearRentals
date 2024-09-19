using Microsoft.AspNetCore.Identity;
using ProGearRentals.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGearRentals.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
       public IdentityUser AgentUser { get; set; } 
        
       public IdentityUser GuestUser { get; set; }

       public Agent Agent { get; set; }

       public Category MountainEquipment { get; set; }

       public Category WaterEquipment { get; set; }

       public Category WinterSportsEquipment { get; set; }

       public Category SummerGear { get; set; }

       public Equipment FirstEquipment { get; set; }

       public Equipment SecondEquipment { get; set; }

       public Equipment ThirdEquipment { get; set; }

       public Review FirstReview { get; set; }

       public Review SecondReview { get;set; }

       public Review ThirdReview { get; set; }
       public Reservation FirstReservation { get; set; }
       public Reservation SecondReservation { get;  set; }
       public Reservation ThirdReservation { get; set; }


        public SeedData()
        {
            SeedUsers();
            SeedAgent();
            SeedCategories();
            SeedEquipments();
            SeedReviews();
            SeedReservation();  
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AgentUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com"
            };

            AgentUser.PasswordHash =
                 hasher.HashPassword(AgentUser, "agent123");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(AgentUser, "guest123");
        }

        private void SeedAgent()
        {
            Agent = new Agent()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = AgentUser.Id
            };
        }

        private void SeedCategories()
        {
            MountainEquipment = new Category()
            {
                Id = 1,
                Name = "MountainEquipment"
            };

            WaterEquipment = new Category()
            {
                Id = 2,
                Name = "WaterEquipment"
            };

           WinterSportsEquipment = new Category()
           {
                Id = 3,
                Name = "WinterSportsEquipment"
           };

            SummerGear = new Category()
            {
                Id = 5,
                Name = "SummerGear"
            };
        }

        private void SeedEquipments()
        {
            FirstEquipment = new Equipment()
            {
                Id = 1,
                Title = "Snowboard",
                Description = "The snowboard is a versatile and essential piece of equipment for snowboarding enthusiasts. ",
                ImageUrl = "https://cdn02.plentymarkets.com/dqaqtvmxowl5/item/images/19158/full/Jones-Frontier-Wide-Snowboard-21-Freeride-All-Mountain-Powder.jpg",
                PricePerMonth = 150.00M,
                CategoryId = WinterSportsEquipment.Id,
                AgentId = Agent.Id,
                RenterId = GuestUser.Id
            };

            SecondEquipment = new Equipment()
            {
                Id = 2,
                Title = "WaterproofJacket",
                Description = "The waterproof jacket is a crucial piece of gear for outdoor enthusiasts and athletes who need protection from rain and wind. ",
                ImageUrl = "https://th.bing.com/th/id/R.8cb5238aadcab3b3db54f3ce5d8add34?rik=hJ9E41YY2Idwtg&pid=ImgRaw&r=0",
                PricePerMonth = 120.00M,
                CategoryId = WinterSportsEquipment.Id,
                AgentId = Agent.Id,
              
            };

            ThirdEquipment = new Equipment()
            {
                Id = 3,
                Title = "ClimbingHarnesses",
                Description = "A climbing harness is an essential piece of safety equipment for climbers, providing security and comfort while ascending. ",
                ImageUrl = "https://th.bing.com/th/id/R.5919827440acbdd756a86ad4c0fc3c50?rik=gWbQT31EPisuSQ&pid=ImgRaw&r=0",
                PricePerMonth = 250.00M,
                CategoryId = MountainEquipment.Id,
                AgentId = Agent.Id,
              
            };
        }

        private void SeedReviews()
        {
            FirstReview = new Review()
            {
                Id = 1,
                Rating = 4,
                Comment = "This snowboard is a game-changer! I'm using it for the first time and it works like a dream in all conditions.",
                EquipmentId = FirstEquipment.Id,
                ReviewerId = GuestUser.Id,
            };
            SecondReview = new Review()
            {
                Id = 2,
                Rating = 5,
                Comment = "This waterproof jacket exceeded my expectations! I used it in snow condition and it's just unique",
                EquipmentId = SecondEquipment.Id,
                ReviewerId = GuestUser.Id,
            };
            ThirdReview = new Review()
            {
                Id = 3,
                Rating = 1,
                Comment = "I’m quite disappointed with this climbing harness. The fit isn’t very comfortable and feels restrictive even after adjusting it several times.",
                EquipmentId = ThirdEquipment.Id,
                ReviewerId = GuestUser.Id,
            };

        }

        private void SeedReservation()
        {
            FirstReservation = new Reservation()
            {
                Id = 1,
                StartDate = new DateTime(2024, 9, 24),
                EndDate = new DateTime(2024, 9, 28),
                EquipmentId = FirstEquipment.Id,
                UserId = GuestUser.Id

            };
            SecondReservation = new Reservation()
            {
                Id = 2,
                StartDate = new DateTime(2024, 10, 15),
                EndDate = new DateTime(2024, 10, 20),
                EquipmentId = SecondEquipment.Id,
                UserId = GuestUser.Id

            };
            ThirdReservation = new Reservation()
            {
                Id = 3,
                StartDate = new DateTime(2024, 10, 10),
                EndDate = new DateTime(2024, 10, 12),
                EquipmentId = ThirdEquipment.Id,
                UserId = GuestUser.Id

            };


        }

    }
}

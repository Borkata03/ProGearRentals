﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProGearRentals.Infrastructure.Data;

#nullable disable

namespace ProGearRentals.Infrastructure.Migrations
{
    [DbContext(typeof(ProGearRentalsDbContext))]
    [Migration("20240926115137_AdminAdded")]
    partial class AdminAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProGearRentals.Infrastructure.Data.Models.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Agent identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Agent's Phone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Identifier");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Agents");

                    b.HasComment("Equipment Agent");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PhoneNumber = "+359888888888",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        },
                        new
                        {
                            Id = 4,
                            PhoneNumber = "+359888888833",
                            UserId = "5fd5055a-69af-416a-acc6-d01823105d81"
                        });
                });

            modelBuilder.Entity("ProGearRentals.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f2a99c93-057a-466e-8956-b1b52d4870fc",
                            Email = "agent@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Agent",
                            LastName = "Agentski",
                            LockoutEnabled = false,
                            NormalizedEmail = "agent@mail.com",
                            NormalizedUserName = "agent@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEC5Uol8XYeshbNKsAQ8hDJ8G4rhVme9ZtMigQHKXOemFdQyL98xzakW2PaPjRFBAeA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6cbd8583-1eb9-40e8-b001-2dae595fdf57",
                            TwoFactorEnabled = false,
                            UserName = "agent@mail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cc156963-8c8d-41ac-8b3e-900f812f2336",
                            Email = "guest@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Guest",
                            LastName = "Guestski ",
                            LockoutEnabled = false,
                            NormalizedEmail = "guest@mail.com",
                            NormalizedUserName = "guest@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEEb4YsczgxBkE3fh9Y7Ie5zie0pjiZcvRHI8Bl4qaFvH/J4c7CpwpT9AB33QZ50pbQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "974ddfa9-8812-4236-a6c7-0120d7e36f4e",
                            TwoFactorEnabled = false,
                            UserName = "guest@mail.com"
                        },
                        new
                        {
                            Id = "5fd5055a-69af-416a-acc6-d01823105d81",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "726c7cbf-e07b-4748-8dac-a9de8c24e771",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Top",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@MAIL.COM",
                            NormalizedUserName = "ADMIN@MAIL.COM",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4fef6f1b-e5ca-4ede-944c-c1155919a757",
                            TwoFactorEnabled = false,
                            UserName = "admin@mail.com"
                        });
                });

            modelBuilder.Entity("ProGearRentals.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Category identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Category Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasComment("Equipment category");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Name = "WinterSportsEquipment"
                        },
                        new
                        {
                            Id = 2,
                            Name = "WaterEquipment"
                        },
                        new
                        {
                            Id = 1,
                            Name = "MountainEquipment"
                        },
                        new
                        {
                            Id = 5,
                            Name = "SummerGear"
                        });
                });

            modelBuilder.Entity("ProGearRentals.Infrastructure.Data.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Equipment Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgentId")
                        .HasColumnType("int")
                        .HasComment("Agent Identifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Category Identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Equipment Description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Equipment image Url");

                    b.Property<decimal>("PricePerMonth")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Monthfly Price");

                    b.Property<string>("RenterId")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("User id of the renterer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Equipment Title");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Equipments");

                    b.HasComment("Equipment to rent");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgentId = 1,
                            CategoryId = 3,
                            Description = "The snowboard is a versatile and essential piece of equipment for snowboarding enthusiasts. ",
                            ImageUrl = "https://cdn02.plentymarkets.com/dqaqtvmxowl5/item/images/19158/full/Jones-Frontier-Wide-Snowboard-21-Freeride-All-Mountain-Powder.jpg",
                            PricePerMonth = 150.00m,
                            RenterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            Title = "Snowboard"
                        },
                        new
                        {
                            Id = 2,
                            AgentId = 1,
                            CategoryId = 3,
                            Description = "The waterproof jacket is a crucial piece of gear for outdoor enthusiasts and athletes who need protection from rain and wind. ",
                            ImageUrl = "https://th.bing.com/th/id/R.8cb5238aadcab3b3db54f3ce5d8add34?rik=hJ9E41YY2Idwtg&pid=ImgRaw&r=0",
                            PricePerMonth = 120.00m,
                            Title = "WaterproofJacket"
                        },
                        new
                        {
                            Id = 3,
                            AgentId = 1,
                            CategoryId = 1,
                            Description = "A climbing harness is an essential piece of safety equipment for climbers, providing security and comfort while ascending. ",
                            ImageUrl = "https://th.bing.com/th/id/R.5919827440acbdd756a86ad4c0fc3c50?rik=gWbQT31EPisuSQ&pid=ImgRaw&r=0",
                            PricePerMonth = 250.00m,
                            Title = "ClimbingHarnesses"
                        });
                });

            modelBuilder.Entity("ProGearRentals.Infrastructure.Data.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Reservation Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasComment("End date of the reservation period");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int")
                        .HasComment("Equipment Identifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasComment("Start date of the reservation period");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Identifier who made the reservation");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");

                    b.HasComment("Equipment reservation record");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateTime(2024, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EquipmentId = 1,
                            StartDate = new DateTime(2024, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                        },
                        new
                        {
                            Id = 2,
                            EndDate = new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EquipmentId = 2,
                            StartDate = new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                        },
                        new
                        {
                            Id = 3,
                            EndDate = new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EquipmentId = 3,
                            StartDate = new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                        });
                });

            modelBuilder.Entity("ProGearRentals.Infrastructure.Data.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Review Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Review comment");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int")
                        .HasComment("Equipment Identifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasComment("Rating given by the user (1 to 5)");

                    b.Property<string>("ReviewerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Identifier Reviewer");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");

                    b.HasComment("Equipment Review");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "This snowboard is a game-changer! I'm using it for the first time and it works like a dream in all conditions.",
                            EquipmentId = 1,
                            Rating = 4,
                            ReviewerId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                        },
                        new
                        {
                            Id = 2,
                            Comment = "This waterproof jacket exceeded my expectations! I used it in snow condition and it's just unique",
                            EquipmentId = 2,
                            Rating = 5,
                            ReviewerId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                        },
                        new
                        {
                            Id = 3,
                            Comment = "I’m quite disappointed with this climbing harness. The fit isn’t very comfortable and feels restrictive even after adjusting it several times.",
                            EquipmentId = 3,
                            Rating = 1,
                            ReviewerId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProGearRentals.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProGearRentals.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProGearRentals.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProGearRentals.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProGearRentals.Infrastructure.Data.Models.Agent", b =>
                {
                    b.HasOne("ProGearRentals.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProGearRentals.Infrastructure.Data.Models.Equipment", b =>
                {
                    b.HasOne("ProGearRentals.Infrastructure.Data.Models.Agent", "Agent")
                        .WithMany("Equipments")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProGearRentals.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("Equipments")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ProGearRentals.Infrastructure.Data.Models.Reservation", b =>
                {
                    b.HasOne("ProGearRentals.Infrastructure.Data.Models.Equipment", "Equipment")
                        .WithMany("Reservations")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProGearRentals.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProGearRentals.Infrastructure.Data.Models.Review", b =>
                {
                    b.HasOne("ProGearRentals.Infrastructure.Data.Models.Equipment", "Equipment")
                        .WithMany("Reviews")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProGearRentals.Infrastructure.Data.Models.ApplicationUser", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("ProGearRentals.Infrastructure.Data.Models.Agent", b =>
                {
                    b.Navigation("Equipments");
                });

            modelBuilder.Entity("ProGearRentals.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("Equipments");
                });

            modelBuilder.Entity("ProGearRentals.Infrastructure.Data.Models.Equipment", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}

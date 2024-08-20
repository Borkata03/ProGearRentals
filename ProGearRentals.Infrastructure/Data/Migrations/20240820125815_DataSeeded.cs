using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProGearRentals.Infrastructure.Migrations
{
    public partial class DataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Agents_AgentId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Categories_CategoryId",
                table: "Equipments");

            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: true,
                comment: "User id of the renterer",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "User id of the renterer");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Agents",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                comment: "Agent's Phone",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "Agent's Phone");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "fdd137aa-ec7e-4e30-8712-df484b2d2ce4", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEC5OW42Nj3uwAVMZOKqzJk0RcsEd6L0ONRcnm6fmwUdNppLdEhLXBcNGPGPI8CJqcg==", null, false, "58e5621d-19ed-47c0-b4cc-55b8546a14d1", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "bfbc0020-5ac7-4b20-b77a-82763ae54146", "agent@mail.com", false, false, null, "agent@mail.com", "agent@mail.com", "AQAAAAEAACcQAAAAEK7jP6Mth6Uh6BeBZPNxrcNsqpljyiQJj66SmAtFq10Tvo85aZ5wDL3TADqpQW2jSQ==", null, false, "5ae77e8f-ae8a-479d-859d-5906fbbd7a3a", false, "agent@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "WaterproofJackets" },
                    { 2, "Snowboard" },
                    { 3, "ClimbingHarnesses" }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { 1, 1, 2, "The snowboard is a versatile and essential piece of equipment for snowboarding enthusiasts. ", "https://cdn02.plentymarkets.com/dqaqtvmxowl5/item/images/19158/full/Jones-Frontier-Wide-Snowboard-21-Freeride-All-Mountain-Powder.jpg", 150.00m, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "Snowboard" });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { 2, 1, 1, "The waterproof jacket is a crucial piece of gear for outdoor enthusiasts and athletes who need protection from rain and wind. ", "https://th.bing.com/th/id/R.8cb5238aadcab3b3db54f3ce5d8add34?rik=hJ9E41YY2Idwtg&pid=ImgRaw&r=0", 120.00m, null, "WaterproofJacket" });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { 3, 1, 3, "A climbing harness is an essential piece of safety equipment for climbers, providing security and comfort while ascending. ", "https://th.bing.com/th/id/R.5919827440acbdd756a86ad4c0fc3c50?rik=gWbQT31EPisuSQ&pid=ImgRaw&r=0", 250.00m, null, "ClimbingHarnesses" });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "EndDate", "EquipmentId", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2024, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 2, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 3, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "EquipmentId", "Rating", "ReviewerId" },
                values: new object[,]
                {
                    { 1, "This snowboard is a game-changer! I'm using it for the first time and it works like a dream in all conditions.", 1, 4, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 2, "This waterproof jacket exceeded my expectations! I used it in snow condition and it's just unique", 2, 5, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 3, "I’m quite disappointed with this climbing harness. The fit isn’t very comfortable and feels restrictive even after adjusting it several times.", 3, 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Agents_AgentId",
                table: "Equipments",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Categories_CategoryId",
                table: "Equipments",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Agents_AgentId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Categories_CategoryId",
                table: "Equipments");

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "User id of the renterer",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "User id of the renterer");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Agents",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "Agent's Phone",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldComment: "Agent's Phone");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Agents_AgentId",
                table: "Equipments",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Categories_CategoryId",
                table: "Equipments",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

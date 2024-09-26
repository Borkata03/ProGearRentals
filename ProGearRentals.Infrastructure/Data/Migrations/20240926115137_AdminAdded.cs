using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProGearRentals.Infrastructure.Migrations
{
    public partial class AdminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc156963-8c8d-41ac-8b3e-900f812f2336", "Guest", "Guestski ", "AQAAAAEAACcQAAAAEEb4YsczgxBkE3fh9Y7Ie5zie0pjiZcvRHI8Bl4qaFvH/J4c7CpwpT9AB33QZ50pbQ==", "974ddfa9-8812-4236-a6c7-0120d7e36f4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2a99c93-057a-466e-8956-b1b52d4870fc", "Agent", "Agentski", "AQAAAAEAACcQAAAAEC5Uol8XYeshbNKsAQ8hDJ8G4rhVme9ZtMigQHKXOemFdQyL98xzakW2PaPjRFBAeA==", "6cbd8583-1eb9-40e8-b001-2dae595fdf57" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5fd5055a-69af-416a-acc6-d01823105d81", 0, "726c7cbf-e07b-4748-8dac-a9de8c24e771", "admin@mail.com", false, "Top", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", null, null, false, "4fef6f1b-e5ca-4ede-944c-c1155919a757", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 4, "+359888888833", "5fd5055a-69af-416a-acc6-d01823105d81" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fd5055a-69af-416a-acc6-d01823105d81");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f90da8e0-056b-4d27-9262-d3a44591943b", "", "", "AQAAAAEAACcQAAAAEMg+OGmv6G+E+hRCU9coKq5IzCglTEOK5HWcjGfHjyn53XulwXSwPWQjKauQXiuF4Q==", "12ba53b0-96df-4a75-9016-c78630a24b62" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83fcdd6a-963c-456d-b8e8-b769cb2dbdaf", "", "", "AQAAAAEAACcQAAAAEEh9mbw5Hnrijnsr4XSBUBAAQHhD0ZtfQPUbFpL5m1/dfK7TqqztcWvipgdeJFuzQw==", "f8c93469-570a-43a7-80be-470f78d771d6" });
        }
    }
}

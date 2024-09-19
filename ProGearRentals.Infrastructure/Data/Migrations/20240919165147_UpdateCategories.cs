using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProGearRentals.Infrastructure.Migrations
{
    public partial class UpdateCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "191047b2-e58c-41e8-8f38-cdc86e3e2487", "AQAAAAEAACcQAAAAEIjD8yEk76oHyg5yvssqyFIvIKjUyvhIAeIgiNx4jbN47ow/aMHggbye/2/mGUYcmg==", "5fe43b31-230c-42bb-ac6a-5dbc2d18780e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4396d6dd-fe69-45ba-adf0-475da05b32e9", "AQAAAAEAACcQAAAAEBbqwmKQ3D1NXvWSb6T2PRFxyc644I19wyZtd4Kqx9s4otDM0HP4aFdIOm5wgv4mKA==", "ae001573-553d-4f0d-a6c9-3834247f7afa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f16cadf-ba28-4573-be75-b7c4f0c3ebf8", "AQAAAAEAACcQAAAAEE0QpnayHExOAe5wG9Rs9k8gsSmavyhbw6OXY4pn/iOyvJb2ahTwUcco7uynU4lG8Q==", "feb7ff39-676c-462b-955b-a514ce31f1d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55531222-75dd-4fc0-9e86-de8f892614e4", "AQAAAAEAACcQAAAAEBa23wu9qLfQRm9TYtvD9rDqnREme+PUnXVwK/SbH7uRBBItclwnlrJTHA4EqPAD7Q==", "7b10cbe2-2b7c-4fd2-b82b-5b168f0a6fbd" });
        }
    }
}

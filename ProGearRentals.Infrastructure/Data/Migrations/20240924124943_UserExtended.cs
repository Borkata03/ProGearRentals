using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProGearRentals.Infrastructure.Migrations
{
    public partial class UserExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

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
    }
}

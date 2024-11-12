using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProGearRentals.Infrastructure.Migrations
{
    public partial class AdminClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fd5055a-69af-416a-acc6-d01823105d81",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ac5f03e-016d-4aad-ad7a-342cfef5dced", "AQAAAAEAACcQAAAAEBDVQX5wmj40m0zyrtpyFQp9jFG4JRlpApZa+CJa35Ea37GdS5d489JJNxOiVXSpnQ==", "ea869c2b-2eed-4252-879e-1dac3ec5175d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18d8607c-b09e-4bba-82ef-b50488ea0856", "AQAAAAEAACcQAAAAENdzrPABf0Mc4Tnb3L5yJtBv8iwVvu6BMMQdm2sqRXw7Zn9hv+DyH9sPmxMT1qh4Zg==", "7e883ab5-3780-4041-b8e2-34bf005e2a48" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "628dc1d6-6f62-4540-908b-6098559a1e16", "AQAAAAEAACcQAAAAEB54vV3cP8MUAh7UokMdryd9f1c9uuJLlTiwthYJ7lqBds0kuTbpdBreQAqrImhvdA==", "7733528c-eeea-4a9b-ae53-2fc19b213599" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fd5055a-69af-416a-acc6-d01823105d81",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e75f340b-927d-4d6f-9aed-de62da4b7390", "AQAAAAEAACcQAAAAED6gHh1MZbkiB5qaoVv6/tnIZv70OviZfC9zriZuIYzTovc1p6wdIr2lphePY2QADA==", "3079b8d2-013e-45bf-891c-7dce96157f47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9babba5b-f527-4c5b-bc99-940ffc89c7c4", "AQAAAAEAACcQAAAAEHyhgbYFk6cHoyaDF8Ds2sEFNdo04kDlTjT1+ZTP/uR4/kdkU3UorMcffedw/0me/Q==", "e4062b42-39df-4767-a2e2-a09d32732a37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2800a8a-e4c7-48a4-a1d9-d829aea6824f", "AQAAAAEAACcQAAAAEIbWEqEZfLh9VscAaPfiKg3JJSSiyrpL/83Nv6B8yTxpJ2dAwqjVZVDiHJsqafbi/Q==", "221ac6c9-5fca-42c8-a1be-092ae33cee4a" });
        }
    }
}

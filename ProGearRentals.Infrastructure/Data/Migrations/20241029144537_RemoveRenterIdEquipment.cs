using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProGearRentals.Infrastructure.Migrations
{
    public partial class RemoveRenterIdEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RenterId",
                table: "Equipments");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RenterId",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: true,
                comment: "User id of the renterer");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fd5055a-69af-416a-acc6-d01823105d81",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "333fbd53-ed57-4a56-be68-e2e59d9f2416", "AQAAAAEAACcQAAAAEPObEKvTVvQMZ8G3EEj0F075+f56yfEyKazC4ThS+0TZQ6Kfdveyg/5mZMPz/P4vGg==", "628ae5ab-d587-41e7-9014-01afb1a78625" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0cc959e2-5c62-43ef-8cf8-a71e62d8ee62", "AQAAAAEAACcQAAAAEJM/3Sn3DtNR0y0Nl0P23MSZNGnmG5SBNgoHiSNoRMc7RBuTrsCA5aq6TUDpaj3YXw==", "3ab12ece-8c60-442c-9c73-a29cf76a0bdf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ca117bb-8d09-424e-adc4-6263e0def1aa", "AQAAAAEAACcQAAAAEKAFJcVFGNAPK3tUHvsi5vUvouz+FzHse9P+ljX5sHx/loF/LfqxfH9bLTjClLZA0g==", "97674d88-d812-402c-af19-9d6f962cafd4" });

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1,
                column: "RenterId",
                value: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");
        }
    }
}

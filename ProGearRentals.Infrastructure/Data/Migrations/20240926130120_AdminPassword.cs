using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProGearRentals.Infrastructure.Migrations
{
    public partial class AdminPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fd5055a-69af-416a-acc6-d01823105d81",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e98c9ab-bbff-4343-ae59-eddaa4813582", "AQAAAAEAACcQAAAAEHicJExzGeQDaswyZI3e1ZppGccDvJTRYrV9VWuUN5Bb8XQNhnHdFvmHYEysGvubmg==", "0821a398-566d-42a2-9823-635ca416d290" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6717ff1b-ed25-46eb-b9b9-d4a5fabc2a90", "AQAAAAEAACcQAAAAEHl9cLBWSv9qmhVuNgY8OT+tnS9cSrWgULEHWM14xXAOySJmU/u12i5bEJg1hRJH4g==", "572866d2-bf4a-4255-becd-fda139c19db2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97126926-3add-4886-8b31-04935dfa3816", "AQAAAAEAACcQAAAAEDXl6Wib6zMUtKXTRmwL2nafjzrpyvtW663cWZ2iwmm4NT5BDUAu1H55TDo94nr5Uw==", "0e397134-aa3d-474a-a873-a5e47a8415fe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fd5055a-69af-416a-acc6-d01823105d81",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "726c7cbf-e07b-4748-8dac-a9de8c24e771", null, "4fef6f1b-e5ca-4ede-944c-c1155919a757" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc156963-8c8d-41ac-8b3e-900f812f2336", "AQAAAAEAACcQAAAAEEb4YsczgxBkE3fh9Y7Ie5zie0pjiZcvRHI8Bl4qaFvH/J4c7CpwpT9AB33QZ50pbQ==", "974ddfa9-8812-4236-a6c7-0120d7e36f4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2a99c93-057a-466e-8956-b1b52d4870fc", "AQAAAAEAACcQAAAAEC5Uol8XYeshbNKsAQ8hDJ8G4rhVme9ZtMigQHKXOemFdQyL98xzakW2PaPjRFBAeA==", "6cbd8583-1eb9-40e8-b001-2dae595fdf57" });
        }
    }
}

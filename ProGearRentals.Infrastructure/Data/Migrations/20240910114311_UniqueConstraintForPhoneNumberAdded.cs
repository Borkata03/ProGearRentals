using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProGearRentals.Infrastructure.Migrations
{
    public partial class UniqueConstraintForPhoneNumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88bd7499-fe4e-4207-9fc5-fbe7d24329da", "AQAAAAEAACcQAAAAECNfPmR40Syr0RoHwcXLe8pOF/Dy0H3BAfhBC9Y54OGdvn9dooxKFMI3ioUrMpq5IA==", "1614f2f4-cd32-48ca-b1ae-c1e9aa5ad74e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdee81ff-e9ae-4e56-a1cf-b62fbaf6e836", "AQAAAAEAACcQAAAAELEgbJHYHLb72E0X/2TqBpNLGyh1JSWy/zRaVKqf6k4JKAELOcQgq9lr9VbyBP066w==", "6a3c8bf3-1a29-42a6-bf42-aca86dfb6796" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdd137aa-ec7e-4e30-8712-df484b2d2ce4", "AQAAAAEAACcQAAAAEC5OW42Nj3uwAVMZOKqzJk0RcsEd6L0ONRcnm6fmwUdNppLdEhLXBcNGPGPI8CJqcg==", "58e5621d-19ed-47c0-b4cc-55b8546a14d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfbc0020-5ac7-4b20-b77a-82763ae54146", "AQAAAAEAACcQAAAAEK7jP6Mth6Uh6BeBZPNxrcNsqpljyiQJj66SmAtFq10Tvo85aZ5wDL3TADqpQW2jSQ==", "5ae77e8f-ae8a-479d-859d-5906fbbd7a3a" });
        }
    }
}

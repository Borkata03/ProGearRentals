using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProGearRentals.Infrastructure.Migrations
{
    public partial class ApproveAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_UserId",
                table: "Agents");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Equipments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is Equipment approved by admin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fd5055a-69af-416a-acc6-d01823105d81",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c65c235-5433-45d1-8e19-72d5cdc18b69", "AQAAAAEAACcQAAAAENOWOkXd4qGznGWy0DxEhnlK09zBDZRm+FveEmFBQJwAMgWepwAHwB98b7//FnN8dQ==", "921140d7-2b9d-4e4f-aea3-028431e95148" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd91b4c4-95f4-42b9-9b31-ec6ae329c5c9", "AQAAAAEAACcQAAAAEH1p6UrZCVS56tvu9r2e4sH4Gv0M5XGVMcDTApnJ33j2JQBoKKBryf3MCw99iUCZqg==", "d41930f7-19aa-4955-b719-8749c44b3e43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ad60514-e0f1-4bdc-8118-0043ead611aa", "AQAAAAEAACcQAAAAEMykJwpPvAiIT8ts4XGT1fDlMGpu9A8ABz8SxdIyVT27e+hTXd5HqSyBLZ0dnqWkjg==", "99300cbd-9e9a-4566-9ce3-7499ebc45fb6" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_UserId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Equipments");

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

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");
        }
    }
}

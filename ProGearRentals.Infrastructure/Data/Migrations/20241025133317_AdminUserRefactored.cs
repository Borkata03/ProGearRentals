using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

#nullable disable

namespace ProGearRentals.Infrastructure.Migrations
{
    public partial class AdminUserRefactored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            migrationBuilder.UpdateData(
              table: "AspNetUsers",
              keyColumn: "Id",
              keyValue: "5fd5055a-69af-416a-acc6-d01823105d81",
              columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
              values: new object[] { "333fbd53-ed57-4a56-be68-e2e59d9f2416", hasher.HashPassword(null, "admin1234"), "628ae5ab-d587-41e7-9014-01afb1a78625" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fd5055a-69af-416a-acc6-d01823105d81",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04b80e27-cdd2-4890-af37-509ab6617583", "AQAAAAEAACcQAAAAEKuOxhxhL/Pj64OTA/Zz1e78roYjBTDyYGvcFpOiNnaIs47M6dDssID11POKpI/j2g==", "d9646c98-4a06-4a65-bd9b-e66790236fe6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a34ad438-2ff2-4cf3-88bd-4926fbac3010", "AQAAAAEAACcQAAAAECxn4L4LPea/yAfAr09wx3A0QRlJAMB6sQc64lQbbzZ3IgYCye5xBiTFNa6WtX58+Q==", "6e24009a-868d-44ee-ba30-bddda2d03580" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b46d96fa-7475-4d50-b894-a9328c906a5e", "AQAAAAEAACcQAAAAEGRu7HXlVtROh/zzRs2kkHSs5MIKqg7M3m2Q5RZB6x5P7OFkRPBqnh2e8LnnIU8ang==", "c920e239-38c3-4eea-b29a-a547cde3fe51" });
        }
    }
}

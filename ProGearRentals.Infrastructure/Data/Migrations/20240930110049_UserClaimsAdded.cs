using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProGearRentals.Infrastructure.Migrations
{
    public partial class UserClaimsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Agent Agentski", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 2, "user:fullname", "Guest Guestski", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 3, "user:fullname", "Top Admin", "5fd5055a-69af-416a-acc6-d01823105d81" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

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
    }
}

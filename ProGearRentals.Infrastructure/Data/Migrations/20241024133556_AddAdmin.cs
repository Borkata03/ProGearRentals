using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProGearRentals.Infrastructure.Migrations
{
    public partial class AddAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fd5055a-69af-416a-acc6-d01823105d81",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7a079ca-9d02-41ba-a5e7-afe31ca9f245", "AQAAAAEAACcQAAAAEC8DydkfvTVVae5X+Q+vCSVZdh+jdOYLeCJJj8JEGA7qc5JlE8RGb+Rv8uWHtST32Q==", "259bbf27-2581-4997-a4fd-652de454752d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af55bfa7-622c-44b3-aa99-86a65e070e77", "AQAAAAEAACcQAAAAEKZJUtlo9hf5C7z+PPPSBroKZXzqDnZVMVqrE6YjapW3uMKEWjYnHKt1Q8q/JhL8lg==", "6de8b799-ddea-4b17-be51-6e7835885a8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c15644e9-32db-4acd-8233-2181e4f2faf2", "AQAAAAEAACcQAAAAEEv/8N9xLXM/W9YOHgSAypI+mDu1rELxXTfDfEF54jBmXRok8ya6jomkYId8T1ah9g==", "5a82f015-b9db-4c4d-9420-9727c36e7c62" });
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

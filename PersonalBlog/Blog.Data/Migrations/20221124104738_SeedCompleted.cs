using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class SeedCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "name" },
                values: new object[,]
                {
                    { new Guid("a7dab329-8f34-4be7-bdfe-fccf7df783d1"), "Admin test", new DateTime(2022, 11, 24, 13, 47, 38, 434, DateTimeKind.Local).AddTicks(1163), null, null, false, null, null, "ASP.NET Core" },
                    { new Guid("bf6c8898-1dc7-49d3-ae3f-efcf099b8d15"), "Admin test", new DateTime(2022, 11, 24, 13, 47, 38, 434, DateTimeKind.Local).AddTicks(1186), null, null, false, null, null, "Visual Studio" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("998b5ce9-ce74-4646-bcf6-1f6631231f6b"), "Admin", new DateTime(2022, 11, 24, 13, 47, 38, 434, DateTimeKind.Local).AddTicks(4266), null, null, "images/testimage", "jpg", false, null, null },
                    { new Guid("ebe68fdd-4371-4a0f-860e-6755343f52ea"), "Admin", new DateTime(2022, 11, 24, 13, 47, 38, 434, DateTimeKind.Local).AddTicks(4289), null, null, "images/vstest", "png", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { new Guid("6bd09613-971e-48c4-9054-22bbbf404498"), new Guid("a7dab329-8f34-4be7-bdfe-fccf7df783d1"), "Asp .net core ......", "Admin", new DateTime(2022, 11, 24, 13, 47, 38, 432, DateTimeKind.Local).AddTicks(8619), null, null, new Guid("998b5ce9-ce74-4646-bcf6-1f6631231f6b"), false, null, null, "ASP .NET CORE Deneme Makalesi", 15 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { new Guid("d5c14ce4-6a28-4b3e-88c9-18568646f460"), new Guid("bf6c8898-1dc7-49d3-ae3f-efcf099b8d15"), "Visual Studio ......", "Admin", new DateTime(2022, 11, 24, 13, 47, 38, 432, DateTimeKind.Local).AddTicks(9171), null, null, new Guid("ebe68fdd-4371-4a0f-860e-6755343f52ea"), false, null, null, "Visual Studio Deneme Makalesi", 15 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("6bd09613-971e-48c4-9054-22bbbf404498"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("d5c14ce4-6a28-4b3e-88c9-18568646f460"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a7dab329-8f34-4be7-bdfe-fccf7df783d1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bf6c8898-1dc7-49d3-ae3f-efcf099b8d15"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("998b5ce9-ce74-4646-bcf6-1f6631231f6b"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ebe68fdd-4371-4a0f-860e-6755343f52ea"));
        }
    }
}

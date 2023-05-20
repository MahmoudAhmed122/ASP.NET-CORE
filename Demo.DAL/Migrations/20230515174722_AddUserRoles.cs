using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.DAL.Migrations
{
    public partial class AddUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f638db2-e576-41ca-8eea-2cdad99836ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0b3ca42-d34e-4edc-b02f-b69036523c36");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ee18a14-43ce-49db-bed2-6e568c64e0e5", "2465fb4b-d8d1-43d9-9432-e95073370be0", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ec7afaf0-1f44-4cf2-9832-fd46a4c2b0dc", "08e74cb8-484f-4696-9d05-737337b3f5f4", "User", "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ee18a14-43ce-49db-bed2-6e568c64e0e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec7afaf0-1f44-4cf2-9832-fd46a4c2b0dc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f638db2-e576-41ca-8eea-2cdad99836ff", "b349f512-4b47-4042-bf29-3dabd6cf78e7", "ADMIN", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0b3ca42-d34e-4edc-b02f-b69036523c36", "ec8d83c9-de3a-4b1c-b1f1-33dc15e0e9e6", "USER", "user" });
        }
    }
}

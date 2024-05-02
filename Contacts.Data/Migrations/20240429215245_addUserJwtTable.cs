using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Contacts.Data.Migrations
{
    /// <inheritdoc />
    public partial class addUserJwtTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "1aa3d74f-ccb7-4912-9a83-9eb64bf41220");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "2f70c51d-c9b3-48cd-80a4-d9da8af665cd");

            migrationBuilder.CreateTable(
                name: "UserJwtToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJwtToken", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bdfced0d-ca08-439c-bc2f-9c3dbef9becc", "0805419f-4bf6-4bb8-8dbb-f93ba435f51b", "Admin", "ADMIN" },
                    { "da224b17-ec28-4fca-b82b-d6e9b4bff8e3", "60618c7a-114c-4070-b39c-401817b9fc08", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserJwtToken");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "bdfced0d-ca08-439c-bc2f-9c3dbef9becc");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "da224b17-ec28-4fca-b82b-d6e9b4bff8e3");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1aa3d74f-ccb7-4912-9a83-9eb64bf41220", "6712719c-bd3c-4e9a-80af-87f5fa883e08", "User", "USER" },
                    { "2f70c51d-c9b3-48cd-80a4-d9da8af665cd", "68c251e0-465b-471a-90da-6e6a7f74c1b7", "Admin", "ADMIN" }
                });
        }
    }
}

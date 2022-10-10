using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.DataAccess.Migrations
{
    public partial class AddDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "91c0cddc-0367-4796-a4db-9a0b7575ead3", "9c8e60b3-5044-4f6b-8a05-92c967b340b2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f24ff480-450b-4b8c-98d7-66d8d0f5805a", "cddeafab-2905-47ec-ae3c-6cc5c0645419", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91c0cddc-0367-4796-a4db-9a0b7575ead3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f24ff480-450b-4b8c-98d7-66d8d0f5805a");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customer.Services.ContactAPI.Migrations
{
    public partial class SeedContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "PersonalNumber", "Phone" },
                values: new object[] { 1, "umer.waqar@live.com", "202218051234", "+46768351295" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "PersonalNumber", "Phone" },
                values: new object[] { 2, "john.doe@noreply.com", "201218051234", "+46769120000" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "PersonalNumber", "Phone" },
                values: new object[] { 3, "chris.jericho@wwe.com", "201018051234", "+46760000000" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

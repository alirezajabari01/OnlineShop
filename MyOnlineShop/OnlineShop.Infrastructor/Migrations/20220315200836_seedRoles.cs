using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Infrastructor.Migrations
{
    public partial class seedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7200f30632b4742ad2a0ed4902049f9", "b0ae4265895643878cdf010610719615", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6da17853bad14f88b29b246e8ad4a085", "ae83cc896b484d9498cd3bf66ef2fcdc", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5dddd3a3e6949289c766384a8df4db3", "b2da4a92633d4bab94f615cf88be86d3", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6da17853bad14f88b29b246e8ad4a085");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a5dddd3a3e6949289c766384a8df4db3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e7200f30632b4742ad2a0ed4902049f9");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Infrastructor.Migrations
{
    public partial class seedRoleClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/authorizationdecision", "User", "6da17853bad14f88b29b246e8ad4a085" },
                    { 2, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/authorizationdecision", "Admin.RoleClaims", "a5dddd3a3e6949289c766384a8df4db3" },
                    { 3, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/authorizationdecision", "Admin.Roles", "a5dddd3a3e6949289c766384a8df4db3" },
                    { 4, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/authorizationdecision", "Admin.Comments", "a5dddd3a3e6949289c766384a8df4db3" },
                    { 5, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/authorizationdecision", "Admin.Products", "a5dddd3a3e6949289c766384a8df4db3" },
                    { 6, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/authorizationdecision", "Admin.Users", "a5dddd3a3e6949289c766384a8df4db3" },
                    { 7, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/authorizationdecision", "Admin.Category", "a5dddd3a3e6949289c766384a8df4db3" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6da17853bad14f88b29b246e8ad4a085",
                column: "ConcurrencyStamp",
                value: "2119fa81-14dc-45f1-8928-05ed92f40ac9");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a5dddd3a3e6949289c766384a8df4db3",
                column: "ConcurrencyStamp",
                value: "8a3987fd-bdbd-43eb-a666-47858e2c1a0d");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e7200f30632b4742ad2a0ed4902049f9",
                column: "ConcurrencyStamp",
                value: "43354421-d83c-4e14-9596-725d8539c23b");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6da17853bad14f88b29b246e8ad4a085",
                column: "ConcurrencyStamp",
                value: "03db31ab-71ae-4e60-a80c-dbc11c50e994");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a5dddd3a3e6949289c766384a8df4db3",
                column: "ConcurrencyStamp",
                value: "bbf7c0cb-cded-4df0-866d-0e625865c3ef");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e7200f30632b4742ad2a0ed4902049f9",
                column: "ConcurrencyStamp",
                value: "f22720ce-b507-448f-ae03-6ed8da57d5fd");
        }
    }
}

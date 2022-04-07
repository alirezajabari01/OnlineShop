using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Infrastructor.Migrations
{
    public partial class rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductRates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rate = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductRates_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductRates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductRates_ProductId",
                table: "ProductRates",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRates_UserId",
                table: "ProductRates",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductRates");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6da17853bad14f88b29b246e8ad4a085",
                column: "ConcurrencyStamp",
                value: "69879ba2-8794-4af2-96d1-f986db19fa76");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a5dddd3a3e6949289c766384a8df4db3",
                column: "ConcurrencyStamp",
                value: "b0cab012-1593-4187-bbc0-975e2a5e197b");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e7200f30632b4742ad2a0ed4902049f9",
                column: "ConcurrencyStamp",
                value: "e0675502-cfe9-4b62-ac93-f6264138dd7b");
        }
    }
}

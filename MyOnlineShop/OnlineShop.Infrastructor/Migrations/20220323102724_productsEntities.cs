using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Infrastructor.Migrations
{
    public partial class productsEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product_Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Categories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Categories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6da17853bad14f88b29b246e8ad4a085",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "dfbb44ef-cdc0-4ac5-9400-9472d5df72f4", null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a5dddd3a3e6949289c766384a8df4db3",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "b4fa1bd8-ec23-4ab4-902a-d5b5d7cad22b", null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e7200f30632b4742ad2a0ed4902049f9",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "6537cd7f-efc8-4fb1-ab45-0160a281ebfa", null });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Categories_CategoryId",
                table: "Product_Categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Categories_ProductId",
                table: "Product_Categories",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Categories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6da17853bad14f88b29b246e8ad4a085",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "ae83cc896b484d9498cd3bf66ef2fcdc", "USER" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a5dddd3a3e6949289c766384a8df4db3",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "b2da4a92633d4bab94f615cf88be86d3", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e7200f30632b4742ad2a0ed4902049f9",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "b0ae4265895643878cdf010610719615", "MANAGER" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Infrastructor.Migrations
{
    public partial class commentsEveryThings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Comment_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6da17853bad14f88b29b246e8ad4a085",
                column: "ConcurrencyStamp",
                value: "cbe909cc-8e3d-49bd-81e5-a8b4962b4940");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a5dddd3a3e6949289c766384a8df4db3",
                column: "ConcurrencyStamp",
                value: "c6711a04-da91-4d7e-90c9-5b4065f74d28");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e7200f30632b4742ad2a0ed4902049f9",
                column: "ConcurrencyStamp",
                value: "7bdb5694-6bfc-4c7f-aa0f-45303732d34f");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentId",
                table: "Comment",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ProductId",
                table: "Comment",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6da17853bad14f88b29b246e8ad4a085",
                column: "ConcurrencyStamp",
                value: "dfbb44ef-cdc0-4ac5-9400-9472d5df72f4");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a5dddd3a3e6949289c766384a8df4db3",
                column: "ConcurrencyStamp",
                value: "b4fa1bd8-ec23-4ab4-902a-d5b5d7cad22b");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e7200f30632b4742ad2a0ed4902049f9",
                column: "ConcurrencyStamp",
                value: "6537cd7f-efc8-4fb1-ab45-0160a281ebfa");
        }
    }
}

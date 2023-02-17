using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practicum.Repository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CompanyId", "CreatedDate" },
                values: new object[,]
                {
                    { 1, "Technologies", 1, new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(8017) },
                    { 2, "Stationery", 2, new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(8034) }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CompanyName", "CreatedDate" },
                values: new object[,]
                {
                    { 1, "Amazon", new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(8583) },
                    { 2, "HepsiBurada", new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(8607) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CompanyId", "CreatedDate", "Price", "ProductName", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(9076), 50m, "Mouse", 10 },
                    { 2, 1, 1, new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(9087), 10000m, "PC", 5 },
                    { 3, 1, 2, new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(9090), 100m, "Keyboard", 10 },
                    { 4, 2, 2, new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(9092), 100m, "Book", 10 },
                    { 5, 2, 2, new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(9094), 10m, "Pencil", 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}

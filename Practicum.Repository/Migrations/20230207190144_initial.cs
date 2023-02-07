using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practicum.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Price", "ProductName", "Stock" },
                values: new object[] { 1, new DateTime(2023, 2, 7, 22, 1, 43, 720, DateTimeKind.Local).AddTicks(6011), 50m, "Mouse", 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Price", "ProductName", "Stock" },
                values: new object[] { 2, new DateTime(2023, 2, 7, 22, 1, 43, 720, DateTimeKind.Local).AddTicks(6027), 10000m, "PC", 5 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Price", "ProductName", "Stock" },
                values: new object[] { 3, new DateTime(2023, 2, 7, 22, 1, 43, 720, DateTimeKind.Local).AddTicks(6029), 100m, "Keyboard", 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

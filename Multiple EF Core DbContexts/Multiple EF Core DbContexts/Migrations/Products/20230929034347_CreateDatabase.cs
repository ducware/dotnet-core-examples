using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Multiple_EF_Core_DbContexts.Migrations.Products
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "products");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "products",
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("6e8908a0-bff6-4d8d-b61e-9adbde4d5c84"), "Product #1", 100m },
                    { new Guid("a41f7d97-b798-4043-8618-baa01ffb9ddf"), "Product #3", 300m },
                    { new Guid("b24c2b91-5265-48a5-acba-2d972484cfb6"), "Product #4", 400m },
                    { new Guid("d981534b-c129-442b-9eb1-029907aacc01"), "Product #5", 500m },
                    { new Guid("f2e9c76d-f800-45a2-af49-47b443e400c0"), "Product #2", 200m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "products");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GraphQL_Example.Migrations
{
    /// <inheritdoc />
    public partial class AddCake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "graphql");

            migrationBuilder.CreateTable(
                name: "Cakes",
                schema: "graphql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cakes", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "graphql",
                table: "Cakes",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description #111", "Cake #1", 100m },
                    { 2, "Description #222", "Cake #2", 200m },
                    { 3, "Description #333", "Cake #3", 300m },
                    { 4, "Description #444", "Cake #4", 400m },
                    { 5, "Description #555", "Cake #5", 500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cakes",
                schema: "graphql");
        }
    }
}

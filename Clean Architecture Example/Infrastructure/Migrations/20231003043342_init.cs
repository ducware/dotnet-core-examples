using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "clean");

            migrationBuilder.CreateTable(
                name: "Animals",
                schema: "clean",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IsBird = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "clean",
                table: "Animals",
                columns: new[] { "Id", "Age", "CreatedAt", "Description", "IsBird", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 3, 11, 33, 42, 483, DateTimeKind.Local).AddTicks(8204), "Description #1", false, "Animal #1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2023, 10, 3, 11, 33, 42, 484, DateTimeKind.Local).AddTicks(8822), "Description #2", false, "Animal #2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2023, 10, 3, 11, 33, 42, 484, DateTimeKind.Local).AddTicks(8831), "Description #3", false, "Animal #3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2023, 10, 3, 11, 33, 42, 484, DateTimeKind.Local).AddTicks(8885), "Description #4", false, "Animal #4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2023, 10, 3, 11, 33, 42, 484, DateTimeKind.Local).AddTicks(8886), "Description #5", false, "Animal #5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals",
                schema: "clean");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChatSystem.Migrations
{
    /// <inheritdoc />
    public partial class OnetoMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "electronics" },
                    { 2, "books" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "id",
                keyValue: 5,
                column: "categoryId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Items_categoryId",
                table: "Items",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_categoryId",
                table: "Items",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_categoryId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Items_categoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Items");
        }
    }
}

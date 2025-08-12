using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatSystem.Migrations
{
    /// <inheritdoc />
    public partial class OnetoOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "serialNumberId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SerialNumbers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialNumbers", x => x.id);
                    table.ForeignKey(
                        name: "FK_SerialNumbers_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "id", "name", "price", "serialNumberId" },
                values: new object[] { 5, "controller", 321.69, 10 });

            migrationBuilder.InsertData(
                table: "SerialNumbers",
                columns: new[] { "id", "itemId", "name" },
                values: new object[] { 10, 5, "cont" });

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumbers_itemId",
                table: "SerialNumbers",
                column: "itemId",
                unique: true,
                filter: "[itemId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SerialNumbers");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "serialNumberId",
                table: "Items");
        }
    }
}

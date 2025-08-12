using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatSystem.Migrations
{
    /// <inheritdoc />
    public partial class ManytoMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ItemClients",
                columns: table => new
                {
                    itemId = table.Column<int>(type: "int", nullable: false),
                    clientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemClients", x => new { x.itemId, x.clientId });
                    table.ForeignKey(
                        name: "FK_ItemClients_Clients_clientId",
                        column: x => x.clientId,
                        principalTable: "Clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemClients_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemClients_clientId",
                table: "ItemClients",
                column: "clientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemClients");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}

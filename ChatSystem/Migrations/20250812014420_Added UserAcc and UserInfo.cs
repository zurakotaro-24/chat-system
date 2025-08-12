using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserAccandUserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInformations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    extensionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthday = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserAccounts_UserInformations_id",
                        column: x => x.id,
                        principalTable: "UserInformations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "UserInformations");
        }
    }
}

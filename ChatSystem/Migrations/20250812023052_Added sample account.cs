using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatSystem.Migrations
{
    /// <inheritdoc />
    public partial class Addedsampleaccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserInformations",
                columns: new[] { "id", "birthday", "extensionName", "firstName", "lastName", "middleName", "sex" },
                values: new object[] { 1, new DateOnly(2003, 2, 24), null, "First", "Last", "Middle", "Male" });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "id", "password", "username" },
                values: new object[] { 1, "pass", "user" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserInformations",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}

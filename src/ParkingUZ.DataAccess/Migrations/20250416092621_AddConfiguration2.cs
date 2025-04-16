using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingUZ.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddConfiguration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bc56836e-0345-4f01-a883-47f39e32e079"),
                column: "Password",
                value: null);
        }
    }
}

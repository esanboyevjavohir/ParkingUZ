using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingUZ.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardType",
                table: "Payments",
                newName: "PaymentType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentType",
                table: "Payments",
                newName: "CardType");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingUZ.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatedEntity1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Discounts_ParkingZoneId",
                table: "Discounts");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ParkingZoneId",
                table: "Discounts",
                column: "ParkingZoneId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Discounts_ParkingZoneId",
                table: "Discounts");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ParkingZoneId",
                table: "Discounts",
                column: "ParkingZoneId");
        }
    }
}

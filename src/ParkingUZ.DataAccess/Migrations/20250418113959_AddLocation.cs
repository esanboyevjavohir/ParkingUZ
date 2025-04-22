using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingUZ.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingZones_GeoLocation_GeoLocationId",
                table: "ParkingZones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeoLocation",
                table: "GeoLocation");

            migrationBuilder.RenameTable(
                name: "GeoLocation",
                newName: "Locations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingZones_Locations_GeoLocationId",
                table: "ParkingZones",
                column: "GeoLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingZones_Locations_GeoLocationId",
                table: "ParkingZones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "GeoLocation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeoLocation",
                table: "GeoLocation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingZones_GeoLocation_GeoLocationId",
                table: "ParkingZones",
                column: "GeoLocationId",
                principalTable: "GeoLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingUZ.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class deletedEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingZones_Locations_GeoLocationId",
                table: "ParkingZones");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_ParkingZones_GeoLocationId",
                table: "ParkingZones");

            migrationBuilder.DropColumn(
                name: "GeoLocationId",
                table: "ParkingZones");

            migrationBuilder.AddColumn<decimal>(
                name: "XCoordinate",
                table: "ParkingZones",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "YCoordinate",
                table: "ParkingZones",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "XCoordinate",
                table: "ParkingZones");

            migrationBuilder.DropColumn(
                name: "YCoordinate",
                table: "ParkingZones");

            migrationBuilder.AddColumn<Guid>(
                name: "GeoLocationId",
                table: "ParkingZones",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    XCoordinate = table.Column<decimal>(type: "numeric", nullable: false),
                    YCoordinate = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingZones_GeoLocationId",
                table: "ParkingZones",
                column: "GeoLocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingZones_Locations_GeoLocationId",
                table: "ParkingZones",
                column: "GeoLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

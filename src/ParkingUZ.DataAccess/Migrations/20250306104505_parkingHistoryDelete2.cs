using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingUZ.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class parkingHistoryDelete2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ParkingSpots_ParkingSpotId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ParkSubsId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "SpotId",
                table: "Reservations");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParkingSpotId",
                table: "Reservations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ParkingSpots_ParkingSpotId",
                table: "Reservations",
                column: "ParkingSpotId",
                principalTable: "ParkingSpots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ParkingSpots_ParkingSpotId",
                table: "Reservations");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParkingSpotId",
                table: "Reservations",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "ParkSubsId",
                table: "Reservations",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SpotId",
                table: "Reservations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ParkingSpots_ParkingSpotId",
                table: "Reservations",
                column: "ParkingSpotId",
                principalTable: "ParkingSpots",
                principalColumn: "Id");
        }
    }
}

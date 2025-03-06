using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingUZ.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class parkingHistoryDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingHistorys");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Reservations");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckInTime",
                table: "Reservations",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOutTime",
                table: "Reservations",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPaid",
                table: "Reservations",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckInTime",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CheckOutTime",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TotalPaid",
                table: "Reservations");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Reservations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ParkingHistorys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParkingSpotId = table.Column<Guid>(type: "uuid", nullable: true),
                    ParkingZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CheckOutTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    SpotId = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalPaid = table.Column<decimal>(type: "numeric", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingHistorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingHistorys_ParkingSpots_ParkingSpotId",
                        column: x => x.ParkingSpotId,
                        principalTable: "ParkingSpots",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParkingHistorys_ParkingZones_ParkingZoneId",
                        column: x => x.ParkingZoneId,
                        principalTable: "ParkingZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingHistorys_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingHistorys_ParkingSpotId",
                table: "ParkingHistorys",
                column: "ParkingSpotId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingHistorys_ParkingZoneId",
                table: "ParkingHistorys",
                column: "ParkingZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingHistorys_UserId",
                table: "ParkingHistorys",
                column: "UserId");
        }
    }
}

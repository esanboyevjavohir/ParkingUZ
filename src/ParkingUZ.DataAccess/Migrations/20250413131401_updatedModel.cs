using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingUZ.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SubscriptionPlans");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SubscriptionPlans");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "QRCodes");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "QRCodes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ParkingZones");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ParkingZones");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ParkingSubscriptions");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ParkingSubscriptions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ParkingSpots");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ParkingSpots");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GeoLocation");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "GeoLocation");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Discounts");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "User",
                newName: "ResetPasswordToken");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "User",
                newName: "RefreshToken");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpireDate",
                table: "User",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetPasswordTokenExpiry",
                table: "User",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OtpCode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtpCode_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtpCode_UserId",
                table: "OtpCode",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtpCode");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpireDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ResetPasswordTokenExpiry",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "ResetPasswordToken",
                table: "User",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "User",
                newName: "CreatedBy");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SubscriptionPlans",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "SubscriptionPlans",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Reviews",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Reviews",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Reservations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Reservations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "QRCodes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "QRCodes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Payments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Payments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ParkingZones",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ParkingZones",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ParkingSubscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ParkingSubscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ParkingSpots",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ParkingSpots",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GeoLocation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "GeoLocation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Discounts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Discounts",
                type: "text",
                nullable: true);
        }
    }
}

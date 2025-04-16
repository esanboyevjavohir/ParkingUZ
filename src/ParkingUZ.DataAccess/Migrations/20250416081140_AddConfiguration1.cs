using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingUZ.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddConfiguration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bc56836e-0345-4f01-a883-47f39e32e079"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "AKlJ3Kv+/m1pYHf4ZKL4iEoWm1d6BD8QKGrD4w5e2Go=", "5bd421f2-1e10-4dd9-81ff-e26c83e33b2f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bc56836e-0345-4f01-a883-47f39e32e079"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "xV0BJa6RsmnTyrkd4Zg3aAG2o65JHqGqCEjU6QFzzX8=", "61fc4177-1226-4a48-b58c-a7475412e31a" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarriotTest.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HasWarning",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    WarningTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    WarningType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HasWarning", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TempLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DeviceTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Altitude = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Course = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Satellites = table.Column<int>(type: "int", nullable: false),
                    SpeedOTG = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    AccelerationX1 = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    AccelerationY1 = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Signal = table.Column<int>(type: "int", nullable: false),
                    PowerSupply = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempLog", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HasWarning");

            migrationBuilder.DropTable(
                name: "TempLog");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrashTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedScheduleDriver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Users_DriverId",
                table: "Schedules");

            migrationBuilder.DropTable(
                name: "ScheduleDriverUser");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_DriverId",
                table: "Schedules");

            migrationBuilder.DeleteData(
                table: "Garbages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "ScheduleDrivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ScheduleDrivers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDrivers_UserId",
                table: "ScheduleDrivers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDrivers_Users_UserId",
                table: "ScheduleDrivers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDrivers_Users_UserId",
                table: "ScheduleDrivers");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleDrivers_UserId",
                table: "ScheduleDrivers");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "ScheduleDrivers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ScheduleDrivers");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ScheduleDriverUser",
                columns: table => new
                {
                    DriversId = table.Column<int>(type: "int", nullable: false),
                    ScheduleDriversId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDriverUser", x => new { x.DriversId, x.ScheduleDriversId });
                    table.ForeignKey(
                        name: "FK_ScheduleDriverUser_ScheduleDrivers_ScheduleDriversId",
                        column: x => x.ScheduleDriversId,
                        principalTable: "ScheduleDrivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleDriverUser_Users_DriversId",
                        column: x => x.DriversId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Garbages",
                columns: new[] { "Id", "Address", "CreatedAt", "GarbageType", "Latitude", "Longitude", "ModifiedAt" },
                values: new object[] { 1, "dwudid", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), 0, 10m, 10m, null });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DriverId",
                table: "Schedules",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDriverUser_ScheduleDriversId",
                table: "ScheduleDriverUser",
                column: "ScheduleDriversId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Users_DriverId",
                table: "Schedules",
                column: "DriverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

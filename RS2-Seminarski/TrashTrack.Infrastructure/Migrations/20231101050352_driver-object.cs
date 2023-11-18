using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrashTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class driverobject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDrivers_Users_UserId",
                table: "ScheduleDrivers");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleDrivers_UserId",
                table: "ScheduleDrivers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ScheduleDrivers");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDrivers_DriverId",
                table: "ScheduleDrivers",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDrivers_Users_DriverId",
                table: "ScheduleDrivers",
                column: "DriverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDrivers_Users_DriverId",
                table: "ScheduleDrivers");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleDrivers_DriverId",
                table: "ScheduleDrivers");

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
    }
}

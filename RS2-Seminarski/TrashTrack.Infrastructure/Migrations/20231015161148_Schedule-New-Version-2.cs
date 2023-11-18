using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrashTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ScheduleNewVersion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GarbageScheduleGarbage");

            migrationBuilder.AddColumn<int>(
                name: "GarbageId",
                table: "ScheduleGarbages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleGarbages_GarbageId",
                table: "ScheduleGarbages",
                column: "GarbageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleGarbages_Garbages_GarbageId",
                table: "ScheduleGarbages",
                column: "GarbageId",
                principalTable: "Garbages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleGarbages_Garbages_GarbageId",
                table: "ScheduleGarbages");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleGarbages_GarbageId",
                table: "ScheduleGarbages");

            migrationBuilder.DropColumn(
                name: "GarbageId",
                table: "ScheduleGarbages");

            migrationBuilder.CreateTable(
                name: "GarbageScheduleGarbage",
                columns: table => new
                {
                    GarbagesId = table.Column<int>(type: "int", nullable: false),
                    ScheduleGarbagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarbageScheduleGarbage", x => new { x.GarbagesId, x.ScheduleGarbagesId });
                    table.ForeignKey(
                        name: "FK_GarbageScheduleGarbage_Garbages_GarbagesId",
                        column: x => x.GarbagesId,
                        principalTable: "Garbages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GarbageScheduleGarbage_ScheduleGarbages_ScheduleGarbagesId",
                        column: x => x.ScheduleGarbagesId,
                        principalTable: "ScheduleGarbages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GarbageScheduleGarbage_ScheduleGarbagesId",
                table: "GarbageScheduleGarbage",
                column: "ScheduleGarbagesId");
        }
    }
}

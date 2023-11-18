using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrashTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OccupancyGarbage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Occupancy",
                table: "Garbages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Occupancy",
                table: "Garbages");
        }
    }
}

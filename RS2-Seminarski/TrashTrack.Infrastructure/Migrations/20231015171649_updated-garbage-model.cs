using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrashTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedgarbagemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Garbages",
                newName: "Address");

            migrationBuilder.InsertData(
                table: "Garbages",
                columns: new[] { "Id", "Address", "CreatedAt", "GarbageType", "Latitude", "Longitude", "ModifiedAt" },
                values: new object[] { 1, "dwudid", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), 0, 10m, 10m, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Garbages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Garbages",
                newName: "Description");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrashTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUserPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Photos_ProfilePhotoId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ProfilePhotoId",
                table: "Users",
                newName: "PhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ProfilePhotoId",
                table: "Users",
                newName: "IX_Users_PhotoId");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NotificationsRabbit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationsRabbit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationsRabbit_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Photo",
                value: null);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Balance", "Biography", "BirthDate", "CreatedAt", "Email", "FirstName", "Gender", "IsActive", "IsVerified", "LastName", "LastSignInAt", "ModifiedAt", "PasswordHash", "PasswordSalt", "PhoneNumber", "Photo", "PhotoId", "Role" },
                values: new object[] { 2, 0m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), "hamza.admin@TrashTrack.com", "Hamza", 0, true, true, "Taslidza", null, null, "b4I5yA4Mp+0Pg1C3EsKU17sS13eDExGtBjjI07Vh/JM=", "1wQEjdSFeZttx6dlvEDjOg==", "38761123456", null, null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsRabbit_UserId",
                table: "NotificationsRabbit",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Photos_PhotoId",
                table: "Users",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Photos_PhotoId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "NotificationsRabbit");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PhotoId",
                table: "Users",
                newName: "ProfilePhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PhotoId",
                table: "Users",
                newName: "IX_Users_ProfilePhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Photos_ProfilePhotoId",
                table: "Users",
                column: "ProfilePhotoId",
                principalTable: "Photos",
                principalColumn: "Id");
        }
    }
}

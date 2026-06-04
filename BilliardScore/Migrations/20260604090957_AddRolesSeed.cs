using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BilliardScore.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlayerProfiles_UserId",
                table: "PlayerProfiles");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleRoleId",
                table: "UserRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRoleUserId",
                table: "UserRoles",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 6, 4, 9, 9, 56, 779, DateTimeKind.Utc).AddTicks(4611), "Admin" },
                    { 2, new DateTime(2026, 6, 4, 9, 9, 56, 779, DateTimeKind.Utc).AddTicks(4614), "TournamentOwner" },
                    { 3, new DateTime(2026, 6, 4, 9, 9, 56, 779, DateTimeKind.Utc).AddTicks(4614), "Player" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserRoleUserId_UserRoleRoleId",
                table: "UserRoles",
                columns: new[] { "UserRoleUserId", "UserRoleRoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerProfiles_UserId",
                table: "PlayerProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_UserRoles_UserRoleUserId_UserRoleRoleId",
                table: "UserRoles",
                columns: new[] { "UserRoleUserId", "UserRoleRoleId" },
                principalTable: "UserRoles",
                principalColumns: new[] { "UserId", "RoleId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_UserRoles_UserRoleUserId_UserRoleRoleId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserRoleUserId_UserRoleRoleId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_PlayerProfiles_UserId",
                table: "PlayerProfiles");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "UserRoleRoleId",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "UserRoleUserId",
                table: "UserRoles");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerProfiles_UserId",
                table: "PlayerProfiles",
                column: "UserId");
        }
    }
}

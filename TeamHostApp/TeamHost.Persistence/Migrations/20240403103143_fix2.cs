using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamHost.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaticFiles_Games_GameId1",
                table: "StaticFiles");

            migrationBuilder.DropIndex(
                name: "IX_StaticFiles_GameId1",
                table: "StaticFiles");

            migrationBuilder.DropColumn(
                name: "GameId1",
                table: "StaticFiles");

            migrationBuilder.AddColumn<int>(
                name: "MainImageId",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MainImageId1",
                table: "Games",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_MainImageId1",
                table: "Games",
                column: "MainImageId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_StaticFiles_MainImageId1",
                table: "Games",
                column: "MainImageId1",
                principalTable: "StaticFiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_StaticFiles_MainImageId1",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_MainImageId1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "MainImageId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "MainImageId1",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameId1",
                table: "StaticFiles",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaticFiles_GameId1",
                table: "StaticFiles",
                column: "GameId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StaticFiles_Games_GameId1",
                table: "StaticFiles",
                column: "GameId1",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}

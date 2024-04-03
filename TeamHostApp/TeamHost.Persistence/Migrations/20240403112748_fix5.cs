using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamHost.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fix5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Companies_CompanyId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_CompanyId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameId1",
                table: "Platforms",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_GameId1",
                table: "Platforms",
                column: "GameId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Platforms_Games_GameId1",
                table: "Platforms",
                column: "GameId1",
                principalTable: "Games",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Platforms_Games_GameId1",
                table: "Platforms");

            migrationBuilder.DropIndex(
                name: "IX_Platforms_GameId1",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "GameId1",
                table: "Platforms");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_CompanyId",
                table: "Games",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Companies_CompanyId",
                table: "Games",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

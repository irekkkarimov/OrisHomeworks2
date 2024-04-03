using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamHost.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_StaticFiles_MainImageId1",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_MainImageId1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "MainImageId1",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "StaticFiles",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Games_MainImageId",
                table: "Games",
                column: "MainImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_StaticFiles_MainImageId",
                table: "Games",
                column: "MainImageId",
                principalTable: "StaticFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_StaticFiles_MainImageId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_MainImageId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "StaticFiles",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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
    }
}

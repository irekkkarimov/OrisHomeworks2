using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamHost.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fix4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Companies_CompanyDeveloperId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_StaticFiles_MainImageId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_CompanyDeveloperId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CompanyDeveloperId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "MainImageId",
                table: "Games",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_MainImageId",
                table: "Games",
                newName: "IX_Games_CompanyId");

            migrationBuilder.AddColumn<bool>(
                name: "IsMainImage",
                table: "StaticFiles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Companies_CompanyId",
                table: "Games",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Companies_CompanyId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "IsMainImage",
                table: "StaticFiles");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Games",
                newName: "MainImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_CompanyId",
                table: "Games",
                newName: "IX_Games_MainImageId");

            migrationBuilder.AddColumn<int>(
                name: "CompanyDeveloperId",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_CompanyDeveloperId",
                table: "Games",
                column: "CompanyDeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Companies_CompanyDeveloperId",
                table: "Games",
                column: "CompanyDeveloperId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_StaticFiles_MainImageId",
                table: "Games",
                column: "MainImageId",
                principalTable: "StaticFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

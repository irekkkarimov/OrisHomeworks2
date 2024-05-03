using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamHost.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditedMessageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_UserInfos_UserInfoId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "UserInfoId",
                table: "Messages",
                newName: "SenderInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserInfoId",
                table: "Messages",
                newName: "IX_Messages_SenderInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_UserInfos_SenderInfoId",
                table: "Messages",
                column: "SenderInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_UserInfos_SenderInfoId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "SenderInfoId",
                table: "Messages",
                newName: "UserInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderInfoId",
                table: "Messages",
                newName: "IX_Messages_UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_UserInfos_UserInfoId",
                table: "Messages",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

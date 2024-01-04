using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaSiteAPI.Migrations
{
    /// <inheritdoc />
    public partial class user4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_AspNetUsers_UsersId",
                table: "UserFriends");

            migrationBuilder.DropColumn(
                name: "User",
                table: "UserFriends");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "UserFriends",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFriends_UsersId",
                table: "UserFriends",
                newName: "IX_UserFriends_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId",
                table: "UserFriends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId",
                table: "UserFriends");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserFriends",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFriends_UserId",
                table: "UserFriends",
                newName: "IX_UserFriends_UsersId");

            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "UserFriends",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_UsersId",
                table: "UserFriends",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

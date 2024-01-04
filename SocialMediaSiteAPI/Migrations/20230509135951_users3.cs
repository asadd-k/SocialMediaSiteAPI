using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaSiteAPI.Migrations
{
    /// <inheritdoc />
    public partial class users3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_AspNetUsers_FriendNoId",
                table: "UserFriends");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserFriends",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "FriendNoId",
                table: "UserFriends",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "Friend",
                table: "UserFriends",
                newName: "FriendID");

            migrationBuilder.RenameIndex(
                name: "IX_UserFriends_FriendNoId",
                table: "UserFriends",
                newName: "IX_UserFriends_UsersId");

            migrationBuilder.AlterColumn<string>(
                name: "FriendUserName",
                table: "UserFriends",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_UsersId",
                table: "UserFriends",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_AspNetUsers_UsersId",
                table: "UserFriends");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "UserFriends",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "UserFriends",
                newName: "FriendNoId");

            migrationBuilder.RenameColumn(
                name: "FriendID",
                table: "UserFriends",
                newName: "Friend");

            migrationBuilder.RenameIndex(
                name: "IX_UserFriends_UsersId",
                table: "UserFriends",
                newName: "IX_UserFriends_FriendNoId");

            migrationBuilder.AlterColumn<int>(
                name: "FriendUserName",
                table: "UserFriends",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_FriendNoId",
                table: "UserFriends",
                column: "FriendNoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

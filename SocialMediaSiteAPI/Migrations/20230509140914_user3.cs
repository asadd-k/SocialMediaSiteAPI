using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaSiteAPI.Migrations
{
    /// <inheritdoc />
    public partial class user3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FriendUserName",
                table: "UserFriends",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "FriendID",
                table: "UserFriends",
                newName: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserFriends",
                newName: "FriendUserName");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "UserFriends",
                newName: "FriendID");
        }
    }
}

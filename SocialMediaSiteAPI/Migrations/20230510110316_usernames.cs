using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaSiteAPI.Migrations
{
    /// <inheritdoc />
    public partial class usernames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserFriends",
                newName: "FriendUserName");

            migrationBuilder.AddColumn<string>(
                name: "FriendName",
                table: "UserFriends",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FriendName",
                table: "UserFriends");

            migrationBuilder.RenameColumn(
                name: "FriendUserName",
                table: "UserFriends",
                newName: "UserName");
        }
    }
}

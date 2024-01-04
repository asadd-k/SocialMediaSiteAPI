using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaSiteAPI.Migrations
{
    /// <inheritdoc />
    public partial class username2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserFriends",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UserFriends",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserFriends");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UserFriends");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaSiteAPI.Migrations
{
    /// <inheritdoc />
    public partial class users2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFriends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendUserName = table.Column<int>(type: "int", nullable: false),
                    Friend = table.Column<int>(type: "int", nullable: false),
                    FriendNoId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFriends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFriends_AspNetUsers_FriendNoId",
                        column: x => x.FriendNoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_FriendNoId",
                table: "UserFriends",
                column: "FriendNoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFriends");
        }
    }
}

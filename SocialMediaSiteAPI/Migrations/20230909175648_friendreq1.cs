using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaSiteAPI.Migrations
{
    /// <inheritdoc />
    public partial class friendreq1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesVideos_Posts_PostsId",
                table: "ImagesVideos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagesVideos",
                table: "ImagesVideos");

            migrationBuilder.RenameTable(
                name: "ImagesVideos",
                newName: "PostImagesVideos");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesVideos_PostsId",
                table: "PostImagesVideos",
                newName: "IX_PostImagesVideos_PostsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostImagesVideos",
                table: "PostImagesVideos",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "FriendRequests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNameToAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FriendRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_UserId",
                table: "FriendRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostImagesVideos_Posts_PostsId",
                table: "PostImagesVideos",
                column: "PostsId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostImagesVideos_Posts_PostsId",
                table: "PostImagesVideos");

            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostImagesVideos",
                table: "PostImagesVideos");

            migrationBuilder.RenameTable(
                name: "PostImagesVideos",
                newName: "ImagesVideos");

            migrationBuilder.RenameIndex(
                name: "IX_PostImagesVideos_PostsId",
                table: "ImagesVideos",
                newName: "IX_ImagesVideos_PostsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagesVideos",
                table: "ImagesVideos",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesVideos_Posts_PostsId",
                table: "ImagesVideos",
                column: "PostsId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

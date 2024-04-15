using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MutualFriends",
                columns: table => new
                {
                    FriendEntityId = table.Column<int>(type: "int", nullable: false),
                    MutualFriendsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MutualFriends", x => new { x.FriendEntityId, x.MutualFriendsId });
                    table.ForeignKey(
                        name: "FK_MutualFriends_Friends_FriendEntityId",
                        column: x => x.FriendEntityId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MutualFriends_Friends_MutualFriendsId",
                        column: x => x.MutualFriendsId,
                        principalTable: "Friends",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MutualFriends_MutualFriendsId",
                table: "MutualFriends",
                column: "MutualFriendsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MutualFriends");
        }
    }
}

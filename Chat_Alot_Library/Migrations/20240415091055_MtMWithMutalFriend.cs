using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MtMWithMutalFriend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MutualFriends_Friends_FriendEntityId",
                table: "MutualFriends");

            migrationBuilder.DropForeignKey(
                name: "FK_MutualFriends_Friends_MutualFriendsId",
                table: "MutualFriends");

            migrationBuilder.RenameColumn(
                name: "MutualFriendsId",
                table: "MutualFriends",
                newName: "MutualFriendId");

            migrationBuilder.RenameColumn(
                name: "FriendEntityId",
                table: "MutualFriends",
                newName: "FriendId");

            migrationBuilder.RenameIndex(
                name: "IX_MutualFriends_MutualFriendsId",
                table: "MutualFriends",
                newName: "IX_MutualFriends_MutualFriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_MutualFriends_Friends_FriendId",
                table: "MutualFriends",
                column: "FriendId",
                principalTable: "Friends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MutualFriends_Friends_MutualFriendId",
                table: "MutualFriends",
                column: "MutualFriendId",
                principalTable: "Friends",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MutualFriends_Friends_FriendId",
                table: "MutualFriends");

            migrationBuilder.DropForeignKey(
                name: "FK_MutualFriends_Friends_MutualFriendId",
                table: "MutualFriends");

            migrationBuilder.RenameColumn(
                name: "MutualFriendId",
                table: "MutualFriends",
                newName: "MutualFriendsId");

            migrationBuilder.RenameColumn(
                name: "FriendId",
                table: "MutualFriends",
                newName: "FriendEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_MutualFriends_MutualFriendId",
                table: "MutualFriends",
                newName: "IX_MutualFriends_MutualFriendsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MutualFriends_Friends_FriendEntityId",
                table: "MutualFriends",
                column: "FriendEntityId",
                principalTable: "Friends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MutualFriends_Friends_MutualFriendsId",
                table: "MutualFriends",
                column: "MutualFriendsId",
                principalTable: "Friends",
                principalColumn: "Id");
        }
    }
}

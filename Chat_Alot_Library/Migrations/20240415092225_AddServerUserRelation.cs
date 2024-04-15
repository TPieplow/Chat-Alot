using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddServerUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServerEntityUserEntity");

            migrationBuilder.CreateTable(
                name: "ServerUser",
                columns: table => new
                {
                    ServerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerUser", x => new { x.ServerId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ServerUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServerUser_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServerUser_UserId",
                table: "ServerUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServerUser");

            migrationBuilder.CreateTable(
                name: "ServerEntityUserEntity",
                columns: table => new
                {
                    MembersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerEntityUserEntity", x => new { x.MembersId, x.ServersId });
                    table.ForeignKey(
                        name: "FK_ServerEntityUserEntity_AspNetUsers_MembersId",
                        column: x => x.MembersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServerEntityUserEntity_Servers_ServersId",
                        column: x => x.ServersId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServerEntityUserEntity_ServersId",
                table: "ServerEntityUserEntity",
                column: "ServersId");
        }
    }
}

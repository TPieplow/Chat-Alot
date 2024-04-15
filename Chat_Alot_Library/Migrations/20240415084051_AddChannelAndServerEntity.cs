using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChannelAndServerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServerDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Channels_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_ChannelId",
                table: "Channels",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServerId",
                table: "Channels",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerEntityUserEntity_ServersId",
                table: "ServerEntityUserEntity",
                column: "ServersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "ServerEntityUserEntity");

            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}

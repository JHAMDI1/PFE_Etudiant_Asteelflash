using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFE_Etudiant_Asteelflash.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersZapsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Zap_ZapId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ZapId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZapId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UsersZaps",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ZapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersZaps", x => new { x.UserId, x.ZapId });
                    table.ForeignKey(
                        name: "FK_UsersZaps_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersZaps_Zap_ZapId",
                        column: x => x.ZapId,
                        principalTable: "Zap",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersZaps_ZapId",
                table: "UsersZaps",
                column: "ZapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersZaps");

            migrationBuilder.AddColumn<int>(
                name: "ZapId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ZapId",
                table: "AspNetUsers",
                column: "ZapId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Zap_ZapId",
                table: "AspNetUsers",
                column: "ZapId",
                principalTable: "Zap",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFE_Etudiant_Asteelflash.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class ClotureQrqc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ClotureDecisionAt",
                table: "Qrqc",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClotureDecisionById",
                table: "Qrqc",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClotureDecisionComment",
                table: "Qrqc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClotureToken",
                table: "Qrqc",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClotureTokenExpiry",
                table: "Qrqc",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Qrqc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Qrqc_ClotureDecisionById",
                table: "Qrqc",
                column: "ClotureDecisionById");

            migrationBuilder.AddForeignKey(
                name: "FK_Qrqc_AspNetUsers_ClotureDecisionById",
                table: "Qrqc",
                column: "ClotureDecisionById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Qrqc_AspNetUsers_ClotureDecisionById",
                table: "Qrqc");

            migrationBuilder.DropIndex(
                name: "IX_Qrqc_ClotureDecisionById",
                table: "Qrqc");

            migrationBuilder.DropColumn(
                name: "ClotureDecisionAt",
                table: "Qrqc");

            migrationBuilder.DropColumn(
                name: "ClotureDecisionById",
                table: "Qrqc");

            migrationBuilder.DropColumn(
                name: "ClotureDecisionComment",
                table: "Qrqc");

            migrationBuilder.DropColumn(
                name: "ClotureToken",
                table: "Qrqc");

            migrationBuilder.DropColumn(
                name: "ClotureTokenExpiry",
                table: "Qrqc");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Qrqc");
        }
    }
}

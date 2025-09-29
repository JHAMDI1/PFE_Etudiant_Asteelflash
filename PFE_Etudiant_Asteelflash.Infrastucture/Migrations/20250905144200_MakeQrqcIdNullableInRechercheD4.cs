using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFE_Etudiant_Asteelflash.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class MakeQrqcIdNullableInRechercheD4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QrqcId",
                table: "Recherche_causes_racinesD4",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recherche_causes_racinesD4_QrqcId",
                table: "Recherche_causes_racinesD4",
                column: "QrqcId",
                unique: true,
                filter: "[QrqcId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Recherche_causes_racinesD4_Qrqc_QrqcId",
                table: "Recherche_causes_racinesD4",
                column: "QrqcId",
                principalTable: "Qrqc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recherche_causes_racinesD4_Qrqc_QrqcId",
                table: "Recherche_causes_racinesD4");

            migrationBuilder.DropIndex(
                name: "IX_Recherche_causes_racinesD4_QrqcId",
                table: "Recherche_causes_racinesD4");

            migrationBuilder.DropColumn(
                name: "QrqcId",
                table: "Recherche_causes_racinesD4");
        }
    }
}

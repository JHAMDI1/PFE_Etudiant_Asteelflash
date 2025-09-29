using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFE_Etudiant_Asteelflash.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class AddFncTriPlanRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TriFnc_FncId",
                table: "TriFnc");

            migrationBuilder.DropIndex(
                name: "IX_PlanActionFnc_FncId",
                table: "PlanActionFnc");

            migrationBuilder.AddColumn<int>(
                name: "TraitementChoisi",
                table: "Fnc",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TriFnc_FncId",
                table: "TriFnc",
                column: "FncId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanActionFnc_FncId",
                table: "PlanActionFnc",
                column: "FncId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TriFnc_FncId",
                table: "TriFnc");

            migrationBuilder.DropIndex(
                name: "IX_PlanActionFnc_FncId",
                table: "PlanActionFnc");

            migrationBuilder.DropColumn(
                name: "TraitementChoisi",
                table: "Fnc");

            migrationBuilder.CreateIndex(
                name: "IX_TriFnc_FncId",
                table: "TriFnc",
                column: "FncId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanActionFnc_FncId",
                table: "PlanActionFnc",
                column: "FncId");
        }
    }
}

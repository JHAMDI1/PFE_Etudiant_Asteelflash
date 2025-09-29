using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFE_Etudiant_Asteelflash.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class RenameQrqcTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanActionFncQrqc_Fnc_FncId",
                table: "PlanActionFncQrqc");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanActionFncQrqcLigne_PlanActionFncQrqc_PlanActionFncQrqcId",
                table: "PlanActionFncQrqcLigne");

            migrationBuilder.DropForeignKey(
                name: "FK_TriFncQrqc_AspNetUsers_PiloteId",
                table: "TriFncQrqc");

            migrationBuilder.DropForeignKey(
                name: "FK_TriFncQrqc_Fnc_FncId",
                table: "TriFncQrqc");

            migrationBuilder.DropForeignKey(
                name: "FK_TriFncQrqcLigne_TriFncQrqc_TriFncQrqcId",
                table: "TriFncQrqcLigne");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TriFncQrqcLigne",
                table: "TriFncQrqcLigne");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TriFncQrqc",
                table: "TriFncQrqc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanActionFncQrqcLigne",
                table: "PlanActionFncQrqcLigne");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanActionFncQrqc",
                table: "PlanActionFncQrqc");

            migrationBuilder.RenameTable(
                name: "TriFncQrqcLigne",
                newName: "TriFncLigne");

            migrationBuilder.RenameTable(
                name: "TriFncQrqc",
                newName: "TriFnc");

            migrationBuilder.RenameTable(
                name: "PlanActionFncQrqcLigne",
                newName: "PlanActionFncLigne");

            migrationBuilder.RenameTable(
                name: "PlanActionFncQrqc",
                newName: "PlanActionFnc");

            migrationBuilder.RenameIndex(
                name: "IX_TriFncQrqcLigne_TriFncQrqcId",
                table: "TriFncLigne",
                newName: "IX_TriFncLigne_TriFncQrqcId");

            migrationBuilder.RenameIndex(
                name: "IX_TriFncQrqc_PiloteId",
                table: "TriFnc",
                newName: "IX_TriFnc_PiloteId");

            migrationBuilder.RenameIndex(
                name: "IX_TriFncQrqc_FncId",
                table: "TriFnc",
                newName: "IX_TriFnc_FncId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanActionFncQrqcLigne_PlanActionFncQrqcId",
                table: "PlanActionFncLigne",
                newName: "IX_PlanActionFncLigne_PlanActionFncQrqcId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanActionFncQrqc_FncId",
                table: "PlanActionFnc",
                newName: "IX_PlanActionFnc_FncId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TriFncLigne",
                table: "TriFncLigne",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TriFnc",
                table: "TriFnc",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanActionFncLigne",
                table: "PlanActionFncLigne",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanActionFnc",
                table: "PlanActionFnc",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanActionFnc_Fnc_FncId",
                table: "PlanActionFnc",
                column: "FncId",
                principalTable: "Fnc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanActionFncLigne_PlanActionFnc_PlanActionFncQrqcId",
                table: "PlanActionFncLigne",
                column: "PlanActionFncQrqcId",
                principalTable: "PlanActionFnc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TriFnc_AspNetUsers_PiloteId",
                table: "TriFnc",
                column: "PiloteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TriFnc_Fnc_FncId",
                table: "TriFnc",
                column: "FncId",
                principalTable: "Fnc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TriFncLigne_TriFnc_TriFncQrqcId",
                table: "TriFncLigne",
                column: "TriFncQrqcId",
                principalTable: "TriFnc",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanActionFnc_Fnc_FncId",
                table: "PlanActionFnc");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanActionFncLigne_PlanActionFnc_PlanActionFncQrqcId",
                table: "PlanActionFncLigne");

            migrationBuilder.DropForeignKey(
                name: "FK_TriFnc_AspNetUsers_PiloteId",
                table: "TriFnc");

            migrationBuilder.DropForeignKey(
                name: "FK_TriFnc_Fnc_FncId",
                table: "TriFnc");

            migrationBuilder.DropForeignKey(
                name: "FK_TriFncLigne_TriFnc_TriFncQrqcId",
                table: "TriFncLigne");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TriFncLigne",
                table: "TriFncLigne");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TriFnc",
                table: "TriFnc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanActionFncLigne",
                table: "PlanActionFncLigne");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanActionFnc",
                table: "PlanActionFnc");

            migrationBuilder.RenameTable(
                name: "TriFncLigne",
                newName: "TriFncQrqcLigne");

            migrationBuilder.RenameTable(
                name: "TriFnc",
                newName: "TriFncQrqc");

            migrationBuilder.RenameTable(
                name: "PlanActionFncLigne",
                newName: "PlanActionFncQrqcLigne");

            migrationBuilder.RenameTable(
                name: "PlanActionFnc",
                newName: "PlanActionFncQrqc");

            migrationBuilder.RenameIndex(
                name: "IX_TriFncLigne_TriFncQrqcId",
                table: "TriFncQrqcLigne",
                newName: "IX_TriFncQrqcLigne_TriFncQrqcId");

            migrationBuilder.RenameIndex(
                name: "IX_TriFnc_PiloteId",
                table: "TriFncQrqc",
                newName: "IX_TriFncQrqc_PiloteId");

            migrationBuilder.RenameIndex(
                name: "IX_TriFnc_FncId",
                table: "TriFncQrqc",
                newName: "IX_TriFncQrqc_FncId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanActionFncLigne_PlanActionFncQrqcId",
                table: "PlanActionFncQrqcLigne",
                newName: "IX_PlanActionFncQrqcLigne_PlanActionFncQrqcId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanActionFnc_FncId",
                table: "PlanActionFncQrqc",
                newName: "IX_PlanActionFncQrqc_FncId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TriFncQrqcLigne",
                table: "TriFncQrqcLigne",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TriFncQrqc",
                table: "TriFncQrqc",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanActionFncQrqcLigne",
                table: "PlanActionFncQrqcLigne",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanActionFncQrqc",
                table: "PlanActionFncQrqc",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanActionFncQrqc_Fnc_FncId",
                table: "PlanActionFncQrqc",
                column: "FncId",
                principalTable: "Fnc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanActionFncQrqcLigne_PlanActionFncQrqc_PlanActionFncQrqcId",
                table: "PlanActionFncQrqcLigne",
                column: "PlanActionFncQrqcId",
                principalTable: "PlanActionFncQrqc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TriFncQrqc_AspNetUsers_PiloteId",
                table: "TriFncQrqc",
                column: "PiloteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TriFncQrqc_Fnc_FncId",
                table: "TriFncQrqc",
                column: "FncId",
                principalTable: "Fnc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TriFncQrqcLigne_TriFncQrqc_TriFncQrqcId",
                table: "TriFncQrqcLigne",
                column: "TriFncQrqcId",
                principalTable: "TriFncQrqc",
                principalColumn: "Id");
        }
    }
}

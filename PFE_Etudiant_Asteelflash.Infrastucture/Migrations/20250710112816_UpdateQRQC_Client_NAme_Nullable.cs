using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFE_Etudiant_Asteelflash.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQRQC_Client_NAme_Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActD7_Qrqc_QrqcId",
                table: "ActD7");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionDeSecurisationD3_Qrqc_QRQCId",
                table: "ActionDeSecurisationD3");

            migrationBuilder.DropForeignKey(
                name: "FK_CauseOccurenceD4_Qrqc_QrqcId",
                table: "CauseOccurenceD4");

            migrationBuilder.DropForeignKey(
                name: "FK_CausesNonDetectionD4_Qrqc_QrqcId",
                table: "CausesNonDetectionD4");

            migrationBuilder.DropForeignKey(
                name: "FK_ClotureD8_Qrqc_QrqcId",
                table: "ClotureD8");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionDuProblemeD2_Qrqc_QRQCId",
                table: "DescriptionDuProblemeD2");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipe_Qrqc_QrqcId",
                table: "Equipe");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanActionsCorrectivesD5_Qrqc_QrqcId",
                table: "PlanActionsCorrectivesD5");

            migrationBuilder.DropForeignKey(
                name: "FK_SuiviD6_Qrqc_QrqcId",
                table: "SuiviD6");

            migrationBuilder.AlterColumn<string>(
                name: "client_name",
                table: "Qrqc",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_ActD7_Qrqc_QrqcId",
                table: "ActD7",
                column: "QrqcId",
                principalTable: "Qrqc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionDeSecurisationD3_Qrqc_QRQCId",
                table: "ActionDeSecurisationD3",
                column: "QRQCId",
                principalTable: "Qrqc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CauseOccurenceD4_Qrqc_QrqcId",
                table: "CauseOccurenceD4",
                column: "QrqcId",
                principalTable: "Qrqc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CausesNonDetectionD4_Qrqc_QrqcId",
                table: "CausesNonDetectionD4",
                column: "QrqcId",
                principalTable: "Qrqc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClotureD8_Qrqc_QrqcId",
                table: "ClotureD8",
                column: "QrqcId",
                principalTable: "Qrqc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionDuProblemeD2_Qrqc_QRQCId",
                table: "DescriptionDuProblemeD2",
                column: "QRQCId",
                principalTable: "Qrqc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipe_Qrqc_QrqcId",
                table: "Equipe",
                column: "QrqcId",
                principalTable: "Qrqc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanActionsCorrectivesD5_Qrqc_QrqcId",
                table: "PlanActionsCorrectivesD5",
                column: "QrqcId",
                principalTable: "Qrqc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SuiviD6_Qrqc_QrqcId",
                table: "SuiviD6",
                column: "QrqcId",
                principalTable: "Qrqc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActD7_Qrqc_QrqcId",
                table: "ActD7");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionDeSecurisationD3_Qrqc_QRQCId",
                table: "ActionDeSecurisationD3");

            migrationBuilder.DropForeignKey(
                name: "FK_CauseOccurenceD4_Qrqc_QrqcId",
                table: "CauseOccurenceD4");

            migrationBuilder.DropForeignKey(
                name: "FK_CausesNonDetectionD4_Qrqc_QrqcId",
                table: "CausesNonDetectionD4");

            migrationBuilder.DropForeignKey(
                name: "FK_ClotureD8_Qrqc_QrqcId",
                table: "ClotureD8");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionDuProblemeD2_Qrqc_QRQCId",
                table: "DescriptionDuProblemeD2");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipe_Qrqc_QrqcId",
                table: "Equipe");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanActionsCorrectivesD5_Qrqc_QrqcId",
                table: "PlanActionsCorrectivesD5");

            migrationBuilder.DropForeignKey(
                name: "FK_SuiviD6_Qrqc_QrqcId",
                table: "SuiviD6");

            migrationBuilder.AlterColumn<string>(
                name: "client_name",
                table: "Qrqc",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActD7_Qrqc_QrqcId",
                table: "ActD7",
                column: "QrqcId",
                principalTable: "Qrqc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionDeSecurisationD3_Qrqc_QRQCId",
                table: "ActionDeSecurisationD3",
                column: "QRQCId",
                principalTable: "Qrqc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CauseOccurenceD4_Qrqc_QrqcId",
                table: "CauseOccurenceD4",
                column: "QrqcId",
                principalTable: "Qrqc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CausesNonDetectionD4_Qrqc_QrqcId",
                table: "CausesNonDetectionD4",
                column: "QrqcId",
                principalTable: "Qrqc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClotureD8_Qrqc_QrqcId",
                table: "ClotureD8",
                column: "QrqcId",
                principalTable: "Qrqc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionDuProblemeD2_Qrqc_QRQCId",
                table: "DescriptionDuProblemeD2",
                column: "QRQCId",
                principalTable: "Qrqc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipe_Qrqc_QrqcId",
                table: "Equipe",
                column: "QrqcId",
                principalTable: "Qrqc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanActionsCorrectivesD5_Qrqc_QrqcId",
                table: "PlanActionsCorrectivesD5",
                column: "QrqcId",
                principalTable: "Qrqc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SuiviD6_Qrqc_QrqcId",
                table: "SuiviD6",
                column: "QrqcId",
                principalTable: "Qrqc",
                principalColumn: "Id");
        }
    }
}

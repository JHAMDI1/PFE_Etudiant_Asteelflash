using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFE_Etudiant_Asteelflash.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class add2table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanActionFncQrqc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FncId = table.Column<int>(type: "int", nullable: false),
                    DateCreationDoc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateMiseAJour = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VersionDoc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TauxClotureActions = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    TauxRespectDelais = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    TauxEfficacite = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanActionFncQrqc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanActionFncQrqc_Fnc_FncId",
                        column: x => x.FncId,
                        principalTable: "Fnc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TriFncQrqc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FncId = table.Column<int>(type: "int", nullable: false),
                    DateCreationDoc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateMiseAJour = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VersionDoc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DateTri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PiloteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceProduit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetTri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroAlerte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalTrie = table.Column<int>(type: "int", nullable: false),
                    TotalNonConforme = table.Column<int>(type: "int", nullable: false),
                    PourcentageDefaut = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriFncQrqc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TriFncQrqc_AspNetUsers_PiloteId",
                        column: x => x.PiloteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TriFncQrqc_Fnc_FncId",
                        column: x => x.FncId,
                        principalTable: "Fnc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlanActionFncQrqcLigne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanActionFncQrqcId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Origine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sujet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Processus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionProbleme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CauseRacine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NC = table.Column<bool>(type: "bit", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePrevue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRealise = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateMesureEfficacite = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RespMesureEfficacite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EfficaciteOK = table.Column<bool>(type: "bit", nullable: true),
                    Avancement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Retard = table.Column<int>(type: "int", nullable: true),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PointCritique = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanActionFncQrqcLigne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanActionFncQrqcLigne_PlanActionFncQrqc_PlanActionFncQrqcId",
                        column: x => x.PlanActionFncQrqcId,
                        principalTable: "PlanActionFncQrqc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TriFncQrqcLigne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TriFncQrqcId = table.Column<int>(type: "int", nullable: false),
                    Zone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    QuantiteTriee = table.Column<int>(type: "int", nullable: false),
                    QuantiteNonConforme = table.Column<int>(type: "int", nullable: false),
                    MatriculeOperateur = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DefautsDetectes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriFncQrqcLigne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TriFncQrqcLigne_TriFncQrqc_TriFncQrqcId",
                        column: x => x.TriFncQrqcId,
                        principalTable: "TriFncQrqc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanActionFncQrqc_FncId",
                table: "PlanActionFncQrqc",
                column: "FncId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanActionFncQrqcLigne_PlanActionFncQrqcId",
                table: "PlanActionFncQrqcLigne",
                column: "PlanActionFncQrqcId");

            migrationBuilder.CreateIndex(
                name: "IX_TriFncQrqc_FncId",
                table: "TriFncQrqc",
                column: "FncId");

            migrationBuilder.CreateIndex(
                name: "IX_TriFncQrqc_PiloteId",
                table: "TriFncQrqc",
                column: "PiloteId");

            migrationBuilder.CreateIndex(
                name: "IX_TriFncQrqcLigne_TriFncQrqcId",
                table: "TriFncQrqcLigne",
                column: "TriFncQrqcId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanActionFncQrqcLigne");

            migrationBuilder.DropTable(
                name: "TriFncQrqcLigne");

            migrationBuilder.DropTable(
                name: "PlanActionFncQrqc");

            migrationBuilder.DropTable(
                name: "TriFncQrqc");
        }
    }
}

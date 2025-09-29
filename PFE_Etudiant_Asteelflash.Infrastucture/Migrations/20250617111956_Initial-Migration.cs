using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFE_Etudiant_Asteelflash.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    nbre_de_lignes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Fonction = table.Column<int>(type: "int", nullable: true),
                    ZapId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Zap_ZapId",
                        column: x => x.ZapId,
                        principalTable: "Zap",
                        principalColumn: "Id");
                });

 
            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fnc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Num = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZapEmettriceId = table.Column<int>(type: "int", nullable: false),
                    ZapReceptriceId = table.Column<int>(type: "int", nullable: false),
                    TransmitterID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProcessorID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hour = table.Column<TimeSpan>(type: "time", nullable: false),
                    Client_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Detection_loc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity_NOK = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bilan_de_tri = table.Column<bool>(type: "bit", nullable: false),
                    TypeDefaut = table.Column<int>(type: "int", nullable: false),
                    ImageUrl_Piece_bonne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl_Piece_Mauvaise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeFnc = table.Column<int>(type: "int", nullable: false),
                    NcImpact = table.Column<int>(type: "int", nullable: false),
                    actionImmediate = table.Column<int>(type: "int", nullable: false),
                    Etat = table.Column<int>(type: "int", nullable: false),
                    Quantite_Isoloation_de_lot = table.Column<int>(type: "int", nullable: true),
                    Quantite_Rebut = table.Column<int>(type: "int", nullable: true),
                    Numero_dérogation = table.Column<int>(type: "int", nullable: true),
                    Tri_Ok = table.Column<int>(type: "int", nullable: true),
                    Tri_NOk = table.Column<int>(type: "int", nullable: true),
                    Action_de_reparation = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fnc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fnc_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fnc_AspNetUsers_ProcessorID",
                        column: x => x.ProcessorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fnc_AspNetUsers_TransmitterID",
                        column: x => x.TransmitterID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fnc_Zap_ZapEmettriceId",
                        column: x => x.ZapEmettriceId,
                        principalTable: "Zap",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fnc_Zap_ZapReceptriceId",
                        column: x => x.ZapReceptriceId,
                        principalTable: "Zap",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FncId = table.Column<int>(type: "int", nullable: true),
                    TypeFnc = table.Column<int>(type: "int", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recherche_causes_racinesD4",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PiloteID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DatePrevue = table.Column<DateOnly>(type: "date", nullable: false),
                    DateReelle = table.Column<DateOnly>(type: "date", nullable: false),
                    Evolution = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recherche_causes_racinesD4", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recherche_causes_racinesD4_AspNetUsers_PiloteID",
                        column: x => x.PiloteID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Réclamation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Réclamation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Réclamation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Qrqc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FNCId = table.Column<int>(type: "int", nullable: false),
                    ProcessorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    client_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    nature_defaut = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Alerte_qualité = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qrqc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Qrqc_AspNetUsers_ProcessorID",
                        column: x => x.ProcessorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Qrqc_Fnc_FNCId",
                        column: x => x.FNCId,
                        principalTable: "Fnc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActD7",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConnaissanceExperience = table.Column<int>(type: "int", nullable: false),
                    QrqcId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActD7", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActD7_Qrqc_QrqcId",
                        column: x => x.QrqcId,
                        principalTable: "Qrqc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActionDeSecurisationD3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    action = table.Column<int>(type: "int", nullable: false),
                    TypeReclamation = table.Column<int>(type: "int", nullable: false),
                    Conclusion_tri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QRQCId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionDeSecurisationD3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionDeSecurisationD3_Qrqc_QRQCId",
                        column: x => x.QRQCId,
                        principalTable: "Qrqc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CauseOccurenceD4",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pourquoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QrqcId = table.Column<int>(type: "int", nullable: false),
                    Cause = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauseOccurenceD4", x => x.id);
                    table.ForeignKey(
                        name: "FK_CauseOccurenceD4_Qrqc_QrqcId",
                        column: x => x.QrqcId,
                        principalTable: "Qrqc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CausesNonDetectionD4",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cause = table.Column<int>(type: "int", nullable: false),
                    Pourquoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QrqcId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CausesNonDetectionD4", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CausesNonDetectionD4_Qrqc_QrqcId",
                        column: x => x.QrqcId,
                        principalTable: "Qrqc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClotureD8",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChefEquipeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApprobationChefEquipe = table.Column<bool>(type: "bit", nullable: false),
                    RespZapId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApprobationRespZap = table.Column<bool>(type: "bit", nullable: false),
                    QualitéProdId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApprobationQualitéProd = table.Column<bool>(type: "bit", nullable: false),
                    RespQualiteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApprobationRespQualite = table.Column<bool>(type: "bit", nullable: false),
                    RespProdId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApprobationRespProd = table.Column<bool>(type: "bit", nullable: false),
                    QrqcId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClotureD8", x => x.id);
                    table.ForeignKey(
                        name: "FK_ClotureD8_AspNetUsers_ChefEquipeId",
                        column: x => x.ChefEquipeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClotureD8_AspNetUsers_QualitéProdId",
                        column: x => x.QualitéProdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClotureD8_AspNetUsers_RespProdId",
                        column: x => x.RespProdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClotureD8_AspNetUsers_RespQualiteId",
                        column: x => x.RespQualiteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClotureD8_AspNetUsers_RespZapId",
                        column: x => x.RespZapId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClotureD8_Qrqc_QrqcId",
                        column: x => x.QrqcId,
                        principalTable: "Qrqc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DescriptionDuProblemeD2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Probleme = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Detecteur = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LieuDeDetection = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Heure = table.Column<TimeSpan>(type: "time", nullable: false),
                    ManiéreDeDetection = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NbreDePiecesConcernes = table.Column<int>(type: "int", nullable: false),
                    RaisonDuProbleme = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ReccurenceDuProbleme = table.Column<bool>(type: "bit", nullable: false),
                    Risque = table.Column<bool>(type: "bit", nullable: false),
                    QRQCId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionDuProblemeD2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescriptionDuProblemeD2_Qrqc_QRQCId",
                        column: x => x.QRQCId,
                        principalTable: "Qrqc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QrqcId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fonction = table.Column<int>(type: "int", nullable: false),
                    IsAbsent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipe_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipe_Qrqc_QrqcId",
                        column: x => x.QrqcId,
                        principalTable: "Qrqc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlanActionsCorrectivesD5",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionEliminationProbleme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PiloteID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DatePlanifiee = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QrqcId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanActionsCorrectivesD5", x => x.id);
                    table.ForeignKey(
                        name: "FK_PlanActionsCorrectivesD5_AspNetUsers_PiloteID",
                        column: x => x.PiloteID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanActionsCorrectivesD5_Qrqc_QrqcId",
                        column: x => x.QrqcId,
                        principalTable: "Qrqc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SuiviD6",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipe1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRealisation1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Equipe2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRealisation2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Equipe3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRealisation3 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Equipe4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRealisation4 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Equipe5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRealisation5 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QrqcId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuiviD6", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuiviD6_Qrqc_QrqcId",
                        column: x => x.QrqcId,
                        principalTable: "Qrqc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActionImmediateGlobale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenir_Stopper = table.Column<int>(type: "int", nullable: true),
                    Contenir_Déroulement = table.Column<int>(type: "int", nullable: true),
                    Réparer_Déclenchement = table.Column<int>(type: "int", nullable: true),
                    ConclusionTri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ActionDeSecurisationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionImmediateGlobale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionImmediateGlobale_ActionDeSecurisationD3_ActionDeSecurisationId",
                        column: x => x.ActionDeSecurisationId,
                        principalTable: "ActionDeSecurisationD3",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AssurerD3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PiloteID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Assurer_Réunion = table.Column<int>(type: "int", nullable: true),
                    Assurer_Audit = table.Column<int>(type: "int", nullable: true),
                    ActionDeSecurisationD3ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssurerD3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssurerD3_ActionDeSecurisationD3_ActionDeSecurisationD3ID",
                        column: x => x.ActionDeSecurisationD3ID,
                        principalTable: "ActionDeSecurisationD3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssurerD3_AspNetUsers_PiloteID",
                        column: x => x.PiloteID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContenirD3",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PiloteID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Contenir_Stopper = table.Column<int>(type: "int", nullable: true),
                    Contenir_Déroulement = table.Column<int>(type: "int", nullable: true),
                    Contenir_Ajout = table.Column<int>(type: "int", nullable: true),
                    ActionDeSecurisationD3ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContenirD3", x => x.id);
                    table.ForeignKey(
                        name: "FK_ContenirD3_ActionDeSecurisationD3_ActionDeSecurisationD3ID",
                        column: x => x.ActionDeSecurisationD3ID,
                        principalTable: "ActionDeSecurisationD3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContenirD3_AspNetUsers_PiloteID",
                        column: x => x.PiloteID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ListeDesActionsD3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StatusAction = table.Column<int>(type: "int", nullable: false),
                    DatePrévue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRéelle = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PiloteID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActionDeSecurisationD3Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListeDesActionsD3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListeDesActionsD3_ActionDeSecurisationD3_ActionDeSecurisationD3Id",
                        column: x => x.ActionDeSecurisationD3Id,
                        principalTable: "ActionDeSecurisationD3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListeDesActionsD3_AspNetUsers_PiloteID",
                        column: x => x.PiloteID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReparerD3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PiloteID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Réparer_Edition = table.Column<int>(type: "int", nullable: true),
                    Réparer_Définition_Des_Flux = table.Column<int>(type: "int", nullable: true),
                    Réparer_Définition_Du_Point = table.Column<int>(type: "int", nullable: true),
                    Réparer_Formation = table.Column<int>(type: "int", nullable: true),
                    Réparer_Déclenchement = table.Column<int>(type: "int", nullable: true),
                    ActionDeSecurisationD3ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReparerD3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReparerD3_ActionDeSecurisationD3_ActionDeSecurisationD3ID",
                        column: x => x.ActionDeSecurisationD3ID,
                        principalTable: "ActionDeSecurisationD3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReparerD3_AspNetUsers_PiloteID",
                        column: x => x.PiloteID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrierD3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PiloteID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Trier_Edition = table.Column<int>(type: "int", nullable: true),
                    Trier_Formation = table.Column<int>(type: "int", nullable: true),
                    Trier_Définition = table.Column<int>(type: "int", nullable: true),
                    Trier_Déclenchement = table.Column<int>(type: "int", nullable: true),
                    Trier_En_Cours = table.Column<int>(type: "int", nullable: true),
                    Trier_Expédition = table.Column<int>(type: "int", nullable: true),
                    ActionDeSecurisationD3ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrierD3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrierD3_ActionDeSecurisationD3_ActionDeSecurisationD3ID",
                        column: x => x.ActionDeSecurisationD3ID,
                        principalTable: "ActionDeSecurisationD3",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrierD3_AspNetUsers_PiloteID",
                        column: x => x.PiloteID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrieActionImmediateGlobale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NombrePiéceTrié = table.Column<int>(type: "int", nullable: false),
                    NombrePiéceTotale = table.Column<int>(type: "int", nullable: false),
                    ActionImmediateGlobaleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrieActionImmediateGlobale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrieActionImmediateGlobale_ActionImmediateGlobale_ActionImmediateGlobaleId",
                        column: x => x.ActionImmediateGlobaleId,
                        principalTable: "ActionImmediateGlobale",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuantitéTriéeParJour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jour1 = table.Column<int>(type: "int", nullable: true),
                    Jour2 = table.Column<int>(type: "int", nullable: true),
                    Jour3 = table.Column<int>(type: "int", nullable: true),
                    Jour4 = table.Column<int>(type: "int", nullable: true),
                    Jour5 = table.Column<int>(type: "int", nullable: true),
                    TriActionImmédiateGlobaleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantitéTriéeParJour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuantitéTriéeParJour_TrieActionImmediateGlobale_TriActionImmédiateGlobaleId",
                        column: x => x.TriActionImmédiateGlobaleId,
                        principalTable: "TrieActionImmediateGlobale",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActD7_QrqcId",
                table: "ActD7",
                column: "QrqcId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActionDeSecurisationD3_QRQCId",
                table: "ActionDeSecurisationD3",
                column: "QRQCId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActionImmediateGlobale_ActionDeSecurisationId",
                table: "ActionImmediateGlobale",
                column: "ActionDeSecurisationId",
                unique: true,
                filter: "[ActionDeSecurisationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ZapId",
                table: "AspNetUsers",
                column: "ZapId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AssurerD3_ActionDeSecurisationD3ID",
                table: "AssurerD3",
                column: "ActionDeSecurisationD3ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssurerD3_PiloteID",
                table: "AssurerD3",
                column: "PiloteID");

            migrationBuilder.CreateIndex(
                name: "IX_CauseOccurenceD4_QrqcId",
                table: "CauseOccurenceD4",
                column: "QrqcId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CausesNonDetectionD4_QrqcId",
                table: "CausesNonDetectionD4",
                column: "QrqcId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClotureD8_ChefEquipeId",
                table: "ClotureD8",
                column: "ChefEquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClotureD8_QrqcId",
                table: "ClotureD8",
                column: "QrqcId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClotureD8_QualitéProdId",
                table: "ClotureD8",
                column: "QualitéProdId");

            migrationBuilder.CreateIndex(
                name: "IX_ClotureD8_RespProdId",
                table: "ClotureD8",
                column: "RespProdId");

            migrationBuilder.CreateIndex(
                name: "IX_ClotureD8_RespQualiteId",
                table: "ClotureD8",
                column: "RespQualiteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClotureD8_RespZapId",
                table: "ClotureD8",
                column: "RespZapId");

            migrationBuilder.CreateIndex(
                name: "IX_ContenirD3_ActionDeSecurisationD3ID",
                table: "ContenirD3",
                column: "ActionDeSecurisationD3ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContenirD3_PiloteID",
                table: "ContenirD3",
                column: "PiloteID");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionDuProblemeD2_QRQCId",
                table: "DescriptionDuProblemeD2",
                column: "QRQCId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_QrqcId",
                table: "Equipe",
                column: "QrqcId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_UserId",
                table: "Equipe",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fnc_ApplicationUserId",
                table: "Fnc",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fnc_ProcessorID",
                table: "Fnc",
                column: "ProcessorID");

            migrationBuilder.CreateIndex(
                name: "IX_Fnc_TransmitterID",
                table: "Fnc",
                column: "TransmitterID");

            migrationBuilder.CreateIndex(
                name: "IX_Fnc_ZapEmettriceId",
                table: "Fnc",
                column: "ZapEmettriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Fnc_ZapReceptriceId",
                table: "Fnc",
                column: "ZapReceptriceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListeDesActionsD3_ActionDeSecurisationD3Id",
                table: "ListeDesActionsD3",
                column: "ActionDeSecurisationD3Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListeDesActionsD3_PiloteID",
                table: "ListeDesActionsD3",
                column: "PiloteID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanActionsCorrectivesD5_PiloteID",
                table: "PlanActionsCorrectivesD5",
                column: "PiloteID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanActionsCorrectivesD5_QrqcId",
                table: "PlanActionsCorrectivesD5",
                column: "QrqcId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Qrqc_FNCId",
                table: "Qrqc",
                column: "FNCId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Qrqc_ProcessorID",
                table: "Qrqc",
                column: "ProcessorID");

            migrationBuilder.CreateIndex(
                name: "IX_QuantitéTriéeParJour_TriActionImmédiateGlobaleId",
                table: "QuantitéTriéeParJour",
                column: "TriActionImmédiateGlobaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recherche_causes_racinesD4_PiloteID",
                table: "Recherche_causes_racinesD4",
                column: "PiloteID");

            migrationBuilder.CreateIndex(
                name: "IX_Réclamation_UserId",
                table: "Réclamation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReparerD3_ActionDeSecurisationD3ID",
                table: "ReparerD3",
                column: "ActionDeSecurisationD3ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReparerD3_PiloteID",
                table: "ReparerD3",
                column: "PiloteID");

            migrationBuilder.CreateIndex(
                name: "IX_SuiviD6_QrqcId",
                table: "SuiviD6",
                column: "QrqcId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrieActionImmediateGlobale_ActionImmediateGlobaleId",
                table: "TrieActionImmediateGlobale",
                column: "ActionImmediateGlobaleId");

            migrationBuilder.CreateIndex(
                name: "IX_TrierD3_ActionDeSecurisationD3ID",
                table: "TrierD3",
                column: "ActionDeSecurisationD3ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrierD3_PiloteID",
                table: "TrierD3",
                column: "PiloteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActD7");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AssurerD3");

            migrationBuilder.DropTable(
                name: "CauseOccurenceD4");

            migrationBuilder.DropTable(
                name: "CausesNonDetectionD4");

            migrationBuilder.DropTable(
                name: "ClotureD8");

            migrationBuilder.DropTable(
                name: "ContenirD3");

            migrationBuilder.DropTable(
                name: "DescriptionDuProblemeD2");

            migrationBuilder.DropTable(
                name: "Equipe");

            migrationBuilder.DropTable(
                name: "ListeDesActionsD3");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "PlanActionsCorrectivesD5");

            migrationBuilder.DropTable(
                name: "QuantitéTriéeParJour");

            migrationBuilder.DropTable(
                name: "Recherche_causes_racinesD4");

            migrationBuilder.DropTable(
                name: "Réclamation");

            migrationBuilder.DropTable(
                name: "ReparerD3");

            migrationBuilder.DropTable(
                name: "SuiviD6");

            migrationBuilder.DropTable(
                name: "TrierD3");
            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TrieActionImmediateGlobale");

            migrationBuilder.DropTable(
                name: "ActionImmediateGlobale");

            migrationBuilder.DropTable(
                name: "ActionDeSecurisationD3");

            migrationBuilder.DropTable(
                name: "Qrqc");

            migrationBuilder.DropTable(
                name: "Fnc");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Zap");
        }
    }
}

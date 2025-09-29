using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFE_Etudiant_Asteelflash.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class Update_Fnc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approbation_conducteur",
                table: "Fnc",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Enonce_de_la_reclamaion",
                table: "Fnc",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pour_quoi",
                table: "Fnc",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approbation_conducteur",
                table: "Fnc");

            migrationBuilder.DropColumn(
                name: "Enonce_de_la_reclamaion",
                table: "Fnc");

            migrationBuilder.DropColumn(
                name: "pour_quoi",
                table: "Fnc");
        }
    }
}

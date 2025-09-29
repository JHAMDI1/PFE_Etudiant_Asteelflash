using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFE_Etudiant_Asteelflash.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class Update_Fnc_Add_Ligne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "Num",
                table: "Fnc");

            migrationBuilder.AddColumn<string>(
                name: "Ligne",
                table: "Fnc",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ligne",
                table: "Fnc");

            migrationBuilder.AddColumn<string>(
                name: "Num",
                table: "Fnc",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

        }
    }
}

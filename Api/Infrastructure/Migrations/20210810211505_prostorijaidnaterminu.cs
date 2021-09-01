using Microsoft.EntityFrameworkCore.Migrations;

namespace SportskiCentarRS2.Infrastructure.Migrations
{
    public partial class prostorijaidnaterminu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProstorijaId",
                table: "Termini",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Termini_ProstorijaId",
                table: "Termini",
                column: "ProstorijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Termini_Prostorije_ProstorijaId",
                table: "Termini",
                column: "ProstorijaId",
                principalTable: "Prostorije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Termini_Prostorije_ProstorijaId",
                table: "Termini");

            migrationBuilder.DropIndex(
                name: "IX_Termini_ProstorijaId",
                table: "Termini");

            migrationBuilder.DropColumn(
                name: "ProstorijaId",
                table: "Termini");
        }
    }
}

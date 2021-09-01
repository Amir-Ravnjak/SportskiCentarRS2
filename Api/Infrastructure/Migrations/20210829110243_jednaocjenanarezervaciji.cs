using Microsoft.EntityFrameworkCore.Migrations;

namespace SportskiCentarRS2.Infrastructure.Migrations
{
    public partial class jednaocjenanarezervaciji : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ocjene_RezervacijaId",
                table: "Ocjene");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_RezervacijaId",
                table: "Ocjene",
                column: "RezervacijaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ocjene_RezervacijaId",
                table: "Ocjene");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_RezervacijaId",
                table: "Ocjene",
                column: "RezervacijaId");
        }
    }
}

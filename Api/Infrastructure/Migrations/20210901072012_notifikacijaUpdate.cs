using Microsoft.EntityFrameworkCore.Migrations;

namespace SportskiCentarRS2.Infrastructure.Migrations
{
    public partial class notifikacijaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Uplate_RezervacijaId",
                table: "Uplate");

            migrationBuilder.AddColumn<bool>(
                name: "Procitana",
                table: "Notifikacije",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Uplate_RezervacijaId",
                table: "Uplate",
                column: "RezervacijaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Uplate_RezervacijaId",
                table: "Uplate");

            migrationBuilder.DropColumn(
                name: "Procitana",
                table: "Notifikacije");

            migrationBuilder.CreateIndex(
                name: "IX_Uplate_RezervacijaId",
                table: "Uplate",
                column: "RezervacijaId");
        }
    }
}

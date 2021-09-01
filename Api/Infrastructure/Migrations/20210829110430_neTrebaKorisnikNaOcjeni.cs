using Microsoft.EntityFrameworkCore.Migrations;

namespace SportskiCentarRS2.Infrastructure.Migrations
{
    public partial class neTrebaKorisnikNaOcjeni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocjene_AspNetUsers_KorisnikId",
                table: "Ocjene");

            migrationBuilder.DropIndex(
                name: "IX_Ocjene_KorisnikId",
                table: "Ocjene");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Ocjene");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "Ocjene",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_KorisnikId",
                table: "Ocjene",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjene_AspNetUsers_KorisnikId",
                table: "Ocjene",
                column: "KorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

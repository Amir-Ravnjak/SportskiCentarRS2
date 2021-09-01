using Microsoft.EntityFrameworkCore.Migrations;

namespace SportskiCentarRS2.Infrastructure.Migrations
{
    public partial class typoRezervacijeFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifikacije_AspNetUsers_PosiljalacId",
                table: "Notifikacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifikacije_AspNetUsers_PrimalacId",
                table: "Notifikacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocjene_Rezetvacije_RezervacijaId",
                table: "Ocjene");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezetvacije_AspNetUsers_KorisnikId",
                table: "Rezetvacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezetvacije_AspNetUsers_KreoiraoKorisnikId",
                table: "Rezetvacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezetvacije_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Rezetvacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezetvacije_Termini_TerminId",
                table: "Rezetvacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Uplate_Rezetvacije_RezervacijaId",
                table: "Uplate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rezetvacije",
                table: "Rezetvacije");

            migrationBuilder.RenameTable(
                name: "Rezetvacije",
                newName: "Rezervacije");

            migrationBuilder.RenameIndex(
                name: "IX_Rezetvacije_ZadnjiIzmijenioKorisnikId",
                table: "Rezervacije",
                newName: "IX_Rezervacije_ZadnjiIzmijenioKorisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_Rezetvacije_TerminId",
                table: "Rezervacije",
                newName: "IX_Rezervacije_TerminId");

            migrationBuilder.RenameIndex(
                name: "IX_Rezetvacije_KreoiraoKorisnikId",
                table: "Rezervacije",
                newName: "IX_Rezervacije_KreoiraoKorisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_Rezetvacije_KorisnikId",
                table: "Rezervacije",
                newName: "IX_Rezervacije_KorisnikId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rezervacije",
                table: "Rezervacije",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifikacije_AspNetUsers_PosiljalacId",
                table: "Notifikacije",
                column: "PosiljalacId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifikacije_AspNetUsers_PrimalacId",
                table: "Notifikacije",
                column: "PrimalacId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjene_Rezervacije_RezervacijaId",
                table: "Ocjene",
                column: "RezervacijaId",
                principalTable: "Rezervacije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_AspNetUsers_KorisnikId",
                table: "Rezervacije",
                column: "KorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_AspNetUsers_KreoiraoKorisnikId",
                table: "Rezervacije",
                column: "KreoiraoKorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Rezervacije",
                column: "ZadnjiIzmijenioKorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Termini_TerminId",
                table: "Rezervacije",
                column: "TerminId",
                principalTable: "Termini",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uplate_Rezervacije_RezervacijaId",
                table: "Uplate",
                column: "RezervacijaId",
                principalTable: "Rezervacije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifikacije_AspNetUsers_PosiljalacId",
                table: "Notifikacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifikacije_AspNetUsers_PrimalacId",
                table: "Notifikacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocjene_Rezervacije_RezervacijaId",
                table: "Ocjene");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_AspNetUsers_KorisnikId",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_AspNetUsers_KreoiraoKorisnikId",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Termini_TerminId",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Uplate_Rezervacije_RezervacijaId",
                table: "Uplate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rezervacije",
                table: "Rezervacije");

            migrationBuilder.RenameTable(
                name: "Rezervacije",
                newName: "Rezetvacije");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacije_ZadnjiIzmijenioKorisnikId",
                table: "Rezetvacije",
                newName: "IX_Rezetvacije_ZadnjiIzmijenioKorisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacije_TerminId",
                table: "Rezetvacije",
                newName: "IX_Rezetvacije_TerminId");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacije_KreoiraoKorisnikId",
                table: "Rezetvacije",
                newName: "IX_Rezetvacije_KreoiraoKorisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacije_KorisnikId",
                table: "Rezetvacije",
                newName: "IX_Rezetvacije_KorisnikId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rezetvacije",
                table: "Rezetvacije",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifikacije_AspNetUsers_PosiljalacId",
                table: "Notifikacije",
                column: "PosiljalacId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifikacije_AspNetUsers_PrimalacId",
                table: "Notifikacije",
                column: "PrimalacId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjene_Rezetvacije_RezervacijaId",
                table: "Ocjene",
                column: "RezervacijaId",
                principalTable: "Rezetvacije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezetvacije_AspNetUsers_KorisnikId",
                table: "Rezetvacije",
                column: "KorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezetvacije_AspNetUsers_KreoiraoKorisnikId",
                table: "Rezetvacije",
                column: "KreoiraoKorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezetvacije_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Rezetvacije",
                column: "ZadnjiIzmijenioKorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezetvacije_Termini_TerminId",
                table: "Rezetvacije",
                column: "TerminId",
                principalTable: "Termini",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uplate_Rezetvacije_RezervacijaId",
                table: "Uplate",
                column: "RezervacijaId",
                principalTable: "Rezetvacije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

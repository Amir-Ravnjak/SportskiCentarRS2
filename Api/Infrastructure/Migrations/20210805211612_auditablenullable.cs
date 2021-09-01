using Microsoft.EntityFrameworkCore.Migrations;

namespace SportskiCentarRS2.Infrastructure.Migrations
{
    public partial class auditablenullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oprema_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Oprema");

            migrationBuilder.DropForeignKey(
                name: "FK_Prostorije_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Prostorije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Termini_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Termini");

            migrationBuilder.AlterColumn<int>(
                name: "ZadnjiIzmijenioKorisnikId",
                table: "Termini",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ZadnjiIzmijenioKorisnikId",
                table: "Rezervacije",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ZadnjiIzmijenioKorisnikId",
                table: "Prostorije",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ZadnjiIzmijenioKorisnikId",
                table: "Oprema",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Oprema_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Oprema",
                column: "ZadnjiIzmijenioKorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prostorije_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Prostorije",
                column: "ZadnjiIzmijenioKorisnikId",
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
                name: "FK_Termini_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Termini",
                column: "ZadnjiIzmijenioKorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oprema_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Oprema");

            migrationBuilder.DropForeignKey(
                name: "FK_Prostorije_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Prostorije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Termini_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Termini");

            migrationBuilder.AlterColumn<int>(
                name: "ZadnjiIzmijenioKorisnikId",
                table: "Termini",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ZadnjiIzmijenioKorisnikId",
                table: "Rezervacije",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ZadnjiIzmijenioKorisnikId",
                table: "Prostorije",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ZadnjiIzmijenioKorisnikId",
                table: "Oprema",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Oprema_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Oprema",
                column: "ZadnjiIzmijenioKorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prostorije_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Prostorije",
                column: "ZadnjiIzmijenioKorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Rezervacije",
                column: "ZadnjiIzmijenioKorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Termini_AspNetUsers_ZadnjiIzmijenioKorisnikId",
                table: "Termini",
                column: "ZadnjiIzmijenioKorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

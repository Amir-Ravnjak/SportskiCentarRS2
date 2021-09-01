using Microsoft.EntityFrameworkCore.Migrations;

namespace SportskiCentarRS2.Infrastructure.Migrations
{
    public partial class OpremaProstorija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oprema_Prostorije_ProstorijaId",
                table: "Oprema");

            migrationBuilder.DropIndex(
                name: "IX_Oprema_ProstorijaId",
                table: "Oprema");

            migrationBuilder.DropColumn(
                name: "ProstorijaId",
                table: "Oprema");

            migrationBuilder.CreateTable(
                name: "OpremaProstorija",
                columns: table => new
                {
                    OpremaId = table.Column<int>(type: "int", nullable: false),
                    ProstorijeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpremaProstorija", x => new { x.OpremaId, x.ProstorijeId });
                    table.ForeignKey(
                        name: "FK_OpremaProstorija_Oprema_OpremaId",
                        column: x => x.OpremaId,
                        principalTable: "Oprema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpremaProstorija_Prostorije_ProstorijeId",
                        column: x => x.ProstorijeId,
                        principalTable: "Prostorije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpremaProstorija_ProstorijeId",
                table: "OpremaProstorija",
                column: "ProstorijeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpremaProstorija");

            migrationBuilder.AddColumn<int>(
                name: "ProstorijaId",
                table: "Oprema",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Oprema_ProstorijaId",
                table: "Oprema",
                column: "ProstorijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Oprema_Prostorije_ProstorijaId",
                table: "Oprema",
                column: "ProstorijaId",
                principalTable: "Prostorije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

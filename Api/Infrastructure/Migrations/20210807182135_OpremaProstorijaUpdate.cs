using Microsoft.EntityFrameworkCore.Migrations;

namespace SportskiCentarRS2.Infrastructure.Migrations
{
    public partial class OpremaProstorijaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpremaProstorija");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}

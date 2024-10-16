using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FuscaFilmes.Repo.Migrations
{
    /// <inheritdoc />
    public partial class M2MCreatingClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiretorFilme");

            migrationBuilder.CreateTable(
                name: "DiretoresFilmes",
                columns: table => new
                {
                    DiretorId = table.Column<int>(type: "INTEGER", nullable: false),
                    FilmeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiretoresFilmes", x => new { x.DiretorId, x.FilmeId });
                    table.ForeignKey(
                        name: "FK_DiretoresFilmes_Diretores_DiretorId",
                        column: x => x.DiretorId,
                        principalTable: "Diretores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiretoresFilmes_Filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DiretoresFilmes",
                columns: new[] { "DiretorId", "FilmeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 9 },
                    { 4, 10 },
                    { 4, 11 },
                    { 4, 12 },
                    { 5, 13 },
                    { 5, 14 },
                    { 5, 15 },
                    { 6, 16 },
                    { 6, 17 },
                    { 6, 18 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiretoresFilmes_FilmeId",
                table: "DiretoresFilmes",
                column: "FilmeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiretoresFilmes");

            migrationBuilder.CreateTable(
                name: "DiretorFilme",
                columns: table => new
                {
                    DiretoresId = table.Column<int>(type: "INTEGER", nullable: false),
                    FilmesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiretorFilme", x => new { x.DiretoresId, x.FilmesId });
                    table.ForeignKey(
                        name: "FK_DiretorFilme_Diretores_DiretoresId",
                        column: x => x.DiretoresId,
                        principalTable: "Diretores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiretorFilme_Filmes_FilmesId",
                        column: x => x.FilmesId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiretorFilme_FilmesId",
                table: "DiretorFilme",
                column: "FilmesId");
        }
    }
}

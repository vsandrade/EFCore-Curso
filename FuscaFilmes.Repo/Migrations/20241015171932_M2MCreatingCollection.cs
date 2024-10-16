using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuscaFilmes.Repo.Migrations
{
    /// <inheritdoc />
    public partial class M2MCreatingCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.CreateIndex(
                name: "IX_DiretorFilme_DiretoresId",
                table: "DiretorFilme",
                column: "DiretoresId");

            migrationBuilder.Sql(@"
                INSERT INTO DiretorFilme (FilmesId, DiretoresId)
                SELECT Id, DiretorId FROM Filmes WHERE DiretorId IS NOT NULL
            ");

            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Diretores_DiretorId",
                table: "Filmes");

            migrationBuilder.DropIndex(
                name: "IX_Filmes_DiretorId",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "DiretorId",
                table: "Filmes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "DiretorId",
                table: "Filmes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(@"
                UPDATE Filmes
                SET DiretorId = DF.DiretoresId
                FROM Filmes F INNER JOIN DiretorFilme DF 
                ON F.Id = DF.FilmesId
            ");

            migrationBuilder.DropTable(
                name: "DiretorFilme");

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DiretorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DiretorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DiretorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DiretorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DiretorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 6,
                column: "DiretorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 7,
                column: "DiretorId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 8,
                column: "DiretorId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 9,
                column: "DiretorId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 10,
                column: "DiretorId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 11,
                column: "DiretorId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 12,
                column: "DiretorId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 13,
                column: "DiretorId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 14,
                column: "DiretorId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 15,
                column: "DiretorId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 16,
                column: "DiretorId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 17,
                column: "DiretorId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 18,
                column: "DiretorId",
                value: 6);

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_DiretorId",
                table: "Filmes",
                column: "DiretorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Diretores_DiretorId",
                table: "Filmes",
                column: "DiretorId",
                principalTable: "Diretores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

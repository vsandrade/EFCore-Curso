using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FuscaFilmes.Repo.Migrations
{
    /// <inheritdoc />
    public partial class O2O_DiretorDetalhe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiretorDetalhe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Biografia = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DiretorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiretorDetalhe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiretorDetalhe_Diretores_DiretorId",
                        column: x => x.DiretorId,
                        principalTable: "Diretores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DiretorDetalhe",
                columns: new[] { "Id", "Biografia", "DataNascimento", "DiretorId" },
                values: new object[,]
                {
                    { 1, "Biografia do Christopher Nolan", new DateTime(1970, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Biografia do Steven Spielberg", new DateTime(1946, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiretorDetalhe_DiretorId",
                table: "DiretorDetalhe",
                column: "DiretorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiretorDetalhe");
        }
    }
}

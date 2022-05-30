using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class FirstCinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    CompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    IsMeia = table.Column<bool>(type: "bit", nullable: false),
                    PromocaoEspecial = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.CompraId);
                });

            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFilme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idadeindicativa = table.Column<int>(type: "int", nullable: false),
                    GeneroFilme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sinopse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.FilmeId);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    HorarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorarioSessao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.HorarioId);
                });

            migrationBuilder.CreateTable(
                name: "Sessao",
                columns: table => new
                {
                    SessaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessao", x => x.SessaoId);
                });

            migrationBuilder.CreateTable(
                name: "DetalheSessao",
                columns: table => new
                {
                    DetalheSessaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroSala = table.Column<int>(type: "int", nullable: false),
                    QuantidadeLugares = table.Column<int>(type: "int", nullable: false),
                    HorarioId = table.Column<int>(type: "int", nullable: false),
                    FilmeId = table.Column<int>(type: "int", nullable: false),
                    CadeiraSelecionada = table.Column<int>(type: "int", nullable: false),
                    SessaoId = table.Column<int>(type: "int", nullable: false),
                    CompraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalheSessao", x => x.DetalheSessaoId);
                    table.ForeignKey(
                        name: "FK_DetalheSessao_Compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compra",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalheSessao_Filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "FilmeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalheSessao_Horario_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horario",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalheSessao_Sessao_SessaoId",
                        column: x => x.SessaoId,
                        principalTable: "Sessao",
                        principalColumn: "SessaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalheSessao_CompraId",
                table: "DetalheSessao",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalheSessao_FilmeId",
                table: "DetalheSessao",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalheSessao_HorarioId",
                table: "DetalheSessao",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalheSessao_SessaoId",
                table: "DetalheSessao",
                column: "SessaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalheSessao");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "Sessao");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COF.Infra.Data.Migrations
{
    public partial class AdicionadoLancamentoObjetivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LancamentoContaObjetivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdContaObjetivo = table.Column<int>(type: "int", nullable: false),
                    ValorLancamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataHoraOperacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    TipoOperacao = table.Column<string>(type: "char(1)", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentoContaObjetivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LancamentoContaObjetivo_ContaObjetivo_IdContaObjetivo",
                        column: x => x.IdContaObjetivo,
                        principalTable: "ContaObjetivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoContaObjetivo_IdContaObjetivo",
                table: "LancamentoContaObjetivo",
                column: "IdContaObjetivo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LancamentoContaObjetivo");
        }
    }
}

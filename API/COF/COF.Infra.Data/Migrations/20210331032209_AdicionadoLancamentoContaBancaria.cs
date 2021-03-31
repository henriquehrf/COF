using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COF.Infra.Data.Migrations
{
    public partial class AdicionadoLancamentoContaBancaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LancamentoContaBancaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdContaCorrente = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataHoraLancamento = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValorLancamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoOperacao = table.Column<string>(type: "char(1)", nullable: false),
                    GuidComprovante = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentoContaBancaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LancamentoContaBancaria_ContaBancaria_IdContaCorrente",
                        column: x => x.IdContaCorrente,
                        principalTable: "ContaBancaria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoContaBancaria_IdContaCorrente",
                table: "LancamentoContaBancaria",
                column: "IdContaCorrente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LancamentoContaBancaria");
        }
    }
}

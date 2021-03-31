using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COF.Infra.Data.Migrations
{
    public partial class AdicionadoContaObjetivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContaObjetivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    SaldoConta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdConfiguracaoObjetivo = table.Column<int>(type: "int", nullable: false),
                    LimiteObjetivo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    GrauImportancia = table.Column<short>(type: "smallInt", nullable: false, defaultValueSql: "0"),
                    EhContaTemporaria = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    DataHoraAlcance = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaObjetivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaObjetivo_ConfiguracaoObjetivo_IdConfiguracaoObjetivo",
                        column: x => x.IdConfiguracaoObjetivo,
                        principalTable: "ConfiguracaoObjetivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContaObjetivo_IdConfiguracaoObjetivo",
                table: "ContaObjetivo",
                column: "IdConfiguracaoObjetivo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContaObjetivo");
        }
    }
}

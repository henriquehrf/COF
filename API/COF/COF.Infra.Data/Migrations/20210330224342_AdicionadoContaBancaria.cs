using Microsoft.EntityFrameworkCore.Migrations;

namespace COF.Infra.Data.Migrations
{
    public partial class AdicionadoContaBancaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContaBancaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    SaldoConta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdBanco = table.Column<int>(type: "int", nullable: false),
                    IdConfiguracaoObjetivo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaBancaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaBancaria_Banco_IdBanco",
                        column: x => x.IdBanco,
                        principalTable: "Banco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContaBancaria_ConfiguracaoObjetivo_IdConfiguracaoObjetivo",
                        column: x => x.IdConfiguracaoObjetivo,
                        principalTable: "ConfiguracaoObjetivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContaBancaria_IdBanco",
                table: "ContaBancaria",
                column: "IdBanco");

            migrationBuilder.CreateIndex(
                name: "IX_ContaBancaria_IdConfiguracaoObjetivo",
                table: "ContaBancaria",
                column: "IdConfiguracaoObjetivo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContaBancaria");
        }
    }
}

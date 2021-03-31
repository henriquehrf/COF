using Microsoft.EntityFrameworkCore.Migrations;

namespace COF.Infra.Data.Migrations
{
    public partial class AdicaoTabelaPermissaoPessoaEConfiguracaoObjetivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissaoPessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissaoPessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracaoObjetivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPessoa = table.Column<int>(type: "int", nullable: false),
                    IdPermissaoPessoa = table.Column<int>(type: "int", nullable: false),
                    EhProprietario = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracaoObjetivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguracaoObjetivo_PermissaoPessoa_IdPermissaoPessoa",
                        column: x => x.IdPermissaoPessoa,
                        principalTable: "PermissaoPessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfiguracaoObjetivo_Pessoa_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracaoObjetivo_IdPermissaoPessoa",
                table: "ConfiguracaoObjetivo",
                column: "IdPermissaoPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracaoObjetivo_IdPessoa",
                table: "ConfiguracaoObjetivo",
                column: "IdPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfiguracaoObjetivo");

            migrationBuilder.DropTable(
                name: "PermissaoPessoa");
        }
    }
}

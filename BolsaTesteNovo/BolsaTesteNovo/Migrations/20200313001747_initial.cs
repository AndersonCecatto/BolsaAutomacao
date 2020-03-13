using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BolsaTesteNovo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Saldo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monitoramentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(nullable: true),
                    PrecoCompra = table.Column<decimal>(nullable: false),
                    PrecoVenda = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitoramentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Negociacaos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonitoramentoId = table.Column<int>(nullable: false),
                    ValorNegociado = table.Column<decimal>(nullable: false),
                    DataHora = table.Column<DateTime>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    TipoOperacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negociacaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Negociacaos_Monitoramentos_MonitoramentoId",
                        column: x => x.MonitoramentoId,
                        principalTable: "Monitoramentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Negociacaos_MonitoramentoId",
                table: "Negociacaos",
                column: "MonitoramentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Negociacaos");

            migrationBuilder.DropTable(
                name: "Monitoramentos");
        }
    }
}

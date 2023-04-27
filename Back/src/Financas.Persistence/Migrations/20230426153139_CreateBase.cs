using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Financas.Persistence.Migrations
{
    public partial class CreateBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estabelecimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CEP = table.Column<int>(type: "int", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gastos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Local = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    EstabelecimentoId = table.Column<int>(type: "int", nullable: false),
                    FormaPagamentoId = table.Column<int>(type: "int", nullable: false),
                    Outro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gastos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gastos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gastos_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gastos_FormaPagamentos_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormaPagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcelados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtdParcela = table.Column<int>(type: "int", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    EstabelecimentoId = table.Column<int>(type: "int", nullable: false),
                    FormaPagamentoId = table.Column<int>(type: "int", nullable: false),
                    Outro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcelados_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcelados_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcelados_FormaPagamentos_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormaPagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcelas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValoParcela = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumeroParcela = table.Column<int>(type: "int", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Pago = table.Column<bool>(type: "bit", nullable: true),
                    ParceladoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcelas_Parcelados_ParceladoId",
                        column: x => x.ParceladoId,
                        principalTable: "Parcelados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "DataCadastro", "Nome" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), "Mercado" },
                    { 2, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), "Farmácia" },
                    { 3, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), "Vestuário" },
                    { 4, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), "Eletrodoméstico" },
                    { 5, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), "Veículo" },
                    { 6, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), "Construção" },
                    { 7, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), "Cozinha" },
                    { 8, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), "Transporte" },
                    { 9, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), "Cama/Banho" },
                    { 10, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), "Academia" }
                });

            migrationBuilder.InsertData(
                table: "Estabelecimentos",
                columns: new[] { "Id", "Bairro", "CEP", "Cidade", "DataCadastro", "Endereco", "Foto", "Nome", "Numero", "Observacao", "UF" },
                values: new object[] { 1, "Ipanema", 91770001, "Porto Alegre", new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), "Av. Juca Batista", "image1.png", "Zafari", 925, null, "RS" });

            migrationBuilder.InsertData(
                table: "FormaPagamentos",
                columns: new[] { "Id", "DataCadastro", "Nome" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), "Cartão de Crédito" },
                    { 2, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), "Cartão de Débito" },
                    { 3, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), "Cartão Alimentação" },
                    { 4, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), "Dinheiro" },
                    { 5, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), "Pix" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_CategoriaId",
                table: "Gastos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_EstabelecimentoId",
                table: "Gastos",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_FormaPagamentoId",
                table: "Gastos",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelados_CategoriaId",
                table: "Parcelados",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelados_EstabelecimentoId",
                table: "Parcelados",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelados_FormaPagamentoId",
                table: "Parcelados",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_ParceladoId",
                table: "Parcelas",
                column: "ParceladoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gastos");

            migrationBuilder.DropTable(
                name: "Parcelas");

            migrationBuilder.DropTable(
                name: "Parcelados");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Estabelecimentos");

            migrationBuilder.DropTable(
                name: "FormaPagamentos");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanoVivo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id_Categoria = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Habitat = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Reino = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Familia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id_Categoria);
                });

            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    Id_Localizacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Latitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Longitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Pais = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.Id_Localizacao);
                });

            migrationBuilder.CreateTable(
                name: "Ongs",
                columns: table => new
                {
                    Id_Ong = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Cnpj = table.Column<string>(type: "NVARCHAR2(18)", maxLength: 18, nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ongs", x => x.Id_Ong);
                });

            migrationBuilder.CreateTable(
                name: "Situacoes",
                columns: table => new
                {
                    Id_Situacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Risco_Extincao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Invasora = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacoes", x => x.Id_Situacao);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Genero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    Id_Especie = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome_Comum = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Nome_Cientifico = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Id_Categoria = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Id_Situacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.Id_Especie);
                    table.ForeignKey(
                        name: "FK_Especies_Categorias_Id_Categoria",
                        column: x => x.Id_Categoria,
                        principalTable: "Categorias",
                        principalColumn: "Id_Categoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Especies_Situacoes_Id_Situacao",
                        column: x => x.Id_Situacao,
                        principalTable: "Situacoes",
                        principalColumn: "Id_Situacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deteccoes",
                columns: table => new
                {
                    Id_Deteccao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Url_Imagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data_Deteccao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Id_Usuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Id_Localizacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Id_Especie = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deteccoes", x => x.Id_Deteccao);
                    table.ForeignKey(
                        name: "FK_Deteccoes_Especies_Id_Especie",
                        column: x => x.Id_Especie,
                        principalTable: "Especies",
                        principalColumn: "Id_Especie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deteccoes_Localizacoes_Id_Localizacao",
                        column: x => x.Id_Localizacao,
                        principalTable: "Localizacoes",
                        principalColumn: "Id_Localizacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deteccoes_Usuarios_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OngDeteccao",
                columns: table => new
                {
                    OngId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DeteccaoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OngDeteccao", x => new { x.OngId, x.DeteccaoId });
                    table.ForeignKey(
                        name: "FK_OngDeteccao_Deteccoes_DeteccaoId",
                        column: x => x.DeteccaoId,
                        principalTable: "Deteccoes",
                        principalColumn: "Id_Deteccao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OngDeteccao_Ongs_OngId",
                        column: x => x.OngId,
                        principalTable: "Ongs",
                        principalColumn: "Id_Ong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deteccoes_Id_Especie",
                table: "Deteccoes",
                column: "Id_Especie");

            migrationBuilder.CreateIndex(
                name: "IX_Deteccoes_Id_Localizacao",
                table: "Deteccoes",
                column: "Id_Localizacao");

            migrationBuilder.CreateIndex(
                name: "IX_Deteccoes_Id_Usuario",
                table: "Deteccoes",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Especies_Id_Categoria",
                table: "Especies",
                column: "Id_Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Especies_Id_Situacao",
                table: "Especies",
                column: "Id_Situacao");

            migrationBuilder.CreateIndex(
                name: "IX_OngDeteccao_DeteccaoId",
                table: "OngDeteccao",
                column: "DeteccaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OngDeteccao");

            migrationBuilder.DropTable(
                name: "Deteccoes");

            migrationBuilder.DropTable(
                name: "Ongs");

            migrationBuilder.DropTable(
                name: "Especies");

            migrationBuilder.DropTable(
                name: "Localizacoes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Situacoes");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanoVivo.Migrations
{
    /// <inheritdoc />
    public partial class Addedpredeteccao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Deteccoes",
                columns: new[] { "Id_Deteccao", "Data_Deteccao", "Id_Especie", "Id_Localizacao", "Id_Usuario", "Url_Imagem" },
                values: new object[] { 1, new DateTime(2024, 6, 7, 21, 36, 0, 195, DateTimeKind.Local).AddTicks(8323), 4, 1, 2, "https://exemplo.com/imagem.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Deteccoes",
                keyColumn: "Id_Deteccao",
                keyValue: 1);
        }
    }
}

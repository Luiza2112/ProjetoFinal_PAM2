using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Feedback.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_FEEDBACKS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Remetente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Destinatario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FEEDBACKS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_FEEDBACKS",
                columns: new[] { "Id", "Data", "Descricao", "Destinatario", "Remetente" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 10, 8, 5, 20, 0, DateTimeKind.Unspecified), "O ventilador da sala 7 foi concertado com sucesso. Favor dar baixa no chamado pelo sistema.", "Daniela", "Kelly" },
                    { 2, new DateTime(2025, 4, 15, 12, 50, 31, 0, DateTimeKind.Unspecified), "A visita do técnico precisou ser adiada, peço que aguarde mais alguns dias até a resolução do problema no pc do lab 4.", "Lucas", "Marion" },
                    { 3, new DateTime(2025, 4, 18, 7, 15, 44, 0, DateTimeKind.Unspecified), "A tela do pc do lab 4 foi trocada com sucesso, agradeço a paciencia. Favor dar baixa no chamado pelo sistema.", "Lucas", "Marion" },
                    { 4, new DateTime(2025, 4, 28, 17, 2, 28, 0, DateTimeKind.Unspecified), "Os mouses defeituosos do lab 2 foram substituídos com sucesso. Favor dar baixa no chamado pelo sistema.", "Aline", "Luis" },
                    { 5, new DateTime(2025, 5, 11, 13, 34, 12, 0, DateTimeKind.Unspecified), "Já encomendamos o vidro para a janela quebrada da sala 17 e o problema será resolvido o quanto antes.", "Roberto", "Flávio" },
                    { 6, new DateTime(2025, 5, 13, 9, 37, 53, 0, DateTimeKind.Unspecified), "A janela da sala 17 foi concertada com sucesso. Favor dar baixa no chamado pelo sistema.", "Roberto", "Flávio" },
                    { 7, new DateTime(2025, 5, 21, 14, 16, 49, 0, DateTimeKind.Unspecified), "O vazamento nos bebedouros do pátio foi resolvido imediatamente, agradecemos o aviso. Favor dar baixa no chamado pelo sistema.", "Carlos", "Amanda" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_FEEDBACKS");
        }
    }
}

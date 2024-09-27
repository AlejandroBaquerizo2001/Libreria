using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary1.Migrations
{
    /// <inheritdoc />
    public partial class AgregarPerchaYUbicacion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Perchas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Perchas_GeneroId",
                table: "Perchas",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Perchas_Generos_GeneroId",
                table: "Perchas",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perchas_Generos_GeneroId",
                table: "Perchas");

            migrationBuilder.DropIndex(
                name: "IX_Perchas_GeneroId",
                table: "Perchas");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Perchas");
        }
    }
}

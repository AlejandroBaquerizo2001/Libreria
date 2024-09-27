using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary1.Migrations
{
    /// <inheritdoc />
    public partial class _202405233 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "estado",
                table: "Libros",
                newName: "Estado");

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_GeneroId",
                table: "Libros",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Generos_GeneroId",
                table: "Libros",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Generos_GeneroId",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_GeneroId",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Libros");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Libros",
                newName: "estado");
        }
    }
}

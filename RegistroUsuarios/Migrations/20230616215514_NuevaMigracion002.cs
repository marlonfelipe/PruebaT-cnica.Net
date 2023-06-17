using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroUsuarios.Migrations
{
    /// <inheritdoc />
    public partial class NuevaMigracion002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadPalindromos",
                table: "Palindromo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PalindromoTexto",
                table: "Palindromo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Palindromo_PalindromoTexto",
                table: "Palindromo",
                column: "PalindromoTexto");

            migrationBuilder.AddForeignKey(
                name: "FK_Palindromo_Palindromo_PalindromoTexto",
                table: "Palindromo",
                column: "PalindromoTexto",
                principalTable: "Palindromo",
                principalColumn: "Texto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Palindromo_Palindromo_PalindromoTexto",
                table: "Palindromo");

            migrationBuilder.DropIndex(
                name: "IX_Palindromo_PalindromoTexto",
                table: "Palindromo");

            migrationBuilder.DropColumn(
                name: "CantidadPalindromos",
                table: "Palindromo");

            migrationBuilder.DropColumn(
                name: "PalindromoTexto",
                table: "Palindromo");
        }
    }
}

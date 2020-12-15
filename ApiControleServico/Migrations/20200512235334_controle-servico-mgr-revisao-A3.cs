using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiControleServico.Migrations
{
    public partial class controleservicomgrrevisaoA3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gps",
                table: "Endereco");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Produto",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Unidade",
                table: "Produto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Endereco",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTipo",
                table: "Endereco",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Endereco",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Unidade",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "IdTipo",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Endereco");

            migrationBuilder.AddColumn<string>(
                name: "Gps",
                table: "Endereco",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
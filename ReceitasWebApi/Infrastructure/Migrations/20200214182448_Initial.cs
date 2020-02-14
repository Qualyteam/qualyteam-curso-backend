using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReceitasWebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Ingredientes = table.Column<string>(nullable: true),
                    Preparacao = table.Column<string>(nullable: true),
                    UrlDaImagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receita");
        }
    }
}

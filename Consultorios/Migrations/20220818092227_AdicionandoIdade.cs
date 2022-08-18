using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultorios.Migrations
{
    public partial class AdicionandoIdade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Agendamentos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Agendamentos");
        }
    }
}

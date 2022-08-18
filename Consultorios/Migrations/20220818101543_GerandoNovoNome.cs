using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultorios.Migrations
{
    public partial class GerandoNovoNome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomePaciente",
                table: "tb_agendamento",
                newName: "nome_paciente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nome_paciente",
                table: "tb_agendamento",
                newName: "NomePaciente");
        }
    }
}

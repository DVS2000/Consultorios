using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultorios.Migrations
{
    public partial class GerandoAgendamentoNovo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Horario",
                table: "tb_agendamento",
                newName: "horario");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_agendamento",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "NomePaciente",
                table: "tb_agendamento",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "horario",
                table: "tb_agendamento",
                newName: "Horario");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_agendamento",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "NomePaciente",
                table: "tb_agendamento",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultorios.Migrations
{
    public partial class GerandaTabela1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Agendamentos",
                table: "Agendamentos");

            migrationBuilder.RenameTable(
                name: "Agendamentos",
                newName: "tb_agendamento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_agendamento",
                table: "tb_agendamento",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_agendamento",
                table: "tb_agendamento");

            migrationBuilder.RenameTable(
                name: "tb_agendamento",
                newName: "Agendamentos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agendamentos",
                table: "Agendamentos",
                column: "Id");
        }
    }
}

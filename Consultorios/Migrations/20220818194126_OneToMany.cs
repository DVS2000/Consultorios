using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultorios.Migrations
{
    public partial class OneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_paciente",
                table: "tb_consulta",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_consulta_id_paciente",
                table: "tb_consulta",
                column: "id_paciente");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_paciente_id_paciente",
                table: "tb_consulta",
                column: "id_paciente",
                principalTable: "tb_paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_paciente_id_paciente",
                table: "tb_consulta");

            migrationBuilder.DropIndex(
                name: "IX_tb_consulta_id_paciente",
                table: "tb_consulta");

            migrationBuilder.DropColumn(
                name: "id_paciente",
                table: "tb_consulta");
        }
    }
}

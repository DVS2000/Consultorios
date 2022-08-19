using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultorios.Migrations
{
    public partial class UpdateTableConsulta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_profissional_id_paciente",
                table: "tb_consulta");

            migrationBuilder.CreateIndex(
                name: "IX_tb_consulta_id_profissional",
                table: "tb_consulta",
                column: "id_profissional");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_profissional_id_profissional",
                table: "tb_consulta",
                column: "id_profissional",
                principalTable: "tb_profissional",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_profissional_id_profissional",
                table: "tb_consulta");

            migrationBuilder.DropIndex(
                name: "IX_tb_consulta_id_profissional",
                table: "tb_consulta");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_profissional_id_paciente",
                table: "tb_consulta",
                column: "id_paciente",
                principalTable: "tb_profissional",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

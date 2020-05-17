using Microsoft.EntityFrameworkCore.Migrations;

namespace employer_project.Migrations
{
    public partial class ModelAdjust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notasAluno_alunos_AlunoModelAlunoID",
                table: "notasAluno");

            migrationBuilder.DropIndex(
                name: "IX_notasAluno_AlunoModelAlunoID",
                table: "notasAluno");

            migrationBuilder.DropColumn(
                name: "AlunoModelAlunoID",
                table: "notasAluno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlunoModelAlunoID",
                table: "notasAluno",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_notasAluno_AlunoModelAlunoID",
                table: "notasAluno",
                column: "AlunoModelAlunoID");

            migrationBuilder.AddForeignKey(
                name: "FK_notasAluno_alunos_AlunoModelAlunoID",
                table: "notasAluno",
                column: "AlunoModelAlunoID",
                principalTable: "alunos",
                principalColumn: "AlunoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

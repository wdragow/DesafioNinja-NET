using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace employer_project.Migrations
{
    public partial class DBAdjust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alunos",
                columns: table => new
                {
                    AlunoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoCPF = table.Column<long>(maxLength: 11, nullable: false),
                    AlunoNome = table.Column<string>(maxLength: 50, nullable: true),
                    AlunoSobrenome = table.Column<string>(maxLength: 100, nullable: true),
                    AlunoCurso = table.Column<string>(maxLength: 100, nullable: true),
                    AlunoNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alunos", x => x.AlunoID);
                });

            migrationBuilder.CreateTable(
                name: "materias",
                columns: table => new
                {
                    MateriaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MateriaDesc = table.Column<string>(nullable: true),
                    materiaSitacao = table.Column<string>(nullable: true),
                    MateriaDataCad = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materias", x => x.MateriaID);
                });

            migrationBuilder.CreateTable(
                name: "notasAluno",
                columns: table => new
                {
                    NotaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoID = table.Column<int>(nullable: false),
                    MateriaID = table.Column<int>(nullable: false),
                    notaMateria = table.Column<int>(nullable: false),
                    AlunoModelAlunoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notasAluno", x => x.NotaID);
                    table.ForeignKey(
                        name: "FK_notasAluno_alunos_AlunoModelAlunoID",
                        column: x => x.AlunoModelAlunoID,
                        principalTable: "alunos",
                        principalColumn: "AlunoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_notasAluno_AlunoModelAlunoID",
                table: "notasAluno",
                column: "AlunoModelAlunoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "materias");

            migrationBuilder.DropTable(
                name: "notasAluno");

            migrationBuilder.DropTable(
                name: "alunos");
        }
    }
}

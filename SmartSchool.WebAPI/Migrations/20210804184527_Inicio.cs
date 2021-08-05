using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.WebAPI.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    DataInic = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataNasc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registro = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    DataInic = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataInic = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    CargaHoraria = table.Column<int>(type: "INTEGER", nullable: false),
                    PrerequisitoId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProfessorId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisciplinaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Nota = table.Column<int>(type: "INTEGER", nullable: true),
                    DataInic = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInic", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 1, true, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(3639), new DateTime(2005, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInic", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 2, true, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(4682), new DateTime(2005, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInic", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 3, true, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(4692), new DateTime(2005, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInic", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 4, true, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(4698), new DateTime(2005, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInic", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 5, true, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(4702), new DateTime(2005, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInic", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 6, true, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(4710), new DateTime(2005, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInic", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 7, true, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(4715), new DateTime(2005, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Tecnologia da Informação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Sistemas de Informação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Ciência da Computação" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInic", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 1, true, null, new DateTime(2021, 8, 4, 15, 45, 27, 645, DateTimeKind.Local).AddTicks(9378), "Lauro", 1, "Oliveira", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInic", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 2, true, null, new DateTime(2021, 8, 4, 15, 45, 27, 646, DateTimeKind.Local).AddTicks(6276), "Roberto", 2, "Soares", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInic", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 3, true, null, new DateTime(2021, 8, 4, 15, 45, 27, 646, DateTimeKind.Local).AddTicks(6288), "Ronaldo", 3, "Marconi", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInic", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 4, true, null, new DateTime(2021, 8, 4, 15, 45, 27, 646, DateTimeKind.Local).AddTicks(6290), "Rodrigo", 4, "Carvalho", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInic", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 5, true, null, new DateTime(2021, 8, 4, 15, 45, 27, 646, DateTimeKind.Local).AddTicks(6291), "Alexandre", 5, "Montanha", null });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 1, 0, 1, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 2, 0, 3, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 3, 0, 3, "Física", null, 2 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 4, 0, 1, "Português", null, 3 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 5, 0, 1, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 6, 0, 2, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 7, 0, 3, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 8, 0, 1, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 9, 0, 2, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 10, 0, 3, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 2, 1, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(5932), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 4, 5, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(5944), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 2, 5, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(5936), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 1, 5, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(5930), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 7, 4, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(6005), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 6, 4, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(6000), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 5, 4, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(5945), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 4, 4, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(5943), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 1, 4, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(5926), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 7, 3, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(6004), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 5, 5, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(5946), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 6, 3, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(5950), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 7, 2, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(6002), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 6, 2, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(5949), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 3, 2, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(5938), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 2, 2, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(5933), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 1, 2, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(5601), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 7, 1, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(6001), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 6, 1, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(5948), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 4, 1, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(5942), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 3, 1, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(5937), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 3, 3, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(5940), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[] { 7, 5, null, new DateTime(2021, 8, 4, 15, 45, 27, 653, DateTimeKind.Local).AddTicks(6006), null });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PrerequisitoId",
                table: "Disciplinas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}

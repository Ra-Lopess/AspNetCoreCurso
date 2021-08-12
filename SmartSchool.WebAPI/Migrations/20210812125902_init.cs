using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.WebAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sobrenome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataInic = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataNasc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Registro = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sobrenome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataInic = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DataInic = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false),
                    PrerequisitoId = table.Column<int>(type: "int", nullable: true),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: true),
                    DataInic = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInic", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(5348), new DateTime(2005, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555" },
                    { 2, true, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(6353), new DateTime(2005, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" },
                    { 3, true, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(6364), new DateTime(2005, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" },
                    { 4, true, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(6369), new DateTime(2005, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" },
                    { 5, true, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(6374), new DateTime(2005, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" },
                    { 6, true, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(6382), new DateTime(2005, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" },
                    { 7, true, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(6387), new DateTime(2005, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Tecnologia da Informação" },
                    { 2, "Sistemas de Informação" },
                    { 3, "Ciência da Computação" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInic", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2021, 8, 12, 9, 59, 1, 954, DateTimeKind.Local).AddTicks(5478), "Lauro", 1, "Oliveira", null },
                    { 2, true, null, new DateTime(2021, 8, 12, 9, 59, 1, 955, DateTimeKind.Local).AddTicks(1060), "Roberto", 2, "Soares", null },
                    { 3, true, null, new DateTime(2021, 8, 12, 9, 59, 1, 955, DateTimeKind.Local).AddTicks(1071), "Ronaldo", 3, "Marconi", null },
                    { 4, true, null, new DateTime(2021, 8, 12, 9, 59, 1, 955, DateTimeKind.Local).AddTicks(1073), "Rodrigo", 4, "Carvalho", null },
                    { 5, true, null, new DateTime(2021, 8, 12, 9, 59, 1, 955, DateTimeKind.Local).AddTicks(1074), "Alexandre", 5, "Montanha", null }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 0, 1, "Matemática", null, 1 },
                    { 2, 0, 3, "Matemática", null, 1 },
                    { 3, 0, 3, "Física", null, 2 },
                    { 4, 0, 1, "Português", null, 3 },
                    { 5, 0, 1, "Inglês", null, 4 },
                    { 6, 0, 2, "Inglês", null, 4 },
                    { 7, 0, 3, "Inglês", null, 4 },
                    { 8, 0, 1, "Programação", null, 5 },
                    { 9, 0, 2, "Programação", null, 5 },
                    { 10, 0, 3, "Programação", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInic", "Nota" },
                values: new object[,]
                {
                    { 2, 1, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7663), null },
                    { 4, 5, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7675), null },
                    { 2, 5, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7667), null },
                    { 1, 5, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7662), null },
                    { 7, 4, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7688), null },
                    { 6, 4, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7683), null },
                    { 5, 4, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7677), null },
                    { 4, 4, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7674), null },
                    { 1, 4, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7658), null },
                    { 7, 3, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7687), null },
                    { 5, 5, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7678), null },
                    { 6, 3, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7681), null },
                    { 7, 2, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7686), null },
                    { 6, 2, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7680), null },
                    { 3, 2, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7670), null },
                    { 2, 2, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7664), null },
                    { 1, 2, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7330), null },
                    { 7, 1, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7685), null },
                    { 6, 1, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7679), null },
                    { 4, 1, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7673), null },
                    { 3, 1, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7668), null },
                    { 3, 3, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7671), null },
                    { 7, 5, null, new DateTime(2021, 8, 12, 9, 59, 1, 961, DateTimeKind.Local).AddTicks(7689), null }
                });

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

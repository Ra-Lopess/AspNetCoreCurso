using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Models
{
    public class AlunoCurso // representa o relacionamento N : N entre alunos e disciplinas
    {
        public AlunoCurso() {}

        public AlunoCurso(int alunoId, int cursoId)
        {
            this.AlunoId = alunoId;
            this.CursoId = cursoId;
        }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public DateTime DataInic { get; set; } = DateTime.Now; // data atual
        public DateTime? DataFim { get; set; } = null;
    }
}

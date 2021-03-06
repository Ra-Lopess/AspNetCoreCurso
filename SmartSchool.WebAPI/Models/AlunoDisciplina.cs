using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Models
{
    public class AlunoDisciplina // representa o relacionamento N : N entre alunos e disciplinas
    {
        public AlunoDisciplina() {}

        public AlunoDisciplina(int alunoId, int disciplinaId)
        {
            this.AlunoId = alunoId;
            this.DisciplinaId = disciplinaId;
        }
        public int AlunoId { get; set; }
        public int? Nota { get; set; } = null;
        public Aluno Aluno { get; set; }
        public int DisciplinaId { get; set; }
        public DateTime DataInic { get; set; } = DateTime.Now; // data atual
        public DateTime? DataFim { get; set; } = null;
        public Disciplina Disciplina { get; set; }
    }
}

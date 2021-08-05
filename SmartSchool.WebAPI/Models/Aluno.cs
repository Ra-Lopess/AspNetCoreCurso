using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Models
{
    public class Aluno
    {
        public Aluno() {}

        public Aluno(int id, 
                     int matricula,
                     string nome,
                     string sobrenome,
                     string telefone,
                     DateTime dataNasc)
        {
            this.Id = id;
            this.Matricula = matricula;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Telefone = telefone;
            this.DataNasc = dataNasc;
        }

        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataInic { get; set; } = DateTime.Now; // data atual
        public DateTime? DataFim { get; set; } = null; // se ele nn receber nenhum valor, ja fico como false. Alem de rpecisar da ? para funcionar o = null
        public DateTime DataNasc { get; set; }
        public bool Ativo { get; set; } = true; // se ele nn receber nenhum valor, ja fico como true
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}

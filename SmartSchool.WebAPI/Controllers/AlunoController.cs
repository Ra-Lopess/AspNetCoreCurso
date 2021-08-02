using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase {
        public List<Aluno> Alunos = new List<Aluno>() { // criar uma lista que serve como base
            new Aluno() {
                Id = 1,
                Nome = "Raissa",
                Sobrenome = "Lopes",
                Telefone = "24022002"
            },
            new Aluno() {
                Id = 2,
                Nome = "Luiza",
                Sobrenome = "lulu",
                Telefone = "1234"
            },
            new Aluno() {
                Id = 3,
                Nome = "Samuel",
                Sobrenome = "siflux",
                Telefone = "4567"
            }
        };

        public AlunoController() { }

        [HttpGet]

        public IActionResult Get() {
            return Ok(Alunos);
        }

        [HttpGet("ById/{id}")] // agora passamos o id pela querystring, tipo: localhost:5000/api/aluno/ById/2

        public IActionResult GetById(int id) {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpGet("ByName")] // se nao passarmos o parametro como no antes, ele aceita pela querystring

        public IActionResult GetByNome(string nome, string sobrenome) {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpPost]

        public IActionResult Post(Aluno aluno) {
            return Ok(aluno);
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, Aluno aluno) {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]

        public IActionResult Patch(int id, Aluno aluno) {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id) {
            return Ok(id);
        }
    }
}

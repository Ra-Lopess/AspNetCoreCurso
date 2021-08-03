using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
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

        public readonly IRepository _repo;

        public AlunoController(IRepository repo) {
            _repo = repo;
        }

        [HttpGet]

        public IActionResult Get() {
            var result = _repo.GetAllAlunos(true); // true pra incluir os professores
            return Ok(result);
        }

        [HttpGet("{id}")] // agora passamos o id pela querystring, tipo: localhost:5000/api/aluno/ById/2

        public IActionResult GetById(int id) {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        /*[HttpGet("ByName")] // se nao passarmos o parametro como no antes, ele aceita pela querystring

        public IActionResult GetByNome(string nome, string sobrenome) {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }*/

        [HttpPost]

        public IActionResult Post(Aluno aluno) {
            _repo.Add(aluno);
            if(_repo.SaveChanges())
                return Ok(aluno);

            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, Aluno aluno) {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
                return Ok(aluno);

            return BadRequest("Aluno não atualizado");
        }

        [HttpPatch("{id}")]

        public IActionResult Patch(int id, Aluno aluno) {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
                return Ok(aluno);

            return BadRequest("Aluno não atualizado");
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id) {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _repo.Delete(alu);
            if (_repo.SaveChanges())
                return Ok("Aluno deletado");

            return BadRequest("Aluno não atualizado");
        }
    }
}

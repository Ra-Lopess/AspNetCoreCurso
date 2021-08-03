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

        private readonly DataContext _context;
        public AlunoController(DataContext context) {
            _context = context;
        }

        [HttpGet]

        public IActionResult Get() {
            return Ok(_context.Alunos);
        }

        [HttpGet("ById/{id}")] // agora passamos o id pela querystring, tipo: localhost:5000/api/aluno/ById/2

        public IActionResult GetById(int id) {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpGet("ByName")] // se nao passarmos o parametro como no antes, ele aceita pela querystring

        public IActionResult GetByNome(string nome, string sobrenome) {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpPost]

        public IActionResult Post(Aluno aluno) {
            _context.Add(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, Aluno aluno) {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _context.Update(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        [HttpPatch("{id}")]

        public IActionResult Patch(int id, Aluno aluno) {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _context.Update(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id) {
            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _context.Remove(aluno);
            _context.SaveChanges();

            return Ok(id);
        }
    }
}

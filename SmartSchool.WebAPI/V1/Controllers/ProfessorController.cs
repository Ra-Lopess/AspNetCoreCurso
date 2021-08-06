using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.V1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo) {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id) {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professro não encontrado!");

            return Ok(prof);
        }

        /*[HttpGet("ByName/{id}")]
        public IActionResult GetyName(string nome) {
            var prof = _context.Professores.FirstOrDefault(p => p.Nome.Contains(nome));
            if (prof == null) return BadRequest("Professro não encontrado!");

            return Ok(prof);
        }*/

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
                return Ok(professor);

            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _repo.Update(professor);
            if (_repo.SaveChanges())
                return Ok(professor);

            return BadRequest("Professor não atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor) {
            var prof = _repo.GetProfessorById(id);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _repo.Update(professor);
            if (_repo.SaveChanges())
                return Ok(professor);

            return BadRequest("Professor não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _repo.Delete(prof);
            if (_repo.SaveChanges())
                return Ok("Professor deletado");

            return BadRequest("Professor não deletado");
        }
    }
}

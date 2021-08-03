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
    public class ProfessorController : ControllerBase
    {
        private readonly DataContext _context;
        public ProfessorController(DataContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id) {
            var prof = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("Professro não encontrado!");

            return Ok(prof);
        }

        [HttpGet("ByName/{id}")]
        public IActionResult GetyName(string nome) {
            var prof = _context.Professores.FirstOrDefault(p => p.Nome.Contains(nome));
            if (prof == null) return BadRequest("Professro não encontrado!");

            return Ok(prof);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();

            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _context.Update(professor);
            _context.SaveChanges();

            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor) {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _context.Update(professor);
            _context.SaveChanges();

            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _context.Remove(prof);
            _context.SaveChanges();

            return Ok(id);
        }
    }
}

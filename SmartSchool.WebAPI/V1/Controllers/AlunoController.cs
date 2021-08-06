using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.V1.Dtos;
using SmartSchool.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.V1.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AlunoController : ControllerBase {

        /// <summary>
        /// 
        /// </summary>

        public readonly IRepository _repo;

        /// <summary>
        /// 
        /// </summary>

        public readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>

        public AlunoController(IRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Método responsável por retornar todos alunos
        /// </summary>
        /// <returns></returns>

        [HttpGet]

        public IActionResult Get() {
            var alunos = _repo.GetAllAlunos(true); // true pra incluir os professores
            
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        /// <summary>
        /// Método responsável por retornar um aluno a partir de seu Id
        /// </summary>
        /// <returns></returns>

        [HttpGet("getRegister")]

        public IActionResult GetRegister() {
            var alunos = _repo.GetAllAlunos(true); 
            return Ok(new AlunoRegistrarDto());
        }

        [HttpGet("{id}")] // agora passamos o id pela querystring, tipo: localhost:5000/api/aluno/ById/2

        public IActionResult GetById(int id) {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(_mapper.Map<AlunoDto>(aluno));
        }

        /*[HttpGet("ByName")] // se nao passarmos o parametro como no antes, ele aceita pela querystring

        public IActionResult GetByNome(string nome, string sobrenome) {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }*/

        [HttpPost]

        public IActionResult Post(AlunoDto model) {
            var aluno = _mapper.Map<Aluno>(model);

            _repo.Add(aluno);
            if(_repo.SaveChanges())
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));

            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, AlunoDto model) {

            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _mapper.Map(model, alu);

            _repo.Update(alu);
            if (_repo.SaveChanges())
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(alu));

            return BadRequest("Aluno não atualizado");
        }

        [HttpPatch("{id}")]

        public IActionResult Patch(int id, AlunoDto model) {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _mapper.Map(model, alu);

            _repo.Update(alu);
            if (_repo.SaveChanges())
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(alu));

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

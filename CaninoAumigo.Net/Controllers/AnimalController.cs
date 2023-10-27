using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CaninoAumigo_API.Data;
using CaninoAumigo_API.Models;

namespace CaninoAumigo_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : Controller
    {
        private readonly CaninoContext _context;

        public AnimalController(CaninoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Animal>> GetAll()
        {
            return _context.Animal.ToList();
        }

        [HttpGet("{AnimalId}")]
        public ActionResult<List<Animal>> Get(int AnimalId)
        {
            try
            {
                var result = _context.Animal.Find(AnimalId);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }
        [HttpGet("porte/{AnimalPorte}")]
        public ActionResult<List<Animal>> GetAnimalPorte(int AnimalPorte)
        {

            try
            {
                var result = _context.Animal.Where(a => a.idPorte == AnimalPorte).ToList();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");

            }

        }

        [HttpPost]
        public async Task<ActionResult> post(Animal model)
        {
            try
            {
                _context.Animal.Add(model);
                if (await _context.SaveChangesAsync() == 1)
                {
                    return Created($"/api/animal/{model.nome}", model);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
                // return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }

            return BadRequest();
        }

        [HttpPut("{AnimalId}")]
        public async Task<ActionResult> put(int AnimalId, Animal dadosAnimalAlt)
        {
            try
            {
                var result = await _context.Animal.FindAsync(AnimalId);
                if (AnimalId != result.idAnimal)
                {
                    return BadRequest();
                }
                result.nome = dadosAnimalAlt.nome;
                result.raca = dadosAnimalAlt.raca;
                result.cor = dadosAnimalAlt.cor;
                result.idade = dadosAnimalAlt.idade;
                result.descricao = dadosAnimalAlt.descricao;
                result.genero = dadosAnimalAlt.genero;
                result.vacinacao = dadosAnimalAlt.vacinacao;
                result.idPorte = dadosAnimalAlt.idPorte;
                result.idCidade = dadosAnimalAlt.idCidade;
                result.imagem = dadosAnimalAlt.imagem;

                await _context.SaveChangesAsync();
                return Created($"/api/animal/{dadosAnimalAlt.nome}", dadosAnimalAlt);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpDelete("{AnimalId}")]
        public async Task<ActionResult> delete(int AnimalId)
        {
            try
            {
                var Animal = await _context.Animal.FindAsync(AnimalId);

                if (Animal == null)
                {
                    return NotFound();
                }

                _context.Remove(Animal);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }
    }
}
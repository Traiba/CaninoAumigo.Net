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
    public class AnimalPerdidoController : Controller
    {
        private readonly CaninoContext _context;

        public AnimalPerdidoController(CaninoContext context){
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<AnimalPerdido>> GetAll() {
            return _context.AnimalPerdido.ToList();
        }

        [HttpGet("{AnimalPerdidoId}")]
        public ActionResult<List<AnimalPerdido>> Get(int AnimalPerdidoId){
            try
            {
                var result = _context.AnimalPerdido.Find(AnimalPerdidoId);
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
        public async Task<ActionResult> post(AnimalPerdido model){
            try
            {
                _context.AnimalPerdido.Add(model);
                if (await _context.SaveChangesAsync() == 1)
                {
                    return Created($"/api/animalPerdido/{model.nome}", model);
                }
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }

            return BadRequest();
        }

        [HttpPut("{AnimalPerdidoId}")]
        public async Task<ActionResult> put(int AnimalPerdidoId, AnimalPerdido dadosAnimalPerdidoAlt){
            try{
                var result = await _context.AnimalPerdido.FindAsync(AnimalPerdidoId);
                if (AnimalPerdidoId != result.idAnimalPerdido)
                {
                    return BadRequest();
                }

                result.nome = dadosAnimalPerdidoAlt.nome;
                result.complemento = dadosAnimalPerdidoAlt.complemento;
                result.telefone = dadosAnimalPerdidoAlt.telefone;
                result.email = dadosAnimalPerdidoAlt.email;
                result.imagem = dadosAnimalPerdidoAlt.imagem;
                result.idCidade = dadosAnimalPerdidoAlt.idCidade;
                
                await _context.SaveChangesAsync();
                return Created($"/api/AnimalPerdido/{dadosAnimalPerdidoAlt.nome}", dadosAnimalPerdidoAlt);
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpDelete("{AnimalPerdidoId}")]
        public async Task<ActionResult> delete(int AnimalPerdidoId){
            try{
                var AnimalPerdido = await _context.AnimalPerdido.FindAsync(AnimalPerdidoId);
                
                if(AnimalPerdido == null)
                {
                    return NotFound();
                }
                
                _context.Remove(AnimalPerdido);
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
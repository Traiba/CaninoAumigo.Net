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
    public class EstadoController : Controller
    {
        private readonly CaninoContext _context;

        public EstadoController(CaninoContext context){
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Estado>> GetAll() {
            return _context.Estado.ToList();
        }

        [HttpGet("{EstadoId}")]
        public ActionResult<List<Estado>> Get(int EstadoId){
            try
            {
                var result = _context.Estado.Find(EstadoId);
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
        public async Task<ActionResult> post(Estado model){
            try
            {
                _context.Estado.Add(model);
                if (await _context.SaveChangesAsync() == 1)
                {
                    return Created($"/api/Estado/{model.nome}", model);
                }
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }

            return BadRequest();
        }

        [HttpPut("{EstadoId}")]
        public async Task<ActionResult> put(int EstadoId, Estado dadosEstadoAlt){
            try{
                var result = await _context.Estado.FindAsync(EstadoId);
                if (EstadoId != result.idEstado)
                {
                    return BadRequest();
                }
                result.nome = dadosEstadoAlt.nome;
                result.sigla = dadosEstadoAlt.sigla;
                
                await _context.SaveChangesAsync();
                return Created($"/api/Estado/{dadosEstadoAlt.nome}", dadosEstadoAlt);
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpDelete("{EstadoId}")]
        public async Task<ActionResult> delete(int EstadoId){
            try{
                var Estado = await _context.Estado.FindAsync(EstadoId);
                
                if(Estado == null)
                {
                    return NotFound();
                }
                
                _context.Remove(Estado);
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
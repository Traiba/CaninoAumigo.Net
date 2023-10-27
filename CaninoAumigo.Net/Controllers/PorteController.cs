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
    public class PorteController : Controller
    {
        private readonly CaninoContext _context;

        public PorteController(CaninoContext context){
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Porte>> GetAll() {
            return _context.Porte.ToList();
        }

        [HttpGet("{PorteId}")]
        public ActionResult<List<Porte>> Get(int PorteId){
            try
            {
                var result = _context.Porte.Find(PorteId);
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
        public async Task<ActionResult> post(Porte model){
            try
            {
                _context.Porte.Add(model);
                if (await _context.SaveChangesAsync() == 1)
                {
                    return Created($"/api/Porte/{model.tamanho}", model);
                }
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }

            return BadRequest();
        }

        [HttpPut("{PorteId}")]
        public async Task<ActionResult> put(int PorteId, Porte dadosPorteAlt){
            try{
                var result = await _context.Porte.FindAsync(PorteId);
                if (PorteId != result.idPorte)
                {
                    return BadRequest();
                }
                result.tamanho = dadosPorteAlt.tamanho;
                
                await _context.SaveChangesAsync();
                return Created($"/api/Porte/{dadosPorteAlt.tamanho}", dadosPorteAlt);
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpDelete("{PorteId}")]
        public async Task<ActionResult> delete(int PorteId){
            try{
                var Porte = await _context.Porte.FindAsync(PorteId);
                
                if(Porte == null)
                {
                    return NotFound();
                }
                
                _context.Remove(Porte);
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
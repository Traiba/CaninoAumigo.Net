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
    public class CidadeController : Controller
    {
        private readonly CaninoContext _context;

        public CidadeController(CaninoContext context){
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Cidade>> GetAll() {
            return _context.Cidade.ToList();
        }

        [HttpGet("{CidadeId}")]
        public ActionResult<List<Cidade>> Get(int CidadeId){
            try
            {
                var result = _context.Cidade.Find(CidadeId);
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
        public async Task<ActionResult> post(Cidade model){
            try
            {
                _context.Cidade.Add(model);
                if (await _context.SaveChangesAsync() == 1)
                {
                    return Created($"/api/cidade/{model.nome}", model);
                }
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }

            return BadRequest();
        }

        [HttpPut("{CidadeId}")]
        public async Task<ActionResult> put(int CidadeId, Cidade dadosCidadeAlt){
            try{
                var result = await _context.Cidade.FindAsync(CidadeId);
                if (CidadeId != result.idCidade)
                {
                    return BadRequest();
                }
                result.nome = dadosCidadeAlt.nome;
                result.idEstado = dadosCidadeAlt.idEstado;
                
                await _context.SaveChangesAsync();
                return Created($"/api/cidade/{dadosCidadeAlt.nome}", dadosCidadeAlt);
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpDelete("{CidadeId}")]
        public async Task<ActionResult> delete(int CidadeId){
            try{
                var Cidade = await _context.Cidade.FindAsync(CidadeId);
                
                if(Cidade == null)
                {
                    return NotFound();
                }
                
                _context.Remove(Cidade);
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
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
    public class ContaController : Controller
    {
        private readonly CaninoContext _context;

        public ContaController(CaninoContext context){
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Conta>> GetAll() {
            return _context.Conta.ToList();
        }

        [HttpGet("{ContaId}")]
        public ActionResult<List<Conta>> Get(int ContaId){
            try
            {
                var result = _context.Conta.Find(ContaId);
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
        public async Task<ActionResult> post(Conta model){
            try
            {
                _context.Conta.Add(model);
                if (await _context.SaveChangesAsync() == 1)
                {
                    return Created($"/api/Conta/{model.nome}", model);
                }
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }

            return BadRequest();
        }

        [HttpPut("{ContaId}")]
        public async Task<ActionResult> put(int ContaId, Conta dadosContaAlt){
            try{
                var result = await _context.Conta.FindAsync(ContaId);
                if (ContaId != result.idConta)
                {
                    return BadRequest();
                }

                result.senha = dadosContaAlt.senha;
                result.cpf = dadosContaAlt.cpf;
                result.nome = dadosContaAlt.nome;
                result.telefone = dadosContaAlt.telefone;
                result.email = dadosContaAlt.email;
                result.endereco = dadosContaAlt.endereco;
                result.idade = dadosContaAlt.idade;
                result.imagem = dadosContaAlt.imagem;
                
                await _context.SaveChangesAsync();
                return Created($"/api/Conta/{dadosContaAlt.nome}", dadosContaAlt);
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpDelete("{ContaId}")]
        public async Task<ActionResult> delete(int ContaId){
            try{
                var Conta = await _context.Conta.FindAsync(ContaId);
                
                if(Conta == null)
                {
                    return NotFound();
                }
                
                _context.Remove(Conta);
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
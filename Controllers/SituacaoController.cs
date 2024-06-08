using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OceanoVivo.Data;
using OceanoVivo.Models;

namespace OceanoVivo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SituacaoController : ControllerBase
    {
        private readonly OceanoVivoDbContext _context;

        public SituacaoController(OceanoVivoDbContext context)
        {
            _context = context;
        }

        // GET: api/Situacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Situacao>>> GetSituacoes()
        {
            return await _context.Situacoes.ToListAsync();
        }

        // GET: api/Situacao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Situacao>> GetSituacao(int id)
        {
            var situacao = await _context.Situacoes.FindAsync(id);

            if (situacao == null)
            {
                return NotFound();
            }

            return situacao;
        }

        // POST: api/Situacao
        [HttpPost]
        public async Task<ActionResult<Situacao>> PostSituacao(Situacao situacao)
        {
            _context.Situacoes.Add(situacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSituacao), new { id = situacao.Id_Situacao }, situacao);
        }

        // PUT: api/Situacao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSituacao(int id, Situacao situacao)
        {
            if (id != situacao.Id_Situacao)
            {
                return BadRequest();
            }

            _context.Entry(situacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SituacaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Situacao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSituacao(int id)
        {
            var situacao = await _context.Situacoes.FindAsync(id);
            if (situacao == null)
            {
                return NotFound();
            }

            _context.Situacoes.Remove(situacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SituacaoExists(int id)
        {
            return _context.Situacoes.Any(e => e.Id_Situacao == id);
        }
    }
}

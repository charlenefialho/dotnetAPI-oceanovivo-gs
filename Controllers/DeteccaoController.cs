using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OceanoVivo.Data;
using OceanoVivo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanoVivo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeteccaosController : ControllerBase
    {
        private readonly OceanoVivoDbContext _context;

        public DeteccaosController(OceanoVivoDbContext context)
        {
            _context = context;
        }

        // GET: api/Deteccaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deteccao>>> GetDeteccaos()
        {
            return await _context.Deteccoes.Include(d => d.Usuario)
                                           .Include(d => d.Localizacao)
                                           .Include(d => d.Especie)
                                           .Include(d => d.OngDeteccoes)
                                           .ThenInclude(od => od.Ong)
                                           .ToListAsync();
        }

        // GET: api/Deteccaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deteccao>> GetDeteccao(int id)
        {
            var deteccao = await _context.Deteccoes.Include(d => d.Usuario)
                                                   .Include(d => d.Localizacao)
                                                   .Include(d => d.Especie)
                                                   .Include(d => d.OngDeteccoes)
                                                   .ThenInclude(od => od.Ong)
                                                   .FirstOrDefaultAsync(d => d.Id_Deteccao == id);

            if (deteccao == null)
            {
                return NotFound();
            }

            return deteccao;
        }

        // POST: api/Deteccaos
        [HttpPost]
        public async Task<ActionResult<Deteccao>> PostDeteccao(Deteccao deteccao)
        {
            _context.Deteccoes.Add(deteccao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeteccao", new { id = deteccao.Id_Deteccao }, deteccao);
        }

        // PUT: api/Deteccaos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeteccao(int id, Deteccao deteccao)
        {
            if (id != deteccao.Id_Deteccao)
            {
                return BadRequest();
            }

            _context.Entry(deteccao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeteccaoExists(id))
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

        // DELETE: api/Deteccaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeteccao(int id)
        {
            var deteccao = await _context.Deteccoes.FindAsync(id);
            if (deteccao == null)
            {
                return NotFound();
            }

            _context.Deteccoes.Remove(deteccao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeteccaoExists(int id)
        {
            return _context.Deteccoes.Any(e => e.Id_Deteccao == id);
        }
    }
}

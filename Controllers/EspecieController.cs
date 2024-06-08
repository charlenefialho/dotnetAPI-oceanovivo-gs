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
    public class EspecieController : ControllerBase
    {
        private readonly OceanoVivoDbContext _context;

        public EspecieController(OceanoVivoDbContext context)
        {
            _context = context;
        }

        // GET: api/Especie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especie>>> GetEspecies()
        {
            return await _context.Especies
                .Include(e => e.Categoria)
                .Include(e => e.Situacao)
                .ToListAsync();
        }

        // GET: api/Especie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Especie>> GetEspecie(int id)
        {
            var especie = await _context.Especies
                .Include(e => e.Categoria)
                .Include(e => e.Situacao)
                .FirstOrDefaultAsync(e => e.Id_Especie == id);

            if (especie == null)
            {
                return NotFound();
            }

            return especie;
        }

        // POST: api/Especie
        [HttpPost]
        public async Task<ActionResult<Especie>> PostEspecie(Especie especie)
        {
            _context.Especies.Add(especie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEspecie), new { id = especie.Id_Especie }, especie);
        }

        // PUT: api/Especie/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecie(int id, Especie especie)
        {
            if (id != especie.Id_Especie)
            {
                return BadRequest();
            }

            _context.Entry(especie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecieExists(id))
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

        // DELETE: api/Especie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecie(int id)
        {
            var especie = await _context.Especies.FindAsync(id);
            if (especie == null)
            {
                return NotFound();
            }

            _context.Especies.Remove(especie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspecieExists(int id)
        {
            return _context.Especies.Any(e => e.Id_Especie == id);
        }
    }
}

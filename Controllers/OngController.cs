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
    public class OngController : ControllerBase
    {
        private readonly OceanoVivoDbContext _context;

        public OngController(OceanoVivoDbContext context)
        {
            _context = context;
        }

        // GET: api/Ong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ong>>> GetOngs()
        {
            return await _context.Ongs.ToListAsync();
        }

        // GET: api/Ong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ong>> GetOng(int id)
        {
            var ong = await _context.Ongs.FindAsync(id);

            if (ong == null)
            {
                return NotFound();
            }

            return ong;
        }

        // POST: api/Ong
        [HttpPost]
        public async Task<ActionResult<Ong>> PostOng(Ong ong)
        {
            _context.Ongs.Add(ong);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOng), new { id = ong.Id_Ong }, ong);
        }

        // PUT: api/Ong/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOng(int id, Ong ong)
        {
            if (id != ong.Id_Ong)
            {
                return BadRequest();
            }

            _context.Entry(ong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OngExists(id))
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

        // DELETE: api/Ong/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOng(int id)
        {
            var ong = await _context.Ongs.FindAsync(id);
            if (ong == null)
            {
                return NotFound();
            }

            _context.Ongs.Remove(ong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OngExists(int id)
        {
            return _context.Ongs.Any(e => e.Id_Ong == id);
        }
    }
}

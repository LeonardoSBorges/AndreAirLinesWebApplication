using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreAirLinesWebApplication.Data;
using AndreAirLinesWebApplication.Model;
using AndreAirLinesWebApplication.DTO;

namespace AndreAirLinesWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecoBasesController : ControllerBase
    {
        private readonly AndreAirLinesWebApplicationContext _context;

        public PrecoBasesController(AndreAirLinesWebApplicationContext context)
        {
            _context = context;
        }

        // GET: api/PrecoBases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrecoBase>>> GetPrecoBase()
        {
            return await _context.PrecoBase
                .Include(precoBase => precoBase.Origem.Endereco)
                .Include(precoBase => precoBase.Destino.Endereco)
                .Include(precoBase => precoBase.Classe).ToListAsync();
        }

        // GET: api/PrecoBases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrecoBase>> GetPrecoBase(int id)
        {
            var precoBase = await _context.PrecoBase
                .Include(precoBase => precoBase.Origem.Endereco)
                .Include(precoBase => precoBase.Destino.Endereco)
                .Include(precoBase => precoBase.Classe)
                .FirstOrDefaultAsync();

            if (precoBase == null)
            {
                return NotFound();
            }

            return precoBase;
        }

        // PUT: api/PrecoBases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrecoBase(int id, PrecoBase precoBase)
        {
            if (id != precoBase.Id)
            {
                return BadRequest();
            }

            _context.Entry(precoBase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrecoBaseExists(id))
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

        // POST: api/PrecoBases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrecoBase>> PostPrecoBase(PrecoBaseDTO precoBaseDTO)
        {
            PrecoBase precoBase = null;

            try
            {
                var Origem = await _context.Aeroporto.Include(aeroporto => aeroporto.Endereco).Where(aeroporto => aeroporto.Sigla == precoBaseDTO.OrigemId).FirstOrDefaultAsync();
                var Destino = await _context.Aeroporto.Include(aeroporto => aeroporto.Endereco).Where(aeroporto => aeroporto.Sigla == precoBaseDTO.DestinoId).FirstOrDefaultAsync();
                var Classe = await _context.Classe.Where(classe => classe.Id == precoBaseDTO.ClasseId).FirstOrDefaultAsync();
                if (Origem == null || Destino == null || Classe == null)
                    throw new Exception("The value inserted not exists in DataBase");
                double valor = precoBaseDTO.Valor + (precoBaseDTO.Valor * (Classe.ValorPorcentagem / 100));
                precoBase = new PrecoBase(Origem, Destino, valor, Classe, DateTime.Now);
                _context.PrecoBase.Add(precoBase);
                await _context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }


            return CreatedAtAction("GetPrecoBase", new { id = precoBase.Id }, precoBase);
        }

        // DELETE: api/PrecoBases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrecoBase(int id)
        {
            var precoBase = await _context.PrecoBase.FindAsync(id);
            if (precoBase == null)
            {
                return NotFound();
            }

            _context.PrecoBase.Remove(precoBase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrecoBaseExists(int id)
        {
            return _context.PrecoBase.Any(e => e.Id == id);
        }
    }
}

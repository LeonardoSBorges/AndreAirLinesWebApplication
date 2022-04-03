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
    public class PassagemsController : ControllerBase
    {
        private readonly AndreAirLinesWebApplicationContext _context;

        public PassagemsController(AndreAirLinesWebApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Passagems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passagem>>> GetPassagem()
        {
            return await _context.Passagem.Include(passagemPassageiro => passagemPassageiro.Passageiro.Endereco)
                                          .Include(passagemVoo => passagemVoo.Voo.Origem.Endereco)
                                          .Include(passagemVoo => passagemVoo.Voo.Destino.Endereco)
                                          .Include(passagemVoo => passagemVoo.Voo.Aeronave)
                                          .Include(passagemClasse => passagemClasse.Classe).ToListAsync();
        }

        // GET: api/Passagems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passagem>> GetPassagem(Guid id)
        {
            var passagem = await _context.Passagem
                .Include(passagemPassageiro => passagemPassageiro.Passageiro.Endereco)
                                          .Include(passagemVoo => passagemVoo.Voo.Origem.Endereco)
                                          .Include(passagemVoo => passagemVoo.Voo.Destino.Endereco)
                                          .Include(passagemVoo => passagemVoo.Voo.Aeronave)
                                          .Where(procuraPassagem => procuraPassagem.Id == id)
                                          .FirstOrDefaultAsync();

            if (passagem == null)
            {
                return NotFound();
            }

            return passagem;
        }

        // PUT: api/Passagems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassagem(Guid id, Passagem passagem)
        {
            if (id != passagem.Id)
            {
                return BadRequest();
            }

            _context.Entry(passagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassagemExists(id))
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

        // POST: api/Passagems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passagem>> PostPassagem(PassagemDTO passagemDTO)
        {
            Passageiro Passageiro = await _context.Passageiro
                .Where(procuraPassageiro => procuraPassageiro.Cpf.Equals(passagemDTO.PassageiroCpf)).FirstOrDefaultAsync();
            Voo Voo = await _context.Voo
                .Where(procuraVoo => procuraVoo.Id == passagemDTO.IdVoo).FirstOrDefaultAsync();
            Classe Classe = await _context.Classe
                .Where(procuraClasse => procuraClasse.Id.Equals(passagemDTO.IdClasse)).FirstOrDefaultAsync();
            
            Passagem passagem = new Passagem(Voo, Passageiro, 100, Classe);
            




            _context.Passagem.Add(passagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassagem", new { id = passagem.Id }, passagem);
        }

        // DELETE: api/Passagems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassagem(Guid id)
        {
            var passagem = await _context.Passagem.FindAsync(id);
            if (passagem == null)
            {
                return NotFound();
            }

            _context.Passagem.Remove(passagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassagemExists(Guid id)
        {
            return _context.Passagem.Any(e => e.Id == id);
        }
    }
}

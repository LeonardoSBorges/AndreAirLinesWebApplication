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
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;

namespace AndreAirLinesWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoosController : ControllerBase
    {
        private readonly AndreAirLinesWebApplicationContext _context;

        public VoosController(AndreAirLinesWebApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Voos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voo>>> GetVoo()
        {
            var result = await _context.Voo
                        .Include(enderecoDestino => enderecoDestino.Origem.Endereco)
                        .Include(enderecoOrigem => enderecoOrigem.Destino.Endereco)
                        .Include(a => a.Aeronave)
                        .Include(x => x.Passageiro.Endereco).ToListAsync();
            return result;
        }

        // GET: api/Voos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voo>> GetVoo(int id)
        {
            var voo = await _context.Voo.Include(x => x.Origem)
                                        .Include(x => x.Destino)
                                        .Include(x => x.Passageiro)
                                        .Include(x => x.Aeronave)
                                        .Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();
                                        

            if (voo == null)
            {
                return NotFound();
            }

            return voo;
        }

        // PUT: api/Voos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoo(int id, Voo voo)
        {
            if (id != voo.Id)
            {
                return BadRequest();
            }

            _context.Entry(voo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VooExists(id))
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

        // POST: api/Voos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VooDTO>> PostVoo(VooDTO vooDTO)
        {
            Voo Voo;
            var destino = await _context.Aeroporto.Where(endereco => endereco.Sigla == vooDTO.destino).FirstOrDefaultAsync();
            var origem = await _context.Aeroporto.Where(endereco => endereco.Sigla == vooDTO.origem).FirstOrDefaultAsync();
            var aeronave = await _context.Aeronave.Where(identificacao => identificacao.Id == vooDTO.aeronave).FirstOrDefaultAsync();
            var passageiro = await _context.Passageiro.Where(pessoa => pessoa.Cpf == vooDTO.cpf).FirstOrDefaultAsync();
            Voo = new Voo(destino, origem, aeronave, vooDTO.HorarioEmbarque, vooDTO.HorarioDesenbarque, passageiro);
            
            _context.Voo.Add(Voo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoo", new { id = Voo.Id }, vooDTO);
        }

        // DELETE: api/Voos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoo(int id)
        {
            var voo = await _context.Voo.FindAsync(id);
            if (voo == null)
            {
                return NotFound();
            }

            _context.Voo.Remove(voo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VooExists(int id)
        {
            return _context.Voo.Any(e => e.Id == id);
        }
    }
}

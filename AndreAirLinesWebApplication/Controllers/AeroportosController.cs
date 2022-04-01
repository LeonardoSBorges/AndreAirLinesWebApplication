using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreAirLinesWebApplication.Data;
using AndreAirLinesWebApplication.Model;
using System.Net.Http;
using System.Net.Http.Json;
using AndreAirLinesWebApplication.DTO;
using System.Net.Http.Headers;

namespace AndreAirLinesWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeroportosController : ControllerBase
    {
        private readonly AndreAirLinesWebApplicationContext _context;

        public AeroportosController(AndreAirLinesWebApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Aeroportoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aeroporto>>> GetAeroporto()
        {
            return await _context.Aeroporto.Include(x => x.Endereco).ToListAsync();
        }

        // GET: api/Aeroportoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aeroporto>> GetAeroporto(string id)
        {

            var aeroporto = await _context.Aeroporto.Include(x => x.Endereco).Where(x=>x.Sigla == id).FirstOrDefaultAsync();

            if (aeroporto == null)
            {
                return NotFound();
            }

            return aeroporto;
        }

        // PUT: api/Aeroportoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAeroporto(string id, Aeroporto aeroporto)
        {

            if (id != aeroporto.Sigla)
            {
                return BadRequest();
            }

            _context.Entry(aeroporto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeroportoExists(id))
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

        // POST: api/Aeroportoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aeroporto>> PostAeroporto(AeroportoDTO aeroportoDTO)
        {
            
            Aeroporto aeroporto = null;
            try
            {
                var verificaEndereco = _context.Endereco.Where(x => x.CEP == aeroportoDTO.cep).FirstOrDefault();
                if (verificaEndereco == null)
                {
                    verificaEndereco = await HTTPCorreios(aeroportoDTO.cep);
                    verificaEndereco.Numero = aeroportoDTO.numero;
                }
                    

                aeroporto = new Aeroporto(aeroportoDTO.sigla, aeroportoDTO.nome, verificaEndereco);
                _context.Aeroporto.Add(aeroporto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AeroportoExists(aeroportoDTO.sigla))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAeroporto", new { id = aeroporto.Sigla }, aeroporto);
        }

        // DELETE: api/Aeroportoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAeroporto(string id)
        {
            var aeroporto = await _context.Aeroporto.FindAsync(id);
            if (aeroporto == null)
            {
                return NotFound();
            }

            _context.Aeroporto.Remove(aeroporto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AeroportoExists(string id)
        {
            return _context.Aeroporto.Any(e => e.Sigla == id);
        }

        private async Task<Endereco> HTTPCorreios(string cep)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://viacep.com.br/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync($"ws/{cep}/json/");

            ViaCepDTO viaCep = await response.Content.ReadFromJsonAsync<ViaCepDTO>();

            var endereco = new Endereco(viaCep.bairro, viaCep.localidade, viaCep.cep, viaCep.logradouro, viaCep.uf);
            return endereco;
        }
    }
}

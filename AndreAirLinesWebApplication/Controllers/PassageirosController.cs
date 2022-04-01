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
    public class PassageirosController : ControllerBase
    {
        private readonly AndreAirLinesWebApplicationContext _context;

        public PassageirosController(AndreAirLinesWebApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Passageiros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passageiro>>> GetPassageiros()
        {
            return await _context.Passageiros.Include(e=>e.Endereco).ToListAsync();
        }

        // GET: api/Passageiros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passageiro>> GetPassageiros(string id)
        {
            var passageiros = await _context.Passageiros.Include(x => x.Endereco).Where(d => d.Cpf == id).FirstOrDefaultAsync();

            if (passageiros == null)
            {
                return NotFound();
            }

            return passageiros;
        }

        // PUT: api/Passageiros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassageiros(string id, Passageiro passageiros)
        {
            if (id != passageiros.Cpf)
            {
                return BadRequest();
            }

            _context.Entry(passageiros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassageirosExists(id))
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

        // POST: api/Passageiros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passageiro>> PostPassageiros(PassageiroDTO passageiros)
        {
            Endereco endereco = null;
            try
            {
                Endereco verificaEndereco = await _context.Endereco.Where(c => c.CEP == passageiros.CEP).FirstOrDefaultAsync();
                if(verificaEndereco == null) {
                    endereco = await HTTPCorreios(passageiros.CEP);
                    endereco.Numero = passageiros.Numero;
                }
                else
                    endereco = verificaEndereco;
                

                var pessoa = new Passageiro(passageiros.Cpf, passageiros.Nome, passageiros.Telefone, passageiros.DataNascimento, passageiros.Email, endereco);
                _context.Passageiros.Add(pessoa);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException)
            {
                if (PassageirosExists(passageiros.Cpf))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPassageiros", new { id = passageiros.Cpf }, passageiros);
        }

        // DELETE: api/Passageiros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassageiros(string id)
        {
            var passageiros = await _context.Passageiros.FindAsync(id);
            if (passageiros == null)
            {
                return NotFound();
            }

            _context.Passageiros.Remove(passageiros);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassageirosExists(string id)
        {
            return _context.Passageiros.Any(e => e.Cpf == id);
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

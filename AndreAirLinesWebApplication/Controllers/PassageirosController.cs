using System;
using AndreAirLinesWebApplication.Service;
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
            return await _context.Passageiro.Include(e => e.Endereco).ToListAsync();
        }

        // GET: api/Passageiros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passageiro>> GetPassageiros(string id)
        {
            var passageiros = await _context.Passageiro.Include(x => x.Endereco).Where(d => d.Cpf == id).FirstOrDefaultAsync();

            if (passageiros == null)
            {
                return NotFound();
            }

            return passageiros;
        }

        // PUT: api/Passageiros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassageiros(string id, PassageiroDTO passageiroDTO)
        {
            var passageiroExists = await _context.Passageiro.Where(procuraPassageiro => procuraPassageiro.Cpf == id).FirstOrDefaultAsync();

            if (passageiroExists == null)
                throw new Exception("passageiro not found");
            var endereco = await _context.Endereco.Include(procuraEndereco => procuraEndereco.CEP == passageiroDTO.CEP).FirstOrDefaultAsync();
            if (endereco == null) {
                endereco = await ViaCepCorreiosService.HTTPCorreios(passageiroDTO.CEP);
                endereco.Numero = passageiroDTO.Numero;
            }
            var passageiro = new Passageiro(passageiroDTO.Cpf, passageiroDTO.Nome, passageiroDTO.Telefone, passageiroDTO.DataNascimento, passageiroDTO.Email, endereco);

            if (id != passageiro.Cpf)
            {
                return BadRequest();
            }

            _context.Entry(passageiro).State = EntityState.Modified;

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
        public async Task<ActionResult<Passageiro>> PostPassageiros(PassageiroDTO passageiro)
        {
            Endereco endereco = null;
            Passageiro pessoa = null;
            var passageiroExiste = await _context.Passageiro.Where(passageiro => passageiro.Cpf == passageiro.Cpf).FirstOrDefaultAsync();
            try
            {
                if (passageiroExiste != null)
                    throw new Exception("Passageiro already exists");

                    Endereco verificaEndereco = await _context.Endereco.Where(c => c.CEP == passageiro.CEP).FirstOrDefaultAsync();
                    if (verificaEndereco == null)
                    {
                        endereco = await ViaCepCorreiosService.HTTPCorreios(passageiro.CEP);
                        if (endereco.CEP == null)
                            throw new Exception("the cep not exists");
                        endereco.Numero = passageiro.Numero;
                    }
                    else
                        endereco = verificaEndereco;


                    pessoa = new Passageiro(passageiro.Cpf, passageiro.Nome, passageiro.Telefone, passageiro.DataNascimento, passageiro.Email, endereco);
                    _context.Passageiro.Add(pessoa);
                    await _context.SaveChangesAsync();
                
            }
            catch (DbUpdateException)
            {
                if (PassageirosExists(passageiro.Cpf))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetPassageiros", new { id = pessoa.Cpf }, pessoa);
        }

        // DELETE: api/Passageiros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassageiros(string id)
        {
            var passageiros = await _context.Passageiro.FindAsync(id);
            if (passageiros == null)
            {
                return NotFound();
            }

            _context.Passageiro.Remove(passageiros);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassageirosExists(string id)
        {
            return _context.Passageiro.Any(e => e.Cpf == id);
        }

        
    }
}

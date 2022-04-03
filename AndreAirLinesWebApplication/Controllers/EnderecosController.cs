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
using AndreAirLinesWebApplication.Service;

namespace AndreAirLinesWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly AndreAirLinesWebApplicationContext _context;

        public EnderecosController(AndreAirLinesWebApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Enderecoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetEndereco()
        {
            return await _context.Endereco.ToListAsync();
        }

        // GET: api/Enderecoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetEndereco(int id)
        {
            var endereco = await _context.Endereco.FindAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return endereco;
        }

        // PUT: api/Enderecoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEndereco(int id, Endereco endereco)
        {
            var enderecoExists = await _context.Endereco.Where(procuraEndereco => procuraEndereco.Id == id).ToListAsync();

            if (enderecoExists == null)
                throw new Exception("Endereco not exists");


            if (id != endereco.Id)
            {
                return BadRequest();
            }

            _context.Entry(endereco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(id))
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

        // POST: api/Enderecoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Endereco>> PostEndereco(EnderecoDTO enderecoDTO)
        {
            Endereco enderecoCompleto = null;
            try
            {
                var enderecoExists = await _context.Endereco.Where(endereco => endereco.CEP == enderecoDTO.cep).FirstOrDefaultAsync();

                if (enderecoExists != null)
                    throw new Exception("Endereco already exists");

                enderecoCompleto = await ViaCepCorreiosService.HTTPCorreios(enderecoDTO.cep);
                if (enderecoCompleto != null)
                {
                    _context.Endereco.Add(enderecoCompleto);
                }
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException exception)
            {
                Console.WriteLine("Exception DataBase Update: " + exception);
            }
            return CreatedAtAction("GetEndereco", new { id = enderecoCompleto.CEP }, enderecoCompleto);
        }

        // DELETE: api/Enderecoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEndereco(int id)
        {
            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            _context.Endereco.Remove(endereco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnderecoExists(int id)
        {
            return _context.Endereco.Any(e => e.Id == id);
        }
    }
}

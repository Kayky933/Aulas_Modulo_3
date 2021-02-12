using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_01.Data;
using API_01.Models;

namespace API_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly DataBaseContext _context;
        
        public ContaController(DataBaseContext context)
        {            
            _context = context;
        }

        // GET: api/Conta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContaModel>>> GetConta()
        {            
            return await _context.Conta.ToListAsync();
        }

        // GET: api/Conta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContaModel>> GetContaModel(int id)
        {
            var contaModel = await _context.Conta.FindAsync(id);

            if (contaModel == null)
            {
                return NotFound();
            }

            return contaModel;
        }

        // PUT: api/Conta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContaModel(int id, ContaModel contaModel)
        {
            if (id != contaModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(contaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaModelExists(id))
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

        // POST: api/Conta
        [HttpPost]
        public async Task<ActionResult<ContaModel>> PostContaModel(ContaModel contaModel)
        {
            _context.Conta.Add(contaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContaModel", new { id = contaModel.Id }, contaModel);
        }

        // DELETE: api/Conta/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContaModel>> DeleteContaModel(int id)
        {
            var contaModel = await _context.Conta.FindAsync(id);
            if (contaModel == null)
            {
                return NotFound();
            }

            _context.Conta.Remove(contaModel);
            await _context.SaveChangesAsync();

            return contaModel;
        }

        private bool ContaModelExists(int id)
        {
            return _context.Conta.Any(e => e.Id == id);
        }
    }
}

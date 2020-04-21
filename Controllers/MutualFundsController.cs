using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransactionsApi.Models;

namespace TransactionsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MutualFundsController : ControllerBase
    {
        private readonly TransactionContext _context;

        public MutualFundsController(TransactionContext context)
        {
            _context = context;
        }

        // GET: api/MutualFunds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MutualFund>>> GetFunds()
        {
            return await _context.Funds.ToListAsync();
        }

        // GET: api/MutualFunds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MutualFund>> GetMutualFund(int id)
        {
            var mutualFund = await _context.Funds.FindAsync(id);

            if (mutualFund == null)
            {
                return NotFound();
            }

            return mutualFund;
        }

        // PUT: api/MutualFunds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMutualFund(int id, MutualFund mutualFund)
        {
            if (id != mutualFund.Id)
            {
                return BadRequest();
            }

            _context.Entry(mutualFund).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MutualFundExists(id))
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

        // POST: api/MutualFunds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MutualFund>> PostMutualFund(MutualFund mutualFund)
        {
            _context.Funds.Add(mutualFund);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMutualFund), new { id = mutualFund.Id }, mutualFund);
        }

        // DELETE: api/MutualFunds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MutualFund>> DeleteMutualFund(int id)
        {
            var mutualFund = await _context.Funds.FindAsync(id);
            if (mutualFund == null)
            {
                return NotFound();
            }

            _context.Funds.Remove(mutualFund);
            await _context.SaveChangesAsync();

            return mutualFund;
        }

        private bool MutualFundExists(int id)
        {
            return _context.Funds.Any(e => e.Id == id);
        }
    }
}

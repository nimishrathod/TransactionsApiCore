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
            return await _context.MutualFunds.ToListAsync();
        }

        // GET: api/MutualFunds/5
        [HttpGet("{schemeCode}")]
        public async Task<ActionResult<MutualFund>> GetMutualFund(string schemeCode)
        {
            var mutualFund = await _context.MutualFunds.FindAsync(schemeCode);

            if (mutualFund == null)
            {
                return NotFound();
            }

            return mutualFund;
        }

        // PUT: api/MutualFunds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{schemeCode}")]
        public async Task<IActionResult> PutMutualFund(string schemeCode, MutualFund mutualFund)
        {
            if (schemeCode != mutualFund.SchemeCode)
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
                if (!MutualFundExists(schemeCode))
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
            _context.MutualFunds.Add(mutualFund);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMutualFund), new { schemeCode = mutualFund.SchemeCode }, mutualFund);
        }

        // DELETE: api/MutualFunds/5
        [HttpDelete("{schemeCode}")]
        public async Task<ActionResult<MutualFund>> DeleteMutualFund(string schemeCode)
        {
            var mutualFund = await _context.MutualFunds.FindAsync(schemeCode);
            if (mutualFund == null)
            {
                return NotFound();
            }

            _context.MutualFunds.Remove(mutualFund);
            await _context.SaveChangesAsync();

            return mutualFund;
        }

        private bool MutualFundExists(string schemeCode)
        {
            return _context.MutualFunds.Any(e => e.SchemeCode == schemeCode);
        }
    }
}

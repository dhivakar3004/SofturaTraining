using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBTransactionAPI.Data;
using SBTransactionAPI.Models;

namespace SBTransactionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTransController : ControllerBase
    {
        private readonly SBTransactionAPIContext _context;

        public AccountTransController(SBTransactionAPIContext context)
        {
            _context = context;
        }

        // GET: api/AccountTrans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountTrans>>> GetAccountTrans()
        {
            return await _context.AccountTrans.ToListAsync();
        }

        // GET: api/AccountTrans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountTrans>> GetAccountTrans(int id)
        {
            var accountTrans = await _context.AccountTrans.FindAsync(id);

            if (accountTrans == null)
            {
                return NotFound();
            }

            return accountTrans;
        }

        // PUT: api/AccountTrans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountTrans(int id, AccountTrans accountTrans)
        {
            if (id != accountTrans.ID)
            {
                return BadRequest();
            }

            _context.Entry(accountTrans).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountTransExists(id))
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

        // POST: api/AccountTrans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccountTrans>> PostAccountTrans(AccountTrans accountTrans)
        {
            _context.AccountTrans.Add(accountTrans);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountTrans", new { id = accountTrans.ID }, accountTrans);
        }

        // DELETE: api/AccountTrans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountTrans(int id)
        {
            var accountTrans = await _context.AccountTrans.FindAsync(id);
            if (accountTrans == null)
            {
                return NotFound();
            }

            _context.AccountTrans.Remove(accountTrans);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountTransExists(int id)
        {
            return _context.AccountTrans.Any(e => e.ID == id);
        }
    }
}

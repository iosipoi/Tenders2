using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tenders.Data;
using Tenders.Models;

namespace Tenders.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TendersController : ControllerBase
    {
        private readonly TendersContext _context;

        public TendersController(TendersContext context)
        {
            _context = context;
        }

        // GET: api/Tenders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TenderDetails>>> GetTenderDetails()
        {
            return await _context.TenderDetails.ToListAsync();
        }

        // GET: api/Tenders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TenderDetails>> GetTenderDetails(int id)
        {
            var tenderDetails = await _context.TenderDetails.FindAsync(id);

            if (tenderDetails == null)
            {
                return NotFound();
            }

            return tenderDetails;
        }

        // PUT: api/Tenders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTenderDetails(int id, TenderDetails tenderDetails)
        {
            if (id != tenderDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(tenderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenderDetailsExists(id))
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

        // POST: api/Tenders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TenderDetails>> PostTenderDetails(TenderDetails tenderDetails)
        {
            _context.TenderDetails.Add(tenderDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTenderDetails", new { id = tenderDetails.Id }, tenderDetails);
        }

        // DELETE: api/Tenders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TenderDetails>> DeleteTenderDetails(int id)
        {
            var tenderDetails = await _context.TenderDetails.FindAsync(id);
            if (tenderDetails == null)
            {
                return NotFound();
            }

            _context.TenderDetails.Remove(tenderDetails);
            await _context.SaveChangesAsync();

            return tenderDetails;
        }

        private bool TenderDetailsExists(int id)
        {
            return _context.TenderDetails.Any(x=> x.Id == id);  
        }
    }
}

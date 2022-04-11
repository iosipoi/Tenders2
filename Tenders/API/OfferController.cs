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
    public class OfferController : ControllerBase
    {
        private readonly TendersContext _context;

        public OfferController(TendersContext context)
        {
            _context = context;
        }

        // GET: api/Offer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferDetails>>> GetOfferDetails()
        {
            return await _context.OfferDetails.ToListAsync();
        }

        // GET: api/Offer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferDetails>> GetOfferDetails(int id)
        {
            var offerDetails = await _context.OfferDetails.FindAsync(id);

            if (offerDetails == null)
            {
                return NotFound();
            }

            return offerDetails;
        }

        // GET: api/Offer/bytender/5
        //[Route("bytender")]
        [HttpGet("bytender/{id}")]
        public async Task<ActionResult<IEnumerable<OfferDetails>>> GetOfferByTenderId(int id)
        {
            var offerDetails = _context.OfferDetails.Where(x => x.TenderId == id);

            if (offerDetails == null)
            {
                return NotFound();
            }

            return offerDetails.ToList();
        }

        // PUT: api/Offer/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfferDetails(int id, OfferDetails offerDetails)
        {
            if (id != offerDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(offerDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferDetailsExists(id))
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

        // POST: api/Offer
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OfferDetails>> PostOfferDetails(OfferDetails offerDetails)
        {
            _context.OfferDetails.Add(offerDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfferDetails", new { id = offerDetails.Id }, offerDetails);
        }

        // DELETE: api/Offer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OfferDetails>> DeleteOfferDetails(int id)
        {
            var offerDetails = await _context.OfferDetails.FindAsync(id);
            if (offerDetails == null)
            {
                return NotFound();
            }

            _context.OfferDetails.Remove(offerDetails);
            await _context.SaveChangesAsync();

            return offerDetails;
        }

        private bool OfferDetailsExists(int id)
        {
            return _context.OfferDetails.Any(e => e.Id == id);
        }
    }
}

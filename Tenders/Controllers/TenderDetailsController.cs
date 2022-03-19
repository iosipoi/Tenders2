using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tenders.Data;
using Tenders.Models;

namespace Tenders.Controllers
{
    public class TenderDetailsController : Controller
    {
        private readonly TendersContext _context;

        public TenderDetailsController(TendersContext context)
        {
            _context = context;
        }

        // GET: TenderDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.TenderDetails.ToListAsync());
        }

        // GET: TenderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenderDetails = await _context.TenderDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tenderDetails == null)
            {
                return NotFound();
            }

            return View(tenderDetails);
        }

        // GET: TenderDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TenderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,StartPrice,FinalPrice,CreatedOn,CreatedBy,CPVCode,Status")] TenderDetails tenderDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tenderDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tenderDetails);
        }

        // GET: TenderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenderDetails = await _context.TenderDetails.FindAsync(id);
            if (tenderDetails == null)
            {
                return NotFound();
            }
            return View(tenderDetails);
        }

        // POST: TenderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,StartPrice,FinalPrice,CreatedOn,CreatedBy,CPVCode,Status")] TenderDetails tenderDetails)
        {
            if (id != tenderDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenderDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenderDetailsExists(tenderDetails.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tenderDetails);
        }

        // GET: TenderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenderDetails = await _context.TenderDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tenderDetails == null)
            {
                return NotFound();
            }

            return View(tenderDetails);
        }

        // POST: TenderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tenderDetails = await _context.TenderDetails.FindAsync(id);
            _context.TenderDetails.Remove(tenderDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TenderDetailsExists(int id)
        {
            return _context.TenderDetails.Any(e => e.Id == id);
        }
    }
}

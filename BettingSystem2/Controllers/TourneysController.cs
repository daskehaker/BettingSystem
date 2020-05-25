using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BettingSystem2.Data;
using BettingSystem2.Models;

namespace BettingSystem2.Controllers
{
    public class TourneysController : Controller
    {
        private readonly SystemContext _context;

        public TourneysController(SystemContext context)
        {
            _context = context;
        }

        // GET: Tourneys
        public async Task<IActionResult> Index()
        {
            var systemContext = _context.Tourneys.Include(t => t.Category);
            return View(await systemContext.ToListAsync());
        }

        // GET: Tourneys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourney = await _context.Tourneys
                .Include(t => t.Category).Include(t => t.Teams).AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (tourney == null)
            {
                return NotFound();
            }

            return View(tourney);
        }

        // GET: Tourneys/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "ID");
            return View();
        }

        // POST: Tourneys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryID,Title")] Tourney tourney)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tourney);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "ID", tourney.CategoryID);
            return View(tourney);
        }

        // GET: Tourneys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourney = await _context.Tourneys.FindAsync(id);
            if (tourney == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "ID", tourney.CategoryID);
            return View(tourney);
        }

        // POST: Tourneys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CategoryID,Title")] Tourney tourney)
        {
            if (id != tourney.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tourney);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourneyExists(tourney.ID))
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
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "ID", tourney.CategoryID);
            return View(tourney);
        }

        // GET: Tourneys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourney = await _context.Tourneys
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tourney == null)
            {
                return NotFound();
            }

            return View(tourney);
        }

        // POST: Tourneys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tourney = await _context.Tourneys.FindAsync(id);
            _context.Tourneys.Remove(tourney);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TourneyExists(int id)
        {
            return _context.Tourneys.Any(e => e.ID == id);
        }
    }
}

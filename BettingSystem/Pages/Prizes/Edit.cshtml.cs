using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BettingSystem.Data;
using BettingSystem.Models;

namespace BettingSystem
{
    public class EditModel : PageModel
    {
        private readonly BettingSystem.Data.BettingSystemContext _context;

        public EditModel(BettingSystem.Data.BettingSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Prize Prize { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prize = await _context.Prize.FirstOrDefaultAsync(m => m.ID == id);

            if (Prize == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Prize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrizeExists(Prize.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PrizeExists(int id)
        {
            return _context.Prize.Any(e => e.ID == id);
        }
    }
}

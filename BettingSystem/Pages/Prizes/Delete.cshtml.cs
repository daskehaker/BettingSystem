using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BettingSystem.Data;
using BettingSystem.Models;

namespace BettingSystem
{
    public class DeleteModel : PageModel
    {
        private readonly BettingSystem.Data.BettingSystemContext _context;

        public DeleteModel(BettingSystem.Data.BettingSystemContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prize = await _context.Prize.FindAsync(id);

            if (Prize != null)
            {
                _context.Prize.Remove(Prize);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

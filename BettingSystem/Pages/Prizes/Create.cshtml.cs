using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BettingSystem.Data;
using BettingSystem.Models;

namespace BettingSystem
{
    public class CreateModel : PageModel
    {
        private readonly BettingSystem.Data.BettingSystemContext _context;

        public CreateModel(BettingSystem.Data.BettingSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Prize Prize { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Prize.Add(Prize);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

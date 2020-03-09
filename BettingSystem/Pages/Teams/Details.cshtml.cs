using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BettingSystem.Data;
using BettingSystem.Models;

namespace BettingSystem.Pages.Teams
{
    public class DetailsModel : PageModel
    {
        private readonly BettingSystem.Data.BettingSystemContext _context;

        public DetailsModel(BettingSystem.Data.BettingSystemContext context)
        {
            _context = context;
        }

        public Team Team { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team = await _context.Team.FirstOrDefaultAsync(m => m.ID == id);

            if (Team == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

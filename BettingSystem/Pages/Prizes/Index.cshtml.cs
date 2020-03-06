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
    public class IndexModel : PageModel
    {
        private readonly BettingSystem.Data.BettingSystemContext _context;

        public IndexModel(BettingSystem.Data.BettingSystemContext context)
        {
            _context = context;
        }

        public IList<Prize> Prize { get;set; }

        public async Task OnGetAsync()
        {
            Prize = await _context.Prize.ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettingSystem2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BettingSystem2.Models;

namespace BettingSystem2.Controllers
{
    public class PrizeController : Controller
    {
        private readonly SystemContext _context;

        public PrizeController(SystemContext context)
        {
            _context = context;
        }

        // GET: Prizes
        public async Task<IActionResult> Index()
        {
            var systemContext = _context.Prizes;
            return View(await systemContext.ToListAsync());
        }
    }
}
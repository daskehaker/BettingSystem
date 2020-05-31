using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettingSystem2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BettingSystem2.Models;
using Microsoft.AspNetCore.Identity;

namespace BettingSystem2.Controllers
{
    public class PrizeController : Controller
    {
        private readonly SystemContext _context;
        private UserManager<IdentityUser> _userManager { get; set; }

        public PrizeController(SystemContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Prizes
        public async Task<IActionResult> Index(bool? err)
        {
            var userId = _userManager.GetUserId(User);
            var points = _context.UserInfos.Where(u => u.ID == userId).FirstOrDefault().Points;

            ViewData["Test"] = false;
            if (err != null) ViewData["Test"] = true;

            ViewData["Points"] = points;
            var systemContext = _context.Prizes;
            return View(await systemContext.ToListAsync());
        }

        public IActionResult PointsIndex()
        {
            var userId = _userManager.GetUserId(User);
            var userInfo = _context.UserInfos.Where(u => u.ID == userId).FirstOrDefault();

            return View(userInfo);
        }
    }
}
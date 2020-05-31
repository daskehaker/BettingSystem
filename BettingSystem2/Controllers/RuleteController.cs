using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettingSystem2.Data;
using BettingSystem2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BettingSystem2.Controllers
{
    public class RuleteController : Controller
    {
        private readonly SystemContext _context;
        private UserManager<IdentityUser> _userManager { get; set; }

        public RuleteController(SystemContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Fake(PlayedGame game)
        {
            var userId = _userManager.GetUserId(User);
            var userInfo = _context.UserInfos.Where(u => u.ID == userId).FirstOrDefault();
            userInfo.Points = userInfo.Points + game.Points;
            _context.Update(userInfo);
            _context.SaveChanges();
            return RedirectToAction("Index", "Rulete");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettingSystem2.Data;
using BettingSystem2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BettingSystem2.Controllers
{
    public class BlackjackController : Controller
    {
        private readonly SystemContext _context;
        private UserManager<IdentityUser> _userManager { get; set; }

        public BlackjackController(SystemContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: /<controller>/
        public IActionResult Index(bool? err)
        {

            ViewData["err"] = false;
            if (err != null) ViewData["err"] = true;
            return View();
        }
        public IActionResult Index2(PlayedGame game)
        {
            var userId = _userManager.GetUserId(User);
            var userPoints = _context.UserInfos.Where(u => u.ID == userId).FirstOrDefault().Points;
            if (userPoints < game.Points || game.Points <= 0) return RedirectToAction("Index", "Blackjack", new { err = true });
            ViewData["Taskai"] = game.Points;
            return View(game);
        }
        public IActionResult CheckSum(PlayedGame game)
        {
            var userId = _userManager.GetUserId(User);
            var userInfo = _context.UserInfos.Where(u => u.ID == userId).FirstOrDefault();
            userInfo.Points = userInfo.Points + game.Points;
            _context.Update(userInfo);
            _context.SaveChanges();
            return RedirectToAction("Index2", "Blackjack");
            //return View(game);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettingSystem2.Data;
using BettingSystem2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using iTextSharp.tool.xml.html;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace BettingSystem2.Controllers
{
    public class SentFormController : Controller
    {
        private readonly SystemContext _context;
        private UserManager<IdentityUser> _userManager { get; set; }

        public SentFormController(SystemContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SentFormView(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //string UserId = _userManager.GetUserId(User);
            var prize = _context.Prizes.Where(p => p.ID == id).Single();
            var userId = _userManager.GetUserId(User);
            var userPoints = _context.UserInfos.Where(u => u.ID == userId).FirstOrDefault().Points;
            
            if(prize.Price > userPoints) //Jei neužtenka taškų numeta atgal
            {
                return RedirectToAction("Index", "Prize", new { err = true });
            }
            var sentform = new SentForm
            {
                PrizePrice = prize.Price,
                Prize = prize,
                UserId = userId,
                UserPoinst = userPoints
            };
            return View(sentform);
        }

        [HttpPost]
        public IActionResult OrderPrize(SentForm sentForm)
        {
            _context.Add(sentForm);

            UserInfo userInfo = _context.UserInfos.Where(u => u.ID == sentForm.UserId).SingleOrDefault();
            userInfo.Points = userInfo.Points - sentForm.PrizePrice;
            _context.Update(userInfo);

            Prize prize = _context.Prizes.Where(p => p.Price == sentForm.PrizePrice).SingleOrDefault();
            //if (prize.State != State.Unordered) return RedirectToAction("Index", "Prize");
            prize.State = State.Odered;
            _context.Update(prize);

            _context.SaveChanges();
            string str = "Jūsų prizas " + prize.Name + " sekmingai užsakytas";
            

            //siusti emaila
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Lažybų sistema", "blagadariu.kajus@gmail.com"));
            message.To.Add(new MailboxAddress(sentForm.Name.ToString(), sentForm.Email.ToString()));
            message.Subject = "Prizo užsakymas";
            message.Body = new TextPart("plain")
            {
                Text = str
            };
            using(var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("blagadariu.kajus@gmail.com", "");
                client.Send(message);
                client.Disconnect(true);
            }

            return RedirectToAction("Index", "Prize");
        }
    }
}
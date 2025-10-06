using System.Threading.Tasks;
using ClosedXML;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Traversal_Rezervasyon.Models;

namespace Traversal_Rezervasyon.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> ForgetPassword(ForgetPasswordModel p)
        {
           if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(p.Mail);

                string PasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                var PasswordResetToken = Url.Action("ResetPassword", "PasswordChange", new
                {
                    userId = user.Id,
                    Token = PasswordToken

                }, HttpContext.Request.Scheme);

                MimeMessage mimeMessage = new MimeMessage();

                MailboxAddress Gönderen = new MailboxAddress("Admin", "emrekarabey229@gmial.com");

                mimeMessage.From.Add(Gönderen);

                MailboxAddress Alıcı = new MailboxAddress("Üye", p.Mail);

                mimeMessage.To.Add(Alıcı);

                var messagebody = new BodyBuilder();

                messagebody.TextBody = PasswordResetToken;

                mimeMessage.Body = messagebody.ToMessageBody();

                mimeMessage.Subject = "Şifre Sıfırlama";

                SmtpClient smtpClient = new SmtpClient();

                smtpClient.Connect("smtp.gmail.com", 465, true);

                smtpClient.Authenticate("emrekarabey229@gmail.com", "kcioerukhqitzimt");

                smtpClient.Send(mimeMessage);

                smtpClient.Disconnect(true);

                return View();
            }

            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string userid,string token)
        {
            TempData["userid"] = userid;

            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel p)
        {
            if (ModelState.IsValid)
            {
                var userid = TempData["userid"];
                var token = TempData["token"];

                if (userid == null || token == null)
                {
                    return NoContent();
                }
                var user = await _userManager.FindByIdAsync(userid.ToString());

                var results = await _userManager.ResetPasswordAsync(user, token.ToString(), p.NewPassword);

                if (results.Succeeded)
                {
                    RedirectToAction("Index", "SignIn");
                }
            }
           
            return View();
        }
    }
}

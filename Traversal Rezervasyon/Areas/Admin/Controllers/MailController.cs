using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Traversal_Rezervasyon.Areas.Admin.Models;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailReceiveModel p)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress sender = new MailboxAddress("Admin","emrekarabey229@gmail.com");

            mimeMessage.From.Add(sender);

            MailboxAddress receiver = new MailboxAddress("User",p.ReceieverEmail);

            mimeMessage.To.Add(receiver);

            var bodybuilder = new BodyBuilder();

            bodybuilder.TextBody = p.MessageBody;

            mimeMessage.Body = bodybuilder.ToMessageBody();

            mimeMessage.Subject = p.Subject;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Connect("smtp.gmail.com",465,true);

            smtpClient.Authenticate("emrekarabey229@gmail.com", "kcioerukhqitzimt");

            smtpClient.Send(mimeMessage);

            smtpClient.Disconnect(true);
           
                TempData["MailGönderildi"] = true;



            return View();/*RedirectToAction("Index","Comment", new {area="Admin"});*/
        }
    }
}

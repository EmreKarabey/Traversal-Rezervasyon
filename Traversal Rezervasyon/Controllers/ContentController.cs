using BusinessLayer.Abstract;
using DTOs.ContentDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;

namespace Traversal_Rezervasyon.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentUsServices _contentUsServices;

        public ContentController(IContentUsServices contentUsServices)
        {
            _contentUsServices = contentUsServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SendContentDTOs sendContent)
        {
            if (ModelState.IsValid)
            {
                ContentUs contentUs = new ContentUs();

                contentUs.Subject = sendContent.Subject;

                contentUs.Mail = sendContent.Mail;

                contentUs.MessageDetails = sendContent.MessageDetail;

                contentUs.MessageDate = DateTime.Now;

                contentUs.Name = sendContent.Name;

                contentUs.Status = true;

                _contentUsServices.Add(contentUs);

                return RedirectToAction("Index");
            }
            return View();
           
        }
    }
}

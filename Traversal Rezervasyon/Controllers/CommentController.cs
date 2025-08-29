using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EFComment());
        [HttpGet]
        public PartialViewResult Index()
        {
        
            return PartialView();
        }

        [HttpPost]
        public IActionResult Index(Comment comment)
        {
            comment.CommentDate = DateTime.Now;

            comment.CommentStatus = true;


            commentManager.Add(comment);

            return RedirectToAction("Index", "Destination");
        }
    }
}

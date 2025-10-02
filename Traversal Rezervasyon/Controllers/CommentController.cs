using System.Security.Claims;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EFComment());

        private readonly UserManager<AppUser> _usermanager;
        private readonly ICommentServices _commentServices;

        public CommentController(UserManager<AppUser> userManager,ICommentServices commentServices)
        {
            _usermanager = userManager;
            _commentServices = commentServices;
        }
 
        
        [HttpGet]
        public async Task< PartialViewResult> Index(int id)
        {

            

            return PartialView();
        }

        [HttpPost]
        public async Task< IActionResult> Index(Comment comment)
        {

            comment.CommentDate = DateTime.Now;

            comment.CommentStatus = true;

            

            _commentServices.Add(comment);
            return RedirectToAction();
        } 

    
    }
}

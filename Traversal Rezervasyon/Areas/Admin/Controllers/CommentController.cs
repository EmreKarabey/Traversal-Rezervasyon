using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        ICommentServices _commentServices;

        public CommentController(ICommentServices commentServices)
        {
            _commentServices = commentServices;
        }
        public IActionResult Index()
        {
            var gstr = _commentServices.IncludeCommentList();
            return View(gstr);
        }

        public IActionResult CommentDelete(int id)
        {
            var gstr = _commentServices.GetById(id);

            _commentServices.Delete(gstr);

            return RedirectToAction("Index","Comment",new {area="Admin"});


        }
    }
}

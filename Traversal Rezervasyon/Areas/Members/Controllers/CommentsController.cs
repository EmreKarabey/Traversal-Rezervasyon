using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Members.Controllers
{
    [Area("Members")]
    [AllowAnonymous]
    public class CommentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

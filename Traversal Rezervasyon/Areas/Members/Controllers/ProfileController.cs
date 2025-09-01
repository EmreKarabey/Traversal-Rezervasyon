using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Members.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

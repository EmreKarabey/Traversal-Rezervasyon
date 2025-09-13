using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class _404PagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

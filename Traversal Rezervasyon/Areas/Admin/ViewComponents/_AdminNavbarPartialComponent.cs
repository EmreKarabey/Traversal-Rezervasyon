using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Admin.ViewComponents
{
    public class _AdminNavbarPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

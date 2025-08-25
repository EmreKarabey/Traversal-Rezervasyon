using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.ViewComponents.Default
{
    public class _StaticsComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var c = new Context();

            ViewBag.v1 = c.Set<Destination>().Count();

            ViewBag.v2 = c.Set<Guide>().Count();

            ViewBag.v3 = "285";
            return View();
        }
    }
}

using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace Traversal_Rezervasyon.ViewComponents.Default
{
    public class _FeatureComponent:ViewComponent
    {
      
        public IViewComponentResult Invoke()
        {
            using var c = new Context();

            ViewBag.Title = c.Set<Feature1>().Where(N => N.BigImage == true).Select(n=>n.Post1Name).FirstOrDefault();
            ViewBag.Description = c.Set<Feature1>().Where(N => N.BigImage == true).Select(n=>n.Post1Description).FirstOrDefault();
            ViewBag.Image = c.Set<Feature1>().Where(N => N.BigImage == true).Select(n=>n.Post1Image).FirstOrDefault();

            var gstr = c.Set<Feature1>().Where(n => n.BigImage == false).Take(4).ToList();
            return View(gstr);
        }
    }
}

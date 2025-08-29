using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.ViewComponents.Default
{
    public class _CommentListComponent:ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EFComment());
        public IViewComponentResult Invoke(int id)
        {
            var gstr = commentManager.FiltreComments(id);

            ViewBag.MesajSayısı = gstr.Count();
            return View(gstr);
        }
    }
}

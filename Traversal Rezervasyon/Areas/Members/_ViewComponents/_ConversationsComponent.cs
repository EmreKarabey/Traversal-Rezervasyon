using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Members._ViewComponents
{
    public class _ConversationsComponent:ViewComponent
    {
        GuideManager guideManager = new GuideManager(new EFGuide());
        public IViewComponentResult Invoke()
        {
            var gstr = guideManager.list();
            return View(gstr);
        }
    }
}

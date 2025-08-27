using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.ViewComponents.Default
{
    public class _SubAboutComponent : ViewComponent
    {
        SubAboutManager subAboutManager = new SubAboutManager(new EFSubAbout());
        public IViewComponentResult Invoke()
        {
            var gstr = subAboutManager.list();
            return View(gstr);
        }
    }
}

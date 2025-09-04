using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Members._ViewComponents
{
    public class _SelectDestinationComponent:ViewComponent
    {
        DestinationManager destinationManager = new DestinationManager(new EFDestination());
        public IViewComponentResult Invoke()
        {
            var gstr = destinationManager.list();
            return View(gstr);
        }
    }
}

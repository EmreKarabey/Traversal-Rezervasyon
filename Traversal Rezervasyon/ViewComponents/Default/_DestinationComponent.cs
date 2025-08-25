using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.ViewComponents.Default
{
    public class _DestinationComponent:ViewComponent
    {
        DestinationManager destinationManager = new DestinationManager(new EFDestination());
        public IViewComponentResult Invoke()
        {
            var gstr = destinationManager.list();

            return View(gstr);
        }
    }
}

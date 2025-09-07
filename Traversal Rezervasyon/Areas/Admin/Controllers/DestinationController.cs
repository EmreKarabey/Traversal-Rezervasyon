using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {

        DestinationManager destinationManager = new DestinationManager(new EFDestination());

        public IActionResult Index()
        {
            var gstr = destinationManager.list();
            return View(gstr);
        }
    }
}

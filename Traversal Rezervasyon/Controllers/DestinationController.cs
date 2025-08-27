using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EFDestination());
        public IActionResult Index()
        {
            var gstr = destinationManager.list();
            return View(gstr);
        }

        [HttpGet]
        public IActionResult DestinationDetail(int id)
        {
            var gstr = destinationManager.GetById(id);
            return View();
        }

        [HttpPost]
        public IActionResult DestinationDetail(Destination p)
        {
            return View();
        }
    }
}

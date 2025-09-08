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

        public IActionResult DeleteDestination(int id)
        {
            var gstr = destinationManager.GetById(id);

            destinationManager.Delete(gstr);

            return RedirectToAction("Index","Destination",new {area="Admin"});
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var gstr = destinationManager.GetById(id);

            return View(gstr);
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            
            destinationManager.Update(destination);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            var gstr = destinationManager.GetById(id);

            return View(gstr);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
        
                
            destination.Status = false;
            destinationManager.Add(destination);
            return RedirectToAction("Index");
        }

    }
}

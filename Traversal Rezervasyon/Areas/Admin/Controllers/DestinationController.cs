using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        IDestinationServices _destinationServices;
        public DestinationController(IDestinationServices destinationServices)
        {
            _destinationServices = destinationServices;
        }

        public IActionResult Index()
        {
            var gstr = _destinationServices.list();
            return View(gstr);
        }

        public IActionResult DeleteDestination(int id)
        {
            var gstr = _destinationServices.GetById(id);

            _destinationServices.Delete(gstr);

            return RedirectToAction("Index","Destination",new {area="Admin"});
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var gstr = _destinationServices.GetById(id);

            return View(gstr);
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            
            _destinationServices.Update(destination);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            var gstr = _destinationServices.GetById(id);

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
            _destinationServices.Add(destination);
            return RedirectToAction("Index");
        }

    }
}

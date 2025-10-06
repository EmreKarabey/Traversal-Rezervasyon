using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Members.Controllers
{
    [Area("Members")]
    public class LastDestinationController : Controller
    {
        private readonly IDestinationServices _destinationServices;

        public LastDestinationController(IDestinationServices destinationServices)
        {
            _destinationServices = destinationServices;
        }
        public IActionResult Index()
        {
            var gstr = _destinationServices.list();
            return View(gstr);
        }
    }
}

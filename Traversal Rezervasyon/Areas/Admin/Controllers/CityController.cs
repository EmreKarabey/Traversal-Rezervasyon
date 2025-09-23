using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Wordprocessing;
using EntityLayer.Concrete;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal_Rezervasyon.Areas.Admin.Models;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationServices _ıdestinationservices;

        public CityController(IDestinationServices destinationServices)
        {
            _ıdestinationservices = destinationServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var json = _ıdestinationservices.list();
            return Json(json);
        }

        [HttpPost]
        public IActionResult AddDestination(EntityLayer.Concrete.Destination destination)
        {
            destination.Status = true;
            _ıdestinationservices.Add(destination);

            return Json(destination);
        }

        public IActionResult GetByCityId(int id)
        {
            var values = _ıdestinationservices.GetById(id);

            return Json(values);

        }


    }
}

using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Wordprocessing;
using EntityLayer.Concrete;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal_Rezervasyon.Areas.Admin.Models;
using Destination = EntityLayer.Concrete.Destination;

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

        [HttpGet]
        public IActionResult GetByCityId(int DestinationId)
        {
            var values = _ıdestinationservices.GetById(DestinationId);
            if (values == null)
            {

            }
            else
            {
                return Json(values);
            }

            return View();

        }

        public IActionResult DeleteCity(int id)
        {
          var values =  _ıdestinationservices.GetById(id);

            _ıdestinationservices.Delete(values);

            return NoContent();
        }
        [HttpPost]
        public IActionResult UpdateCity(Destination destinations)
        {
            var gstr = _ıdestinationservices.GetById(destinations.DestinationID);

            destinations.DestinationID = gstr.DestinationID;
    
            destinations.Quotation = gstr.Quotation;
            destinations.Reservations = gstr.Reservations;
            destinations.Comments = gstr.Comments;
            destinations.Status = gstr.Status;
            destinations.CoverImage = gstr.CoverImage;
            destinations.Image = gstr.Image;
            destinations.Image2 = gstr.Image2;
            destinations.Details1 = gstr.Details1;
            destinations.Details2 = gstr.Details2;
            destinations.Details3 = gstr.Details3;
            destinations.Title1 = gstr.Title1;
            destinations.Title2 = gstr.Title2;
            destinations.MainTitle = gstr.MainTitle;



            _ıdestinationservices.Update(destinations);

            return Json(destinations);
        }


    }
}

using BusinessLayer.Abstract;
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
            var json = JsonConvert.SerializeObject(_ıdestinationservices.list());
            return Json(json);
        }

        public List<CityModel> cityModels()
        {
            List<CityModel> cityModels = new List<CityModel>()
            {
                new CityModel()
                {
                    CityId = 1,

                    CityName = "Ankara",

                    CountryName = "Türkiye"
                },

                new CityModel()
                {
                    CityId  = 2,

                    CityName = "Paris",

                    CountryName = "Fransa"
                },

                new CityModel()
                {
                    CityId = 3,
                    CityName = "Moskova",
                    CountryName="Rusya"
                },

                new CityModel()
                {
                    CityId = 4,

                    CityName = "Manchester",

                    CountryName = "İngiltere"
                }
            };

            return cityModels;
        }
    }
}

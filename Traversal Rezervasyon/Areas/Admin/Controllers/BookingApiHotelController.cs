using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Utilities.IO;
using Traversal_Rezervasyon.Areas.Admin.Models;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class BookingApiHotelController : Controller
    {
        public async Task< IActionResult> Index()
        {
           
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?adults_number=2&children_number=2&units=metric&page_number=0&checkin_date=2026-01-31&checkout_date=2026-02-01&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_ages=5%2C0&dest_type=city&dest_id=-1746443&order_by=popularity&include_adjacency=true&room_number=1&filter_by_currency=AED&locale=en-gb"),
                Headers =
    {
        { "x-rapidapi-key", "704e7baf3emshed638e2d5865a90p1bec87jsnd3e7bd02670d" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var bodyreplace = body.Replace(".","");
                var JsonFile = JsonConvert.DeserializeObject<BookingApiHotelModel>(bodyreplace);
               
                return View(JsonFile.result);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetById(string p)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=Berlin&locale=en-gb"),
                Headers =
    {
        { "x-rapidapi-key", "704e7baf3emshed638e2d5865a90p1bec87jsnd3e7bd02670d" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                
                return View();
            }
        }
    }
}

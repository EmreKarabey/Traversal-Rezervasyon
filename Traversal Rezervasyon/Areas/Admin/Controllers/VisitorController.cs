using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Packaging.Signing;
using Traversal_Rezervasyon.Areas.Admin.Models;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class VisitorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("http://localhost:5126/api/Visitor");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<VisitorModel>>(jsondata);

                return View(values);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddVisitor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVisitor(VisitorModel p)
        {
            var httpclient = _httpClientFactory.CreateClient();

            var JsonData = JsonConvert.SerializeObject(p);

            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");

            var responsemessage = await httpclient.PostAsync("http://localhost:5126/api/Visitor", stringContent);

            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var httpclient = _httpClientFactory.CreateClient();

            var responsemessage = await httpclient.DeleteAsync($"http://localhost:5126/api/Visitor/{id}");

            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetIdUpdate(int id)
        {
            var httpclient = _httpClientFactory.CreateClient();

            var responseMessage = await httpclient.GetAsync($"http://localhost:5126/api/Visitor/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<VisitorModel>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetIdUpdate(VisitorModel p)
        {
            var httpclient = _httpClientFactory.CreateClient();

            var JsonData = JsonConvert.SerializeObject(p);

            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");

            var responsemessage = await httpclient.PutAsync($"http://localhost:5126/api/Visitor", stringContent);

            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

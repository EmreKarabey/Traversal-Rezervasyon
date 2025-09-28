using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Traversal_Rezervasyon.Areas.Admin.Models;
namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ApiMovieController : Controller
    {
       
        public async Task<IActionResult> Index()
        {
            List<ApiMovieModel> apiMovieModels = new List<ApiMovieModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb236.p.rapidapi.com/api/imdb/cast/nm0000190/titles"),
                Headers =
    {
        { "x-rapidapi-key", "704e7baf3emshed638e2d5865a90p1bec87jsnd3e7bd02670d" },
        { "x-rapidapi-host", "imdb236.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

              var gstr = JsonConvert.DeserializeObject<List<ApiMovieModel>>(body);

                apiMovieModels = gstr.ToList();
             
                return View(apiMovieModels);
            }
           
        }
    }
}

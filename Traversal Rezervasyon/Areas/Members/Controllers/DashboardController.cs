using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Members.Controllers
{
    [Area("Members")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task< IActionResult> Index()
        {
            var Profile = await _userManager.GetUserAsync(User);

            ViewBag.VName = Profile.Name + " " + Profile.Surname;

            ViewBag.BackgroundImage = Profile.BackgroundImageURL;
            

            ViewBag.ImageURL = Profile.ImageURL;
            return View();
        }

        public async Task<IActionResult> Dashboard()
        {
            return View();
        }
    }
}

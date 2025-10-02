using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EFDestination());

        private readonly UserManager<AppUser> _userManager;


        public DestinationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var gstr = destinationManager.list();
            return View(gstr);
        }

        [HttpGet]
        public async Task< IActionResult> DestinationDetail(int id)
        {
            var guide = destinationManager.IncludeDestination(id);

            ViewBag.VGuideName = guide.Guide.Name;

            ViewBag.Image = guide.Guide.ImageURL;

            var nznz = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.UserId = nznz.Id;

            ViewBag.Name = nznz.Name + " " + nznz.Surname;

            ViewBag.Id = id;

            ViewBag.VDetails = destinationManager.SubstringDescription(id);
            ViewBag.V = destinationManager.SplitWord(id);
            var gstr = destinationManager.GetById(id);

            ViewBag.VGuideId = gstr.GuideID;
            ViewBag.vId = id;

            ViewBag.DateTime = gstr.Date.ToShortDateString();
            return View(gstr);
        }

       
    }
}

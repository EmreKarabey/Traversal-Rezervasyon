using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Traversal_Rezervasyon.Areas.Members.Models;
using Traversal_Rezervasyon.Models;

namespace Traversal_Rezervasyon.Areas.Members.Controllers
{
    [Area("Members")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var gstr = await _userManager.GetUserAsync(User);

            UserProfileEditModel userProfileEditModel = new UserProfileEditModel()
            {
                Name = gstr.Name,

                Surname = gstr.Surname,

                Mail = gstr.Email,

                Phone = gstr.PhoneNumber,

                ImageURL = gstr.ImageURL,

                Gender = gstr.Gender,

                UserName = gstr.UserName
            };

            return View(userProfileEditModel);
        }


        [HttpPost]
        public async Task<IActionResult> Index(UserProfileEditModel p)
        {
            var gstr = await _userManager.GetUserAsync(User);

            if (p.ImageURL != null)
            {
                var resource = Directory.GetCurrentDirectory();

                var extension = Path.GetExtension(p.Image.FileName);

                var imagename = Guid.NewGuid() + extension;

                var savelocation = resource + "/wwwroot/userimage/" + imagename;

                var stream = new FileStream(savelocation, FileMode.Create);

                await p.Image.CopyToAsync(stream);

                gstr.ImageURL = imagename;
            }

            gstr.Name = p.Name;

            gstr.UserName = p.UserName;

            gstr.Surname = p.Surname;

            gstr.Email = p.Mail;

            gstr.Gender = p.Gender;

            gstr.Id = p.Id;

            gstr.PhoneNumber = p.Phone;

            var results = await _userManager.UpdateAsync(gstr);

            if (results.Succeeded)
            {
                return RedirectToAction();
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(p);
        }
    }
}

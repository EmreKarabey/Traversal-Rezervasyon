using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.Models;

namespace Traversal_Rezervasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _UserManager;

        public LoginController(UserManager<AppUser> userManager)
        {
            _UserManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {



            AppUser appUser = new AppUser()
            {
                Name = p.Name,

                Surname = p.Surname,

                Email = p.Mail,

                Gender = p.Gender,

                UserName = p.UserName,

            };

            var resource = Directory.GetCurrentDirectory();

            var extension = Path.GetExtension(p.Image.FileName);

            var imagename = Guid.NewGuid() + extension;

            var savelocation = resource + "/wwwroot/userimage/" + imagename;

            var stream = new FileStream(savelocation, FileMode.Create);

            await p.Image.CopyToAsync(stream);
            appUser.ImageURL = imagename;





            if (p.Password == p.ComparePassword)
            {
                var results = await _UserManager.CreateAsync(appUser, p.Password);

                if (results.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(appUser);
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
    }
}

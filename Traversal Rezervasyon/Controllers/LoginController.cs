using BusinessLayer.ValidationRule;
using DTOs.AppUserDTOs;
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
        public async Task<IActionResult> SignUp(UserRegisterModel p)
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


            var resource2 = Directory.GetCurrentDirectory();

            var extension2 = Path.GetExtension(p.BackgroundImage.FileName);

            var imagename2 = Guid.NewGuid()+extension2;

            var savelocation2 = resource2 + "/wwwroot/backgroundimage/" + imagename2;

            var stream2 = new FileStream(savelocation2,FileMode.Create);

            await p.BackgroundImage.CopyToAsync(stream2);

            p.BackgroundImageURL = imagename2;


            if (p.Password == p.ComparePassword)
            {
                var results = await _UserManager.CreateAsync(appUser, p.Password);

                if (results.Succeeded)
                {
                    return RedirectToAction("Index","SignIN");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(p);
        }


       
    }
}

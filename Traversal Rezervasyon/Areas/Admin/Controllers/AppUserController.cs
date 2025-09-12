using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Traversal_Rezervasyon.Areas.Admin.Models;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppUserController : Controller
    {
        IAppUserServices _appuserservices;

        private readonly UserManager<AppUser> _usermanager;



        public AppUserController(IAppUserServices appUser,UserManager<AppUser> usermanager)
        {
            _appuserservices = appUser;

            _usermanager = usermanager;
        }
        public IActionResult Index()
        {
            var gstr = _appuserservices.list();
            return View(gstr);
        }

        [HttpGet]
        public IActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> UserAdd(GuestUserAdd p)
        {
            AppUser w = new AppUser()
            {
                Name = p.Name,

                Surname = p.Surname,

                PhoneNumber = p.PhoneNumber,

                UserName = p.UserName,

                Gender = p.Gender,

                Email = p.Email,
                ImageURL = null,
                BackgroundImageURL = null,


            };

            if(p.Password == p.ConfirmPasword)
            {
                var resource = await _usermanager.CreateAsync(w,p.Password);

                if (resource.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach(var item in resource.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();  
        }
    }
}

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



        public AppUserController(IAppUserServices appUser, UserManager<AppUser> usermanager)
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
        public async Task<IActionResult> UserAdd(GuestUserAdd p)
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

            if (p.Password == p.ConfirmPasword)
            {
                var resource = await _usermanager.CreateAsync(w, p.Password);

                if (resource.Succeeded)
                {
                    TempData["SuccessAdd"] = true;
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in resource.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var gstr = await _usermanager.FindByIdAsync(id.ToString());

            GuestUserUpdate guestUserUpdate = new GuestUserUpdate()
            {
                id = gstr.Id,
                Name = gstr.Name,

                Surname = gstr.Surname,

                Email = gstr.Email,

                Gender = gstr.Gender,

                UserName = gstr.Surname
            };

            return View(guestUserUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(GuestUserUpdate p)
        {
            if (ModelState.IsValid)
            {
                var gstr = await _usermanager.FindByIdAsync(p.id.ToString());

                gstr.Name = p.Name;

                gstr.Id = p.id;

                gstr.Surname = p.Surname;

                gstr.Email = p.Email;

                gstr.Gender = p.Gender;

                gstr.PhoneNumber = p.PhoneNumber;

                gstr.UserName = p.UserName;

                gstr.ImageURL = null;

                gstr.BackgroundImageURL = null;

                if (p.Password == p.ConfirmPasword)
                {
                    var token = await _usermanager.GeneratePasswordResetTokenAsync(gstr);

                    var newPassword = _usermanager.ResetPasswordAsync(gstr, token, p.Password);

                    var results = await _usermanager.UpdateAsync(gstr);

                    if (results.Succeeded)
                    {
                        return RedirectToAction("Index", "AppUser");
                    }
                    else
                    {
                        foreach (var item in results.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }


            return View(p);
        }


        public async Task<IActionResult> UserDelete(int id)
        {
            var gstr = await _usermanager.FindByIdAsync(id.ToString());

            _appuserservices.Delete(gstr);

            return RedirectToAction("Index");
        }



    }
}

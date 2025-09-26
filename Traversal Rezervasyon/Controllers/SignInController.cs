using DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.Models;


namespace Traversal_Rezervasyon.Controllers
{
    [AllowAnonymous]
    public class SignInController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public SignInController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task< IActionResult> Index()
        {
            return View();
        }


        [HttpPost]
        public async Task< IActionResult> Index(UserLoginModel p)
        {
            if (ModelState.IsValid)
            {
                var results = await _signInManager.PasswordSignInAsync(p.UserName,p.Password,true,true);

                if (results.Succeeded)
                {
                    return RedirectToAction("Index","Destination");
                }
                else
                {
                    return RedirectToAction("Index","SignIn");
                }
            }
            return View(p);
        }
    }
}

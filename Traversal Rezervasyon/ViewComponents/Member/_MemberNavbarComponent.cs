using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Extensions;

namespace Traversal_Rezervasyon.ViewComponents.Member
{
    public class _MemberNavbarComponent:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        public _MemberNavbarComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task< IViewComponentResult> InvokeAsync()
        {
            var gstr = await _userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User);


            ViewBag.VName = gstr.Name+" "+gstr.Surname;

            ViewBag.ImageURL = gstr.ImageURL;


            return View();
        }
    }
}

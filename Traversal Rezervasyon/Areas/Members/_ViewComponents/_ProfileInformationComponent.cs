using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Members._ViewComponents
{
    public class _ProfileInformationComponent:ViewComponent
    {
        private readonly UserManager<AppUser> _usermanager;

        public _ProfileInformationComponent(UserManager<AppUser> userManager)
        {
            _usermanager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var gstr = await _usermanager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User);

            ViewBag.Phone = gstr.PhoneNumber;

            ViewBag.Mail = gstr.Email;


            return View();
        }
    }
}

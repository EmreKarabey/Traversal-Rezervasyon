using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.ViewComponents.Default
{
    public class _PartialNavbarComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _usermanager;

        public _PartialNavbarComponent(UserManager<AppUser> userManager)
        {
            _usermanager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
          
            var gstr = await _usermanager.GetUserAsync(HttpContext.User);

            ViewBag.UserName = gstr.Name;
            return View();
        }
    }
}

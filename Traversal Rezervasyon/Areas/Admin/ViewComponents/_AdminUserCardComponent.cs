using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Admin.ViewComponents
{
    public class _AdminUserCardComponent:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _AdminUserCardComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.VUserName = user.Name;
            return View();
        }
    }
}

using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Admin.ViewComponents
{
    public class _AdminStaticsComponent:ViewComponent
    {
        Context context = new Context();

        private readonly UserManager<AppUser> _userManager;

        public _AdminStaticsComponent (UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {
            
            ViewBag.V1 = context.Destinations.Count();

            ViewBag.V2 = _userManager.Users.Count();
            return View();
        }
    }
}

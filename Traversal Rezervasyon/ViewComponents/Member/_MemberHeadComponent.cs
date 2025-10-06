using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.ViewComponents.Member
{
    public class _MemberHeadComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

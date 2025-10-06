using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.ViewComponents.Member
{
    public class _MemberFooterComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

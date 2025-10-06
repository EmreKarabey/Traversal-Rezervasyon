using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Members._ViewComponents
{
    public class _RecentBuyersComponent:ViewComponent
    {
        private readonly IGuideServices _guideServices;
        public _RecentBuyersComponent(IGuideServices guideServices)
        {
            _guideServices = guideServices;
        }
        public IViewComponentResult Invoke()
        {
            var gstr = _guideServices.list();
            return View(gstr);
        }
    }
}

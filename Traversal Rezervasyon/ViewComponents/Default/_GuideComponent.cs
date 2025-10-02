using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.ViewComponents.Default
{
    public class _GuideComponent:ViewComponent
    {
        private readonly IGuideServices _guideServices;

        public _GuideComponent(IGuideServices guideServices)
        {
            _guideServices = guideServices;
        }
        public IViewComponentResult Invoke(int id)
        {
            var gstr = _guideServices.GetById(id);

            return View(gstr);
        }
    }
}

using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.Areas.Admin.Controllers;

namespace Traversal_Rezervasyon.Controllers
{
    public class GuideController : Controller
    {
        private readonly IGuideServices _guideServices;

        public GuideController(IGuideServices guideServices)
        {
            _guideServices = guideServices;
        }
        public IActionResult Index()
        {
            var gstr = _guideServices.list();

            return View(gstr);
        }
    }
}

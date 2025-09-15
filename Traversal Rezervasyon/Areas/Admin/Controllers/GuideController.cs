using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        private readonly IGuideServices _ıguideservices;

        private readonly ILogger<GuideController> _logger;


        public GuideController(IGuideServices guideServices,ILogger<GuideController> logger)
        {
            _ıguideservices = guideServices;

            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Index Sayfasına Yönlendirildi");
            var gstr = _ıguideservices.list();
            return View(gstr);
        }

        public IActionResult DeleteGuide(int id)
        {
            var gstr = _ıguideservices.GetById(id);
            _ıguideservices.Delete(gstr);

            return RedirectToAction("Index");
        }

        
        public IActionResult ChangePasif(int id)
        {
            var gstr = _ıguideservices.GetById(id);

            gstr.Status = false;

            _ıguideservices.Update(gstr);

            return RedirectToAction("Index");
        }


        public IActionResult ChangeAktif(int id)
        {
            var gstr = _ıguideservices.GetById(id);

            gstr.Status = true;

            _ıguideservices.Update(gstr);

            return RedirectToAction("Index");
        }

       


    }
}

using Azure.Core.GeoJson;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRule;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

using Traversal_Rezervasyon.Areas.Admin.Models;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        private readonly IGuideServices _ıguideservices;

        private readonly ILogger<GuideController> _logger;


        public GuideController(IGuideServices guideServices, ILogger<GuideController> logger)
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

        [HttpGet]
        public IActionResult UpdateGuide(int id)
        {
            var gstr = _ıguideservices.GetById(id);

            UpdateGuideModel p = new UpdateGuideModel()
            {
                id = gstr.GuideID,

                Name = gstr.Name,

                Description = gstr.Description,

                ImageURL = gstr.ImageURL,

                TwitterURL = gstr.TwitterURL,

                InstagramURL = gstr.InstagramURL,

                Status = gstr.Status,

            };

            return View(p);
        }

        [HttpPost]

        public async Task<IActionResult> UpdateGuide(UpdateGuideModel p)
        {

            ViewBag.VDurum = p.Status;



            var gstr = _ıguideservices.GetById(p.id);
            Guide guide = new Guide()
            {
                GuideID = p.id,

                Name = p.Name,

                Description = p.Description,

                TwitterURL = p.TwitterURL,

                InstagramURL = p.InstagramURL,

                Status = gstr.Status,

                ImageURL = gstr.ImageURL
            };
            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();

                var extension = Path.GetExtension(p.Image.FileName);

                var imagename = Guid.NewGuid() + extension;

                var savelocation = resource + "/wwwroot/GuideProfileFoto/" + imagename;

                var stream = new FileStream(savelocation, FileMode.Create);

                await p.Image.CopyToAsync(stream);

                guide.ImageURL = imagename;
            }




            _ıguideservices.Update(guide);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuide(AddGuideModel p)
        {


         

            Guide guide = new Guide()
            {
                Name = p.Name,
                Description = p.Description,

                TwitterURL = p.TwitterURL,

                InstagramURL = p.InstagramURL,

                Status = true



            };

            var resource = Directory.GetCurrentDirectory();

            var extension = Path.GetExtension(p.Image.FileName);

            var imagename = Guid.NewGuid() + extension;

            var savelocation = resource + "/wwwroot/GuideProfileFoto/" + imagename;

            var stream = new FileStream(savelocation, FileMode.Create);

            await p.Image.CopyToAsync(stream);

            guide.ImageURL = imagename;


           
                _ıguideservices.Add(guide);

                return RedirectToAction("Index");
            
        

            
        }

    }
}

using AspNetCoreGeneratedDocument;
using AutoMapper;
using BusinessLayer.Abstract;
using DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.Areas.Admin.Models;


namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementServices _ıannouncemenservices;

        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementServices announcementServices, IMapper mapper)
        {
            _ıannouncemenservices = announcementServices;
            _mapper = mapper;

        }
        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDTO>>(_ıannouncemenservices.list());

            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDTO p)
        {
            if (ModelState.IsValid)
            {
                p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                _ıannouncemenservices.Add(new EntityLayer.Concrete.Announcement
                {
                    Title = p.Title,

                    Content = p.Content,

                    Date = p.Date
                });
                TempData["Success"] = true;
                return RedirectToAction("Index");
            }

            return View(p);
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var gstr = _ıannouncemenservices.GetById(id);

            _ıannouncemenservices.Delete(gstr);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var nznz = _mapper.Map<AnnouncementUpdateDTO>(_ıannouncemenservices.GetById(id));

            return View(nznz);
        }

        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO announcement)
        {
            if (ModelState.IsValid)
            {


                _ıannouncemenservices.Update(new Announcement
                {
                    AnnouncementID = announcement.AnnouncementID,
                    Title = announcement.Title,
                    Content =announcement.Content,
                    Date = Convert.ToDateTime(DateTime.Now)

                });

                return RedirectToAction("Index");
            }
            return View(announcement);

        }
    }
}

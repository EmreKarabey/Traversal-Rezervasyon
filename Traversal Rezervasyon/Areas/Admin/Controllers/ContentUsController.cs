using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DocumentFormat.OpenXml.Office.CoverPageProps;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContentUsController : Controller
    {

        private readonly IContentUsServices _contentUsServices;

        public ContentUsController(IContentUsServices contentUsServices)
        {
            _contentUsServices = contentUsServices;
        }
        public IActionResult Index()
        {
            var gstr = _contentUsServices.list();
            return View(gstr);
        }
    }
}

 using System.Linq.Expressions;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Traversal_Rezervasyon.Areas.Members.Controllers
{
    [Area("Members")]
    [AllowAnonymous]
    public class DestinationController : Controller
    {

        DestinationManager destinationManager = new DestinationManager(new EFDestination());
        public IActionResult Index()
        {
            var gstr = destinationManager.list();
            return View(gstr);
        }

        public IActionResult DestinationSearch(string searchdestination)
        {
            ViewData["CurrentFiltre"] = searchdestination;

            var values = from x in destinationManager.list() select x;

            if (!string.IsNullOrEmpty(searchdestination))
            {
                values = values.Where(n => n.City.Contains(searchdestination));
            }

            return View(values.ToList());
        }
    }
}

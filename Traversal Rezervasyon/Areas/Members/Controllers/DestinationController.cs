using System.Linq.Expressions;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}

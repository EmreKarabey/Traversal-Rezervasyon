using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.CRQS.Commands;
using Traversal_Rezervasyon.CRQS.Handlers;
using Traversal_Rezervasyon.CRQS.Queries;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class MediatRGuideController : Controller
    {
      
        private readonly IMediator _mediatR;
        public MediatRGuideController(IMediator mediator)
        {
            _mediatR = mediator;
        }
        public async Task< IActionResult> Index()
        {
            var gstr = await _mediatR.Send(new GetAllGuideQueryQueries());
            return View(gstr);
        }

        public async Task<IActionResult> GetById(int id)
        {
            var gstr = await _mediatR.Send(new GetByIdGuideQueryQueries(id));

            return View(gstr);
        }

        [HttpGet]
        public async Task<IActionResult> AddGuide()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuide(GetCreateGuideQueryCommand p)
        {
           await _mediatR.Send(p);
            return RedirectToAction("Index");
        }
    }
}

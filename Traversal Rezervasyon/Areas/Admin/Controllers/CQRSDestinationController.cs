using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.CRQS.Commands;
using Traversal_Rezervasyon.CRQS.Handlers;
using Traversal_Rezervasyon.CRQS.Queries;
using Traversal_Rezervasyon.CRQS.Results;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class CQRSDestinationController : Controller
    {
        private readonly GetAllDestinationQueryHandlers _getAllDestinationQueryHandlers;

        private readonly GetDestinationQueryHandlers _getDestinationQueryHandlers;

        private readonly GetAddDestinationQueryHandlers _getAddDestinationQueryHandlers;


        private readonly GetDeleteDestinationQueryHandlers _getDeleteDestinationQueryHandlers;

        private readonly GetUpdateDestinationQueryHandlers _getUpdateDestinationQueryHandlers;


        public CQRSDestinationController(GetAllDestinationQueryHandlers getAllDestinationQueryHandlers,GetDestinationQueryHandlers getDestinationQueryHandlers,GetAddDestinationQueryHandlers getAddDestinationQueryHandlers,GetDeleteDestinationQueryHandlers getDeleteDestinationQueryHandlers,GetUpdateDestinationQueryHandlers getUpdateDestinationQueryHandlers)
        {
            _getAllDestinationQueryHandlers = getAllDestinationQueryHandlers;
            _getDestinationQueryHandlers = getDestinationQueryHandlers;
            _getAddDestinationQueryHandlers = getAddDestinationQueryHandlers;
            _getDeleteDestinationQueryHandlers = getDeleteDestinationQueryHandlers;
            _getUpdateDestinationQueryHandlers = getUpdateDestinationQueryHandlers;
        }
        public IActionResult Index()
        {
            var gstr = _getAllDestinationQueryHandlers.getAllDestinationQueryResults();
            return View(gstr);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var gstr = _getDestinationQueryHandlers.Handle(new GetDestinationQueryQueries(id));

            return View(gstr);
        }

        [HttpPost]
        public IActionResult GetById(GetUpdateDestinationQueryCommands id)
        {
            _getUpdateDestinationQueryHandlers.Handle(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddDestional()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestional(GetAddDestinationQueryCommand p)
        {
            _getAddDestinationQueryHandlers.AddHandle(p);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestional(int id)
        {
            _getDeleteDestinationQueryHandlers.Handle(new GetDeleteDestinationQueryCommands(id));

            return RedirectToAction("Index");
        }

       
    }
}

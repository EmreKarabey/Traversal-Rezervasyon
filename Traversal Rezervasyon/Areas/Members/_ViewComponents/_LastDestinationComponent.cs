using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Members._ViewComponents
{
    public class _LastDestinationComponent:ViewComponent
    {
        private readonly IDestinationServices _destinationServices;
        public _LastDestinationComponent(IDestinationServices destinationServices)
        {
            _destinationServices = destinationServices;
        }
       
        public IViewComponentResult Invoke()
        {
            var gstr = _destinationServices.Top4Destination();
            return View(gstr);
        }
    }
}

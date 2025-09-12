using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        IReservationServices _ıreservations;

        public ReservationController(IReservationServices reservationServices)
        {
            _ıreservations = reservationServices;
        }
        public IActionResult LastReservations(int id)
        {
            var gstr = _ıreservations.LastReservations(id);
            return View(gstr);
        }
    }
}

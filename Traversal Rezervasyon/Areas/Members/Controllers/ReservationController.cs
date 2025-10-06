using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Traversal_Rezervasyon.Areas.Members.Controllers
{
    [Area("Members")]
    public class ReservationController : Controller
    {
        ReservationManager reservationManager = new ReservationManager(new EFReservation());

        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public async Task <IActionResult> NewReservation()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> NewReservation(Reservation reservation)
        {
            var gstr = await _userManager.GetUserAsync(User);

            reservation.AppUserID = gstr.Id;

            reservation.Status = "Onay Bekleniyor";

            reservationManager.Add(reservation);

            TempData["Message"] = "Rezervasyon başarıyla eklendi!";

            return View();

        }

        public async Task< IActionResult> MyCurrentReservation()
        {
            var gstr = await _userManager.GetUserAsync(User);

            var nzn =  reservationManager.IncludeCurrentReservations(gstr.Id);

            return View(nzn);
        }

        public async Task<IActionResult> MyOldReservation()
        {
            var gstr = await _userManager.GetUserAsync(User);

            var nzn = reservationManager.IncludeOldReservations(gstr.Id);
            return View(nzn);
        }

        public async Task< IActionResult> MyApprovalReservation()
        {
            var id = await _userManager.GetUserAsync(User);

            var gstr = reservationManager.IncludeReservations(id.Id);

        
            return View(gstr);
        }

   
      
    }
}

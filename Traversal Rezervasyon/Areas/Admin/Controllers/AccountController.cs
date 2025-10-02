using BusinessLayer.Abstract.UowServices;
using DTOs.AccountDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUowAccountServices _uowAccountServices;
        public AccountController(IUowAccountServices uowAccountServices)
        {
            _uowAccountServices = uowAccountServices;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult TransferBalance()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TransferBalance(AccountUpdateDTO p)
        {
            var Sender = _uowAccountServices.GetById(p.SenderID);

            var Receive = _uowAccountServices.GetById(p.ReceiveID);

            Sender.Balance += p.Balance;

            Receive.Balance -= p.Balance;



            List<Account> accountUpdateDTOs = new List<Account>()
            {
               Sender,
               Receive
            };

            _uowAccountServices.Multipart(accountUpdateDTOs);

            return RedirectToAction("Index");
        }
    }
}

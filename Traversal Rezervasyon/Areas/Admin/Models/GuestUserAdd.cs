using System.ComponentModel.DataAnnotations;
using Microsoft.DotNet.Scaffolding.Shared;

namespace Traversal_Rezervasyon.Areas.Admin.Models
{
    public class GuestUserAdd
    {
        [Required(ErrorMessage = "Lütfen İsim Giriniz")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Lütfen Soyisim Giriniz")]
        public string Surname { get; set; }


        [Required(ErrorMessage ="Lütfen Mail Giriniz")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string Password { get; set; }


        [Required(ErrorMessage ="Lütfen Tekrar Şifrenizi Giriniz")]
        [Compare("Password",ErrorMessage ="Şifreniz İle Aynı Olmak Zorunda")]
        public string ConfirmPasword { get; set; }

        [Required(ErrorMessage = "Lütfen Telefon Numrasını Giriniz")]
        public string PhoneNumber { get; set; }

     
        public string ImageURL { get; set; }
        public IFormFile Image { get; set; }


        [Required(ErrorMessage = "Lütfen Cinsiyeti Giriniz Giriniz")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz")]
        public string UserName { get; set; }
    }
}

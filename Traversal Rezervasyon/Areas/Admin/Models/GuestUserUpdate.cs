using System.ComponentModel.DataAnnotations;

namespace Traversal_Rezervasyon.Areas.Admin.Models
{
    public class GuestUserUpdate
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Lütfen İsim Giriniz")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Lütfen Soyisim Giriniz")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        public string Email { get; set; }

        [MinLength(6, ErrorMessage = "Minimum 6 Karakter Uzunluğunda Omalıdır.")]
        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Lütfen Tekrar Şifrenizi Giriniz")]
        [Compare("Password", ErrorMessage = "Şifreniz İle Aynı Olmak Zorunda")]
        public string ConfirmPasword { get; set; }


        [Required(ErrorMessage = "Lütfen Telefon Numrasını Giriniz")]
        [MinLength(11, ErrorMessage = "11 Karakter Uzunluğunda Olmalıdır")]
        [MaxLength(11, ErrorMessage = "11 Karakter Uzunluğunda Olmalıdır")]
        public string PhoneNumber { get; set; }


        public string ImageURL { get; set; }
        public IFormFile Image { get; set; }


        [Required(ErrorMessage = "Lütfen Cinsiyeti Giriniz Giriniz")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz")]
        public string UserName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Traversal_Rezervasyon.Models
{
    public class UserRegisterViewModel
    {
        
        [Required(ErrorMessage = "Lütfen İsminizi Boş Bırakmayın")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyisminizi Boş Bırakmayın")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Mailinizi Boş Bırakmayın")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen Telefon Numaranızı Boş Bırakmayın")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Boş Bırakmayın")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Girin Boş Bırakmayın")]
        [Compare("Password",ErrorMessage ="Şifreniz İle Aynı olmak Zorunda !")]
        public string ComparePassword { get; set; }


        [Required(ErrorMessage = "Lütfen Resim Alanını Boş Bırakmayın")]
        public string ImageURL { get; set; }

        public IFormFile Image { get; set; }


        [Required(ErrorMessage = "Lütfen Cinsiyetinizi Boş Bırakmayın")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Boş Bırakmayın")]
        public string UserName { get; set; }
    }
}

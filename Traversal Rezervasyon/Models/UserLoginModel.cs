using System.ComponentModel.DataAnnotations;

namespace Traversal_Rezervasyon.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }
    }
}

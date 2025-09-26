using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.AppUserDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRule
{
    public class UserRegisterValidation : AbstractValidator<UserRegisterModel>
    {
        public UserRegisterValidation()
        {
            RuleFor(n => n.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
            RuleFor(n => n.Surname).NotEmpty().WithMessage("Soyisim Alanı Boş Geçilemez");
            RuleFor(n => n.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez");
            RuleFor(n => n.Phone).NotEmpty().WithMessage("Telefon Alanı Boş Geçilemez");
            RuleFor(n => n.Password).NotEmpty().WithMessage("Şifre Alanı Boş Geçilemez");
            RuleFor(n => n.ComparePassword).NotEmpty().WithMessage("Şifre Tekrar Alanı Boş Geçilemez");
            RuleFor(n => n.Gender).NotEmpty().WithMessage("Cinsyet Alanı Boş Geçilemez");
            RuleFor(n => n.UserName).NotEmpty().WithMessage("Kullanıcı Alanı Boş Geçilemez");

            RuleFor(n => n.Password).MinimumLength(6).WithMessage("Minimum 6 Karakter Olmak Zorunda Olmalıdır");
            RuleFor(n => n.Password).Equal(N => N.ComparePassword).WithMessage("Şifre Tekrar Alanı, Şifre ile aynı Olmak Zorunda Olmalıdır");
            RuleFor(n => n.UserName).MinimumLength(5).WithMessage("Minimum 5 Karakter Olmak Zorunda Olmalıdır");

        }
    }
}

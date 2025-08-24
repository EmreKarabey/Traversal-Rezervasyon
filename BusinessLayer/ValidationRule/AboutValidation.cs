using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRule
{
    public class AboutValidation : AbstractValidator<About>
    {
        public AboutValidation()
        {
            RuleFor(n => n.Description).NotEmpty().WithMessage("Açıklama Boş Bırakılamaz");

            RuleFor(n => n.Image).NotEmpty().WithMessage("Resim Boş Bırakılamaz");

            RuleFor(n => n.Description).MinimumLength(50).WithMessage("Açıklama Kısmı Minimum 50 Karakter Olmak Zorunda");

            RuleFor(n => n.Description).MaximumLength(1500).WithMessage("Açıklama Kısmı Maksimum 1500 Karakter Olmak Zorunda");
        }
    }
}

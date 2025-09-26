using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRule
{
    public class AnnouncementUpdateValidation:AbstractValidator<Announcement>
    {

        public AnnouncementUpdateValidation()
        {
            RuleFor(n => n.Title).NotEmpty().WithMessage("Başlık Boş Geçilemez");
            RuleFor(n => n.Content).NotEmpty().WithMessage("İçerik Boş Geçilemez");
        }
     
    }
}

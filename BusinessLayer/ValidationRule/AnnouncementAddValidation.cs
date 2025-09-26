using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRule
{
    public class AnnouncementAddValidation:AbstractValidator<AnnouncementAddDTO>
    {
        public AnnouncementAddValidation()
        {
            RuleFor(n => n.Title).NotEmpty().WithMessage("Başlık Boş Bırakılamaz");
            RuleFor(n => n.Content).NotEmpty().WithMessage("İçerik Boş Bırakılamaz");
        }
    }
}

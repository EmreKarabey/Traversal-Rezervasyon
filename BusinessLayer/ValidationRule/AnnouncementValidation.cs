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
    public class AnnouncementValidation:AbstractValidator<AnnouncementDTOs>
    {
        public AnnouncementValidation()
        {
            RuleFor(n=>n.Title).NotEmpty().WithMessage("Lütfen Başlığı Boş Geçmeyin");
            
            
        }
    }
}

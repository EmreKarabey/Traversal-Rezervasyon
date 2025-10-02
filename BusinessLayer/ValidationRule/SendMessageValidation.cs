using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.ContentDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRule
{
    public class SendMessageValidation:AbstractValidator<SendContentDTOs>
    {
        public SendMessageValidation()
        {
            RuleFor(n => n.Name).NotEmpty().WithMessage("İsim Alanı Boş Bırakılamaz");
            RuleFor(n => n.Subject).NotEmpty().WithMessage("Konu Alanı Boş Bırakılamaz");
            RuleFor(n => n.Mail).NotEmpty().WithMessage("Mail Alanı Boş Bırakılamaz");
            RuleFor(n => n.MessageDetail).NotEmpty().WithMessage("Mesaj Detayı Alanı Boş Bırakılamaz");
        }
    }
}

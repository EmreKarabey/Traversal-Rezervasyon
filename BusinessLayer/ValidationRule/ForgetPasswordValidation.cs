using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Traversal_Rezervasyon.Models;

namespace BusinessLayer.ValidationRule
{
    public class ForgetPasswordValidation:AbstractValidator<ForgetPasswordModel>
    {
        public ForgetPasswordValidation()
        {
            RuleFor(n => n.Mail).NotEmpty().WithMessage("Lütfen Mail Girin");
        }
    }
}

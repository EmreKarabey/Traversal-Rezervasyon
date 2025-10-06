using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;
using Traversal_Rezervasyon.Models;

namespace BusinessLayer.ValidationRule
{
    public class ResetPasswordValidation : AbstractValidator<ResetPasswordModel>
    {
        public ResetPasswordValidation()
        {
            RuleFor(n => n.NewPassword).NotEmpty().WithMessage("Lütfen Yeni Şifrenizi Girin");
            RuleFor(n => n.ConfirmPassword).NotEmpty().WithMessage("Lütfen Yeni Şifrenizi Tekrar Girin");
            RuleFor(n => n.ConfirmPassword).Equal(n=>n.NewPassword).WithMessage("Yeni Şifrenizi Tekrar Girin");
        }
    }
}

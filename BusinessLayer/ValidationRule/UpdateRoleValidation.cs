using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.RoleDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRule
{
    public class UpdateRoleValidation:AbstractValidator<UpdateRoleDtos>
    {
        public UpdateRoleValidation()
        {
            RuleFor(n => n.Name).NotEmpty().WithMessage("İsim Alanı Boş Bırakılamaz");
        }
    }
}

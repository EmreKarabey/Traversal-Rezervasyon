using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.RoleDTOs;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRule
{
    public class AddRoleValidation:AbstractValidator<AddRoleDtos>
    {
        public AddRoleValidation()
        {
            RuleFor(N => N.Name).NotEmpty().WithMessage("İsim Alanı Boş Bırakılamaz");
        }
    }
}

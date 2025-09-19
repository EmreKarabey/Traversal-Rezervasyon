using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRule
{
    public class GuidValidation:AbstractValidator<Guide>
    {
        public GuidValidation()
        {

        }
    }
}

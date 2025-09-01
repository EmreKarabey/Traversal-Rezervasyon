using Microsoft.AspNetCore.Identity;

namespace Traversal_Rezervasyon.Models
{
    public class ValidationForPassword : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = "PasswordTooShort",
                Description = "Parola minimum " + length + " karakter uzunluğunda olmalıdır"
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresLower",
                Description = "Parola en az bir tane küçük karakter olmalıdır"

            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code= "PasswordRequiresUpper",

                Description="Parola en az bir tane büyük karakter olmalıdır"
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresNonAlphanumeric",

                Description = "Parola en az bir tane sembol olmalıdır"
            };
        }
    }
}

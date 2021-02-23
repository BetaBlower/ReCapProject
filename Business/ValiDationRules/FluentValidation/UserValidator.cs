using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValiDationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<Users>
    {
        public UserValidator()
        {
            RuleFor(u => u.Password).MinimumLength(8);
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).MinimumLength(2);
        }
    }
}

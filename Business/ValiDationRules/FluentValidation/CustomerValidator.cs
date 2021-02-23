using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValiDationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customers>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).MinimumLength(2);
        }
    }
}

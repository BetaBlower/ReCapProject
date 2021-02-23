using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValiDationRules.FluentValidation
{
    public class RentalsValidator:AbstractValidator<Rentals>
    {
        public RentalsValidator()
        {
        }
    }
}

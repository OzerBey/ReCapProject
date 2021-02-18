using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.RentDate).Must(RentalDateCannotBeLessThanTodayDate).WithMessage("Date given must be less than today's date ");
            RuleFor(r => r.ReturnDate).NotEmpty();
            RuleFor(r => r.ReturnDate).Must(DeliveryDateShouldBeGreater).WithMessage("The given date must be greater than today's date ");
        }

        private bool RentalDateCannotBeLessThanTodayDate(DateTime arg)
        {
            return arg.Date < DateTime.Today;
        }

        private bool DeliveryDateShouldBeGreater(DateTime arg)
        {
            return arg.Date > DateTime.Now;
        }
    }
}

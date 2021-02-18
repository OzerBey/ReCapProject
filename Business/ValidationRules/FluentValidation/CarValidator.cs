using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(100);
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo("2000");
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.Descriptions).NotEmpty();

        }
    }
}

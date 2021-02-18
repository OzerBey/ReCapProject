using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;//for AbstractValidator

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            // RuleFor(b => b.BrandId).GreaterThan(0).When(b=>b.BrandId==1); example
            RuleFor(b => b.BrandName).MinimumLength(3);//name's length of brand must 2 greater than character 
            RuleFor(b => b.BrandName).NotEmpty();
            RuleFor(b => b.BrandName).Must(StartWithA).WithMessage("Marka isimleri A harfi ile başlamalıdır !");//custom 
        }

        //my custom method
        private bool StartWithA(string arg)//if true rule provided else not provide
        {
            return arg.StartsWith("A");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);//validate while BrandValidator the context
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors); //else throw exception
            }
        }
    }
}

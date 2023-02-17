using FluentValidation;
using Practicum.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Service.Validations
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(x => x.CategoryName).NotNull().WithMessage("{PropertyName} is required!").NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(x => x.CompanyId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0!");
        }
    }
}
using FluentValidation;
using Practicum.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Service.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.ProductName).NotNull().WithMessage("{PropertyName} is required!").NotEmpty().WithMessage("{PropertyName} is required!").MinimumLength(2).WithMessage("{PropertyName} is must be between 2 and 150 characters.").MaximumLength(150).WithMessage("{PropertyName} is must be between 2 and 150 characters.");

            RuleFor(x => x.CompanyId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0!");

            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0!");

            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0!");

            RuleFor(x => x.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0!");            
        }
    }
}

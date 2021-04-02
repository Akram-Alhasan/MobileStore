using FluentValidation;
using MobileStore.Services.Catalog.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Services.Catalog.WebApi.FluentValidators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(e => e.Name).NotNull().NotEmpty();
        }
    }
}

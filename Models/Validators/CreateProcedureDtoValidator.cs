using CountieAPI.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountieAPI.Models.Validators
{
    public class CreateProcedureDtoValidator : AbstractValidator<CreateProcedureDto>
    {
        public CreateProcedureDtoValidator(CountieDbContext dbContext)
        {
            RuleFor(x => x.CategoryId)
                .NotEmpty();

            RuleFor(x => x.CategoryId)
                .Custom((value, context) =>
                {
                    var categoryExist = dbContext.Categories.Any(n => n.Id == value);
                    if (!categoryExist)
                    {
                        context.AddFailure("No category!");
                    }
                });
        }
    }
}

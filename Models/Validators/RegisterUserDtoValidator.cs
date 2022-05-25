using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountieAPI.Entities;
using FluentValidation;

namespace CountieAPI.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(CountieDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("Invalid email address format!")
                .Custom((value, context) => { var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "Account with this email already exist!");
                    }
                });

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(8).WithMessage("Password must have at least 8 characters")
                .Matches("[A-Z]").WithMessage("Passwords must contain minimum of 1 upper case letter [A-Z]")
                .Matches("[a-z]").WithMessage("Passwords must contain minimum of 1 lower case letter [a-z]")
                .Matches("[0-9]").WithMessage("Passwords must contain minimum of 1 numeric characte [0-9]")
                .MaximumLength(20).WithMessage("Password must have at most 20 characters");

            RuleFor(x => x.ConfirmPassword)
                .Equal(r => r.Password)
                .WithMessage("Password do not match");
        }
    }
}

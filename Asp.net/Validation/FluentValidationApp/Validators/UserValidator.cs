namespace FluentValidationApp.Validators;

using FluentValidation;
using ValidationApp.Models;

public class UserValidator : AbstractValidator<User>
{
    private const int name_max_length = 30;
    public UserValidator()
    {
        base.RuleFor((user) => user.Name)
            .NotEmpty()
                .WithMessage("Name bosh ola bilmez!")
            .MaximumLength(name_max_length)
                .WithMessage($"Name maksimum {name_max_length} simvoldan ibaret ola biler!");

        base.RuleFor((user) => user.Surname)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(30)
            .NotEqual("Bob");

        base.RuleFor((user) => user.Age)
            .LessThan(120)
            .GreaterThan(18);
    }
}
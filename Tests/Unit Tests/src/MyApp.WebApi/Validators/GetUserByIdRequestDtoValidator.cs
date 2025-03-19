namespace MyApp.WebApi.Validators;

using FluentValidation;
using MyApp.WebApi.Dtos;

public class GetUserByIdRequestDtoValidator : AbstractValidator<GetUserByIdRequestDto>
{
    public GetUserByIdRequestDtoValidator()
    {
        base.RuleFor(user => user.Id)
            .GreaterThanOrEqualTo(1)
            .NotEmpty();
    }
}
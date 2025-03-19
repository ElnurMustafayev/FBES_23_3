using FluentValidation;
using MediatR;
using MyApp.WebApi.Dtos;
using MyApp.WebApi.Entities;
using MyApp.WebApi.Exceptions;
using MyApp.WebApi.Repositories.Base;

namespace MyApp.WebApi.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequestDto, User>
{
    private readonly IValidator<GetUserByIdRequestDto> validator;
    private readonly IUserRepository repository;

    public GetUserByIdHandler(
        IValidator<GetUserByIdRequestDto> validator,
        IUserRepository repository)
    {
        this.repository = repository;
        this.validator = validator;
    }

    public async Task<User> Handle(GetUserByIdRequestDto request, CancellationToken cancellationToken)
    {
        await this.validator.ValidateAndThrowAsync(request);

        var foundUser = await this.repository.GetUserByIdAsync(request.Id);

        if(foundUser is null) {
            throw new NotFoundException("User not found!");
        }

        return foundUser;
    }
}
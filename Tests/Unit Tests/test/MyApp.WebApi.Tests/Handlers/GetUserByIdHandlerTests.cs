namespace MyApp.WebApi.Tests.Handlers;

using FluentValidation;
using MyApp.WebApi.Dtos;
using MyApp.WebApi.Handlers;
using Moq;
using MyApp.WebApi.Validators;
using MyApp.WebApi.Repositories.Base;
using MyApp.WebApi.Exceptions;
using MyApp.WebApi.Entities;

public class GetUserByIdHandlerTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(-7)]
    public async Task Handle_PassIncorrectData_ThrowValidationException(int id) {
        var dto = new GetUserByIdRequestDto() {
            Id = id,
        };

        var handler = new GetUserByIdHandler(
            validator: new GetUserByIdRequestDtoValidator(), 
            repository: null!);

        await Assert.ThrowsAsync<ValidationException>(async () => await handler.Handle(dto, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_RepositoryReturnsNull_ThrowNotFoundException() {
        var dto = new GetUserByIdRequestDto() {
            Id = 700,
        };

        var repositoryMock = new Mock<IUserRepository>();

        repositoryMock
            .Setup(repository => repository.GetUserByIdAsync(dto.Id))
            .ReturnsAsync(() => null);

        var handler = new GetUserByIdHandler(
            validator: new GetUserByIdRequestDtoValidator(), 
            repository: repositoryMock.Object);

        await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(dto, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_RepositoryReturnsFoundUser_ReturnFoundUser() {
        var dto = new GetUserByIdRequestDto() {
            Id = 700,
        };

        var foundUser = new User {
            Id = dto.Id,
            Name = "CorrectName",
            Surname = "CorrectSurname",
        };

        var repositoryMock = new Mock<IUserRepository>();

        repositoryMock
            .Setup(repository => repository.GetUserByIdAsync(dto.Id))
            .ReturnsAsync(() => foundUser);

        var handler = new GetUserByIdHandler(
            validator: new GetUserByIdRequestDtoValidator(), 
            repository: repositoryMock.Object);

        var result = await handler.Handle(dto, CancellationToken.None);

        Assert.Equal(foundUser, result);
        Assert.NotNull(result);
    }
}
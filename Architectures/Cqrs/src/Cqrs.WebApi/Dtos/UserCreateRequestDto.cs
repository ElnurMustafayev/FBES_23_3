using MediatR;

namespace Cqrs.WebApi.Dtos;

public class UserCreateRequestDto : IRequest<UserCreateOkResponseDto>
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public string? Email { get; set; }
}
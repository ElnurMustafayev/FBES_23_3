namespace MyApp.WebApi.Dtos;

using MediatR;
using MyApp.WebApi.Entities;

public class GetUserByIdRequestDto : IRequest<User>
{
    public required int Id { get; set; }
}
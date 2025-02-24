namespace Cqrs.WebApi.Handlers;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cqrs.WebApi.Dtos;
using Cqrs.WebApi.Models;
using Cqrs.WebApi.Repositories.Base;
using MediatR;

public class UserCreateHandler : IRequestHandler<UserCreateRequestDto, UserCreateOkResponseDto>
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;
    public UserCreateHandler(IUserRepository userRepository, IMapper mapper)
    {
        this.mapper = mapper;
        this.userRepository = userRepository;
    }

    public async Task<UserCreateOkResponseDto> Handle(UserCreateRequestDto request, CancellationToken cancellationToken)
    {
        var newUser = this.mapper.Map<User>(request);

        var createdId = await this.userRepository.InsertAsync(newUser);

        return new UserCreateOkResponseDto {
            Id = createdId,
        };
    }
}
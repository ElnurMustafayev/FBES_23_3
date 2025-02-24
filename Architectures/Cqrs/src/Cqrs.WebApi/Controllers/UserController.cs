namespace Cqrs.WebApi.Controllers;

using System.Net;
using Cqrs.WebApi.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly ISender sender;
    public UserController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserCreateOkResponseDto))]
    public async Task<ActionResult<UserCreateOkResponseDto>> CreateAsync(UserCreateRequestDto dto) {
        var response = await this.sender.Send(dto);

        return base.Ok(response);
    }
}
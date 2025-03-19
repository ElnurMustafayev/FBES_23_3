using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.WebApi.Dtos;
using MyApp.WebApi.Entities;
using MyApp.WebApi.Exceptions;

namespace MyApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ISender sender;
    public UserController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<User>> GetUserById([FromQuery]GetUserByIdRequestDto dto) {
        try {
            var result = await this.sender.Send(dto);
        
            return base.Ok(result);
        }
        catch(ValidationException ex) {
            return base.BadRequest(ex.Errors);
        }
        catch(NotFoundException ex) {
            return base.NotFound(ex.Message);
        }
        catch(Exception) {
            return base.StatusCode(500);
        }
    }
}
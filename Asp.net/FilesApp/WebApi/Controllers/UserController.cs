namespace FilesApp.Controllers;

using FilesApp.Dtos;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateUserAsync([FromForm]UserRequestDto userDto, IFormFile avatar)
    {
        var extension = new FileInfo(avatar.FileName).Extension[1..];
        var userId = Guid.NewGuid();
        string filepath = $"Avatars/{userId}.{extension}";

        using var avatarFileStream = System.IO.File.Create(filepath);
        await avatar.CopyToAsync(avatarFileStream);

        return base.Ok(new
        {
            Id = userId
        });
    }

    [HttpGet("Avatar/{uid}")]
    public async Task<ActionResult> GetAvatar(Guid uid) {
        string avatarFilePath = $"Avatars/{uid}.jpg";

        if(System.IO.File.Exists(avatarFilePath) == false) {
            return base.NotFound();
        }

        var stream = System.IO.File.Open(avatarFilePath, FileMode.Open);

        return base.File(stream, contentType: "image/jpeg");
    }
}
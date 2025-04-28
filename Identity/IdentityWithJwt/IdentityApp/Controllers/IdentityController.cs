using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IdentityApp.Defaults;
using IdentityApp.Dtos;
using IdentityApp.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace IdentityApp.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class IdentityController : ControllerBase
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;
    private readonly JwtOptions jwtOptions;

    public IdentityController(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        IOptions<JwtOptions> jwtOptions
    )
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.jwtOptions = jwtOptions.Value;
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto dto) {
        var foundUser = await userManager.FindByEmailAsync(dto.Login);

#region validation
        if(foundUser == null) {
            return base.BadRequest("Incorrect Login or Password");
        }

        var signInResult = await this.signInManager.PasswordSignInAsync(foundUser, dto.Password, true, true);

        if(signInResult.IsLockedOut) {
            return base.BadRequest("User locked");
        }

        if(signInResult.Succeeded == false) {
            return base.BadRequest("Incorrect Login or Password");
        }
#endregion

        var roles = await userManager.GetRolesAsync(foundUser);

#region generate token

#region key
        var keyStr = jwtOptions.SignatureKey;
        var keyBytes = Encoding.ASCII.GetBytes(keyStr);

        var signingKey = new SymmetricSecurityKey(keyBytes);
        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
#endregion

#region claims
        var claims = roles.Select(role => new Claim(ClaimTypes.Role, role))
            .Append(new Claim(ClaimTypes.NameIdentifier, foundUser.Id))
            .Append(new Claim(ClaimTypes.Name, dto.Login))
            .Append(new Claim(ClaimTypes.Email, dto.Login));
#endregion

        var token = new JwtSecurityToken(
            issuer: jwtOptions.Issuer,
            audience: jwtOptions.Audience,
            claims: claims,
            //notBefore: DateTime.Now.AddMinutes(2),
            expires: DateTime.UtcNow.AddMinutes(jwtOptions.LifetimeInMinutes),
            signingCredentials: signingCredentials
        );

        var handler = new JwtSecurityTokenHandler();
        var tokenStr = handler.WriteToken(token);

#endregion

        return Ok(tokenStr);
    }

    [HttpPost]
    public async Task<IActionResult> Registration(RegistrationDto dto) {
        var newUser = new IdentityUser() {
            Email = dto.Email,
            UserName = dto.Username,
        };

        var result = await userManager.CreateAsync(newUser, dto.Password);

        if(result.Succeeded == false) {
            return base.BadRequest(result.Errors);
        }

        await userManager.AddToRoleAsync(newUser, UserRoleDefaults.User);

        return Ok();
    }
}
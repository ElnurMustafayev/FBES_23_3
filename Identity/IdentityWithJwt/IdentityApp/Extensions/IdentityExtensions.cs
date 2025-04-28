namespace IdentityApp.Extensions;

using IdentityApp.Data;
using IdentityApp.Defaults;
using IdentityApp.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

public static class IdentityExtensions
{
    public static void InitAspnetIdentity(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<MyDbContext>(options =>
        {
            var connectinoString = configuration.GetConnectionString("IdentityDb");
            options.UseNpgsql(connectinoString);
        });

        serviceCollection.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<MyDbContext>();
    }

    public async static Task SeedRolesAsync(this WebApplication app) {
        var scope = app.Services.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        await roleManager.CreateAsync(new IdentityRole(UserRoleDefaults.User));
        await roleManager.CreateAsync(new IdentityRole(UserRoleDefaults.Admin));
    }

    public static void InitAuth(this IServiceCollection services) {
        var jwtOptions = services.BuildServiceProvider().GetRequiredService<IOptions<JwtOptions>>().Value;

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                var keyStr = jwtOptions.SignatureKey;
                var keyBytes = System.Text.Encoding.ASCII.GetBytes(keyStr);

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.Issuer,

                    ValidateAudience = true,
                    ValidAudience = jwtOptions.Audience,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
                };
            });
    }
}
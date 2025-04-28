using IdentityApp.Extensions;
using IdentityApp.Options;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<JwtOptions>()
    .Configure(options => {
        var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();

        if(jwtOptions == null) {
            throw new ArgumentNullException(nameof(jwtOptions));
        }

        options.Audience = jwtOptions.Audience ?? throw new ArgumentNullException(nameof(jwtOptions.Audience));
        options.Issuer = jwtOptions.Issuer ?? throw new ArgumentNullException(nameof(jwtOptions.Issuer));

        if(jwtOptions.LifetimeInMinutes == 0) {
            throw new ArgumentNullException(nameof(jwtOptions.LifetimeInMinutes));
        }

        options.LifetimeInMinutes = jwtOptions.LifetimeInMinutes;

        options.SignatureKey = jwtOptions.SignatureKey;
        //options.SignatureKey = Environment.GetEnvironmentVariable("JWT_KEY") ?? throw new ArgumentNullException(nameof(jwtOptions.SignatureKey));
    });

builder.Services.AddOpenApi();
builder.Services.InitAspnetIdentity(builder.Configuration);
builder.Services.InitAuth();
builder.Services.InitSwagger();

builder.Services.AddControllers();

var app = builder.Build();

await app.SeedRolesAsync();

app.MapOpenApi();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
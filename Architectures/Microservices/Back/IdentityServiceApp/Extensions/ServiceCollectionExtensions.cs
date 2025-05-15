namespace IdentityServiceApp.Extensions;

using IdentityServiceApp.Data;
using IdentityServiceApp.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

public static class ServiceCollectionExtensions
{
    public static void InitAspnetIdentity(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<MyDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("IdentityDb");
            options.UseNpgsql(connectionString);
        });

        serviceCollection.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<MyDbContext>();
    }

    public static void InitAuth(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var jwtSection = configuration.GetSection("Jwt");
        serviceCollection.Configure<JwtOptions>(jwtSection);

        serviceCollection.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                var jwtOptions = jwtSection.Get<JwtOptions>();

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "MyApplication",

                    ValidateAudience = true,
                    ValidAudience = "Big Company",

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(jwtOptions.KeyInBytes)
                };
            });
    }

    public static void InitSwagger(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Jwt Identity Service",
                Version = "v1",
            });

            options.AddSecurityDefinition(
                name: JwtBearerDefaults.AuthenticationScheme,
                securityScheme: new OpenApiSecurityScheme()
                {
                    Description = "Input yout JWT token here:",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                });

            options.AddSecurityRequirement(
                new OpenApiSecurityRequirement() {
                {
                    new OpenApiSecurityScheme() {
                        Reference = new OpenApiReference() {
                            Id = JwtBearerDefaults.AuthenticationScheme,
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    new string[] {}
                }
                }
            );
        });
    }

    public static void InitCors(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddCors(options =>
        {
            options.AddPolicy("BlazorApp", policyBuilder =>
            {
                policyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
}
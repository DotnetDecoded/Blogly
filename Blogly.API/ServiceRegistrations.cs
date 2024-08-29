using System.Text;
using Blogly.Application.Implementations;
using Blogly.Application.Interfaces;
using Blogly.Infrastructure.Repository;
using Blogly.Infrastructure.Repository.services;
using Blogly.Sharedkernel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Blogly;

public static class ServiceRegistrations
{
    public static void ConfigureApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.ConfigureInternalServices();
        serviceCollection.ConfigureDataAccessInfrastructure(configuration);
        serviceCollection.AddSecurity(configuration);
    }

    private static void ConfigureDataAccessInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<BloglyDbContext>(x =>
        {
            x.UseNpgsql(configuration.GetConnectionString("BloglyDb"), builder =>
            {
                builder.EnableRetryOnFailure(5, maxRetryDelay: TimeSpan.FromSeconds(5), null);
            });
        });
    }
    private static void ConfigureInternalServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IBloglyService, BloglyService>();
        serviceCollection.AddScoped<IBloglyRepository, BloglyRepository>();
    }

    private static void AddSecurity(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddAuthentication(x =>
        {
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer("Bearer", options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = configuration["JwtSettings:Audience"],
                ValidIssuer = configuration["JwtSettings:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("IAmTheCornerstoneAndThisIsMySecurityToken.ShareItIfYouMust"))
            };

            options.Events = new JwtBearerEvents()
            {
                OnAuthenticationFailed = x =>
                {
                    if (x.Exception.GetType() != typeof(SecurityTokenExpiredException)) return Task.CompletedTask;
                    x.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    x.Response.ContentType = "application/json";
                    return x.Response.WriteAsJsonAsync(new { message = "The token is expired." });
                },
                
                OnForbidden = x =>
                {
                    x.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    x.Response.ContentType = "application/json";
                    return x.Response.WriteAsJsonAsync(new { message = "Sorry, you do have access to this resource." });
                },
                
                OnChallenge = x =>
                {
                    x.HandleResponse();
                    x.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    x.Response.ContentType = "application/json";
                    return x.Response.WriteAsJsonAsync(new { message = "You are not authorized to access this resource." });
                }
            };
        });

        serviceCollection.AddAuthorization(x =>
        {
            x.AddPolicy("admin_policy", builder =>
            {
                builder.RequireClaim(nameof(Role), Role.Admin.ToString());
            });
            
            x.AddPolicy("author_policy", builder =>
            {
                builder.RequireClaim(nameof(Role), Role.Author.ToString());
            });
        });
    }
}
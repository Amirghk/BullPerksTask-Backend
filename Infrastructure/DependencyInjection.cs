using BullPerksTask.Application.Interfaces.Adapters;
using BullPerksTask.Application.Interfaces.Authentication;
using BullPerksTask.Application.Interfaces.Persistance;
using BullPerksTask.Infrastructure.Adapters;
using BullPerksTask.Infrastructure.Authentication;
using BullPerksTask.Infrastructure.Persistence.Db;
using BullPerksTask.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BullPerksTask.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<ITokenRepository, TokenRepository>();

        services.AddScoped<IWeb3RPCAdapter, Web3RPCAdapter>();

        var sqlServerConnectionString = configuration.GetConnectionString("SQLServer");

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseInMemoryDatabase("InMemoryDb");
            //options.UseSqlServer(sqlServerConnectionString); // uncomment this line and comment the line above to use sql server
        });

        var web3RPCSettings = new Web3RPCSettings();

        configuration.Bind(Web3RPCSettings.SectionName, web3RPCSettings);

        services.AddSingleton(Options.Create(web3RPCSettings));

        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();

        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>(); 

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSettings.Secret)
                        )
            });

        return services;
    }
}

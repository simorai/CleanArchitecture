using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchMvc.Infra.Ioc
{
    // Extension method to add JWT authentication to the service collection must be public and static
    public static class DependencyInjectionJWT
    {
        public static IServiceCollection AddInfrastructureJWT(this IServiceCollection services,
    IConfiguration configuration)
        {
            // inform the type of authentication jwt bearer
            // define the default scheme for authentication and challenge
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // enables JWT authentication using the defined scheme and challenge
            // validates the token
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    // define issuer, audience and signing key
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                    ClockSkew = TimeSpan.Zero // Eliminate delay of token when expire
                };
            });
            return services;
        }

    }
}

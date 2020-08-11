using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace test.WebApi.Extensions
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection AddAthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuthentication()
                .AddCookie()
                .AddJwtBearer(cfg =>
                {
                    
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        
                        ValidIssuer = configuration["Tokens:Issuer"],
                        ValidAudience = configuration["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]))
                    };
                });

            return services;
        }
    }
}

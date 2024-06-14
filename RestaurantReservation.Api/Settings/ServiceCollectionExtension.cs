using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace RestaurantReservation.Api.Settings;

public static class ServiceCollectionExtension
{
    public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(k =>
        {
            k.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            k.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(p =>
        {
            var key = Encoding.UTF8.GetBytes(configuration["JWTToken:Key"]
                                             ?? throw new ArgumentException("JWTToken:Key"));
            p.SaveToken = true;
            p.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWTToken:Key"],
                ValidAudience = configuration["JWTToken:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });
    }
}
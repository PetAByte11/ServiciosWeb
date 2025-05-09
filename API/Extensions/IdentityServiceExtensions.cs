<<<<<<< HEAD
=======
namespace API.Extensions;
>>>>>>> datingapp/main
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

<<<<<<< HEAD
namespace API.Extensions;

=======
>>>>>>> datingapp/main
public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
<<<<<<< HEAD
        .AddJwtBearer(options =>
        {
            var tokenKey = config["TokenKey"] ?? throw new ArgumentNullException("Tokenkey");
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        
        return services;
    }
}
=======
            .AddJwtBearer(options =>
            {
                var tokenKey = config["TokenKey"] ?? throw new ArgumentException("TokenKey");
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        return services;
    }
}
>>>>>>> datingapp/main

using AutoMapper;
using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Interfaces.Profile;

using HelpMeApp.Services.MappingProfiles;
using HelpMeApp.Services.Services;
using HelpMeApp.Services.Services.Profile;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HelpMeApp.WebAPI.ServiceCollectionConfiguration
{
    public static class ServiceCollectionExtensionMethods
    {
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfig = configuration.GetSection("jwtConfig");
            var key = jwtConfig["key"];
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig["Issuer"],
                    ValidAudience = jwtConfig["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });
            
        }

        public static void ConfigureMapping(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(map =>
            {
                map.AddProfile<AppUserMappingProfile>();
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }

        public static void BindServices(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IProfileService, ProfileService>();
        }
    }
}

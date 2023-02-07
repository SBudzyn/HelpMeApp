using AutoMapper;
using HelpMeApp.DatabaseAccess.Interfaces;
using HelpMeApp.DatabaseAccess.Repositories;
using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Interfaces.Profile;

using HelpMeApp.Services.MappingProfiles;
using HelpMeApp.Services.Services;
using HelpMeApp.WebAPI.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

        public static void ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();

                options.AddPolicy("EditPolicy", policy =>
                policy.Requirements.Add(new SameUserRequirement()));
            });

            services.AddTransient<IAuthorizationHandler, EditAllowedAuthorizationHandler>();
        }

        public static void ConfigureMapping(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(map =>
            {
                map.AddProfile<AppUserMappingProfile>();
                map.AddProfile<AdvertMappingProfile>();
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }

        public static void BindServices(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAdvertService, AdvertService>();
        }

        public static void BindRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAdvertReadRepository, AdvertReadRepository>();
            services.AddTransient<IAdvertWriteRepository, AdvertWriteRepository>();
        }
    }
}

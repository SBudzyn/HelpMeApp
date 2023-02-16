﻿using AutoMapper;
using FluentValidation;
using HelpMeApp.DatabaseAccess.Interfaces;
using HelpMeApp.DatabaseAccess.Repositories;
using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.MappingProfiles;
using HelpMeApp.Services.Services;
using HelpMeApp.Services.Validators;
using HelpMeApp.WebAPI.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                policy.Requirements.Add(new CreatorRequirement()));

                options.AddPolicy("UserPolicy", policy =>
                policy.Requirements.Add(new CreatorRequirement()));
            });

            services.AddTransient<IAuthorizationHandler, EditAllowedAuthorizationHandler>();
            services.AddTransient<IAuthorizationHandler, UserValidAuthorizationHandler>();
        }

        public static void ConfigureMapping(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(map =>
            {
                map.AddProfile<AppUserMappingProfile>();
                map.AddProfile<AdvertMappingProfile>();
                map.AddProfile<ReportMappingProfile>();
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }

        public static void ConfigureValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<RegistrationValidator>(ServiceLifetime.Transient);
        }

        public static void BindServices(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAdvertService, AdvertService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IReportService, ReportService>();
        }

        public static void BindRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAdvertReadRepository, AdvertReadRepository>();
            services.AddTransient<IAdvertWriteRepository, AdvertWriteRepository>();
            services.AddTransient<IReportReadRepository, ReportReadRepository>();
            services.AddTransient<IReportWriteRepository, ReportWriteRepository>();
        }
    }
}

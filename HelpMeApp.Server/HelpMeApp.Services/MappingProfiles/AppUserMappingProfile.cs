﻿using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using HelpMeApp.Services.Models.Profile;
using HelpMeApp.Services.Models.Advert;
using HelpMeApp.Services.Models.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.MappingProfiles
{
    public class AppUserMappingProfile : Profile
    {
        public AppUserMappingProfile()
        {
            CreateMap<RegistrationRequestModel, AppUser>()
                .ForMember(src => src.UserName, opt =>
                {
                    opt.MapFrom(src => src.Email);
                });

            CreateMap<AppUser, ProfileResponseData>();

            CreateMap<AdvertPreviewResponseData, ProfileGetUserAdverts>();

            CreateMap<ProfileUpdateData, AppUser>()
                .ForMember(src => src.PasswordHash, opt =>
                {
                    opt.MapFrom(src => src.Password);
                });            
        }   
    }
}

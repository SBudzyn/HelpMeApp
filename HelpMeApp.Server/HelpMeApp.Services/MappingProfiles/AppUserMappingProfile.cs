using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using HelpMeApp.Services.Models.Profile;
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
            CreateMap<AppUser, ProfileRequestModel>();
            CreateMap<ProfileEditionModel, AppUser>()
            .ForMember(dest => dest.Name, opt => opt.Condition(src => (src.Name != null)))
            .ForMember(dest => dest.Surname, opt => opt.Condition(src => (src.Surname != null)))
            .ForMember(dest => dest.PhoneNumber, opt => opt.Condition(src => (src.PhoneNumber != null)))
            .ForMember(dest => dest.Email, opt => opt.Condition(src => (src.Email != null)))
            .ForMember(dest => dest.Info, opt => opt.Condition(src => (src.Info != null)))
            .ForMember(dest => dest.PasswordHash, opt => opt.Condition(src => (src.PasswordHash != null && src.PasswordWasHashed == false)))
            .ForMember(dest => dest.Photo, opt => opt.Condition(src => (src.Photo != null)))
            .ForMember(dest => dest.UserName, opt => opt.Condition(src => (src.Username != null))); 
        }
    }
}

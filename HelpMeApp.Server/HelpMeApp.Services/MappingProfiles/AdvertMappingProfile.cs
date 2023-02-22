using AutoMapper;
using Bogus.Bson;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.PhotoEntity;
using HelpMeApp.DatabaseAccess.Filters;
using HelpMeApp.Services.Helpers;
using HelpMeApp.Services.Models.Advert;
using HelpMeApp.Services.Models.Filters;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.MappingProfiles
{
    public class AdvertMappingProfile : Profile
    {
        public AdvertMappingProfile()
        {
            CreateMap<Advert, AdvertDetailedResponseData>()
                .ForMember(src => src.Category, opt =>
                {
                    opt.MapFrom(src => src.Category.Name);
                })
                .ForMember(src => src.Terms, opt =>
                {
                    opt.MapFrom(src => $"{src.Terms.From}-{src.Terms.Till}");
                })
                .ForMember(src => src.CreatorName, opt =>
                {
                    opt.MapFrom(src => $"{src.Creator.Name} {src.Creator.Surname}");
                });

            CreateMap<Advert, AdvertPreviewResponseData>();

            CreateMap<AdvertPostData, Advert>()
                .ForMember(src => src.Photos, opt =>
                {
                    opt.Ignore();
                });

            CreateMap<AdvertFiltersData, AdvertFilters>();
        }
    }
}

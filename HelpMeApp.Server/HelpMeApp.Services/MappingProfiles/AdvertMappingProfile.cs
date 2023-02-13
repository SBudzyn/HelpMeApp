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
                    opt.MapFrom(src => src.Terms.Days);
                });

            CreateMap<Advert, AdvertPreviewResponseData>();

            CreateMap<AdvertPostData, Advert>();

            CreateMap<AdvertFiltersData, AdvertFilters>();
        }
    }
}

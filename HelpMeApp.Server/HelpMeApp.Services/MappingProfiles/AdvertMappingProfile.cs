using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.Services.Models.Advert;
using System;
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
            CreateMap<Advert, AdvertFullResponseData>()
                .ForMember(src => src.Category, opt =>
                {
                    opt.MapFrom(src => src.Category.Name);
                })
                .ForMember(src => src.Terms, opt =>
                {
                    opt.MapFrom(src => src.Terms.Days);
                });

            CreateMap<Advert, AdvertBoardResponseData>();

            CreateMap<AdvertPostData, Advert>();
        }
    }
}
